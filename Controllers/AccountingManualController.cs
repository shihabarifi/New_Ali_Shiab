using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.StoredProcedure;
using POS.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using POS.Data;

namespace POS.Controllers
{
    [AllowAnonymous]
    public class AccountingManualController : Controller
    {

        private readonly IAccountingManual _Repo;
        private readonly posDbContext _context;
        private readonly ICurrency currencyRepo;

        public AccountingManualController(IAccountingManual repo, posDbContext context,ICurrency currencyRepo) // here the repository will be passed by the dependency injection.
        {
            _Repo = repo;
            _context = context;
            this.currencyRepo = currencyRepo;
        }


        public IActionResult Index(string sortExpression = "", string SearchText = "0", int pg = 1, int pageSize = 50)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("number");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<AccountingManual> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;
            AccountingManual item = new AccountingManual();
            item.AccountsCurrencies.Add(new AccountsCurrency() { AccountsCurrenciesId = 1 });
            ViewBag.AccHeadeerlist = GetAccounts();
            ViewBag.AccCurrlist = GetCurrency();
            ViewBag.GetFinAccTypelist = GetFinAccType();

            return View(items);
        }
      

        public IActionResult Create()
        {
            AccountingManual item = new AccountingManual();
            item.AccountsCurrencies.Add(new AccountsCurrency() { AccountsCurrenciesId = 1 });
            ViewBag.AccHeadeerlist = GetAccounts();
            ViewBag.AccCurrlist = GetCurrency();
            ViewBag.GetFinAccTypelist = GetFinAccType();

            //item.AccNumber = _Repo.GetNewEXNumber();

            return View(item);
        }

       

        [HttpPost]
        public IActionResult Create(AccountingManual item)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

                item.FinalAccountType = 1;
                item.FiscalYear = 7;
                
                bolret = _Repo.Create(item);


            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }
            if (bolret == false)
            {
                errMessage = errMessage + "  " + _Repo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(item);
            }
            else
            {
                TempData["SuccessMessage"] = "" + item.ArabicAccName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }
     

        public ActionResult GetAcc(string AccParentid)
        {


            string exnumber = "";
            int lastdigitx = 1;
            
            var LastPoNumber = _context.AccountingManuals.Where(d => d.ParentAccNumber == AccParentid).Max(a => a.AccNumber);
        
             //   level = _context.AccountingManuals.Where(d => d.ParentAccNumber == AccParentid).ToList();
            if (LastPoNumber == null)
                exnumber = (AccParentid + lastdigitx ).ToString();
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.ToString(), out lastdigit);


                exnumber =  (lastdigit + 1).ToString();
            }

           
            var date =new { status="ok", result=exnumber };


            return Json(date);


    

        }

        public ActionResult GetAcclv(string AccParentidlv)
        {
            int lv = 1;
           
            AccountingManual level = _Repo.GetItem(AccParentidlv);

            string llv = "";
            int.TryParse(level.AccLevel.ToString(), out lv);
            llv = (lv + 1).ToString();
            var date = new { status = "ok", result = llv};


            return Json(date);
        }
        public IActionResult Edit(string id)
        {
            AccountingManual item = _Repo.GetItem(id);

            ViewBag.AccHeadeerlist = GetAccounts();
            ViewBag.AccCurrlist = GetCurrency();

            ViewBag.GetFinAccTypelist = GetFinAccType();



            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(AccountingManual item)
        {
            //item.DetailedPayChecks.RemoveAll(a => a.DetailedPaycheckAmountRly == 0);
            item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

            item.FinalAccountType = 1;
            item.FiscalYear = 7;

            bool bolret = false;
            string errMessage = "";
            try
            {
                item.SystemUsers = "dd355141-337f-4f62-b0ad-54fe90542640";



                bolret = _Repo.Edit(item);
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
            }


            if (bolret == false)
            {
                errMessage = errMessage + " " + _Repo.GetErrors();

                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(item);
            }
            else
            {
                TempData["SuccessMessage"] = "" + item.AccNumber + " Modified Successfully";
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Details(string id) //Read
        {
            AccountingManual item = _Repo.GetItem(id);

            ViewBag.AccHeadeerlist = GetAccounts();
            ViewBag.AccCurrlist = GetCurrency();

            return View(item);
        }
        private List<SelectListItem> GetAccounts()
        {
          List<SelectListItem> lstAccount = _context.AccountingManuals.Where(n => n.AccType=="رئيسي" ).OrderBy(n=>n.AccNumber).Select(n=> 
           new SelectListItem()
            {
                Value = n.AccNumber.ToString(),
                Text =n.ArabicAccName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Account----"
            };

           
            lstAccount.Insert(0, defItem);

            var defIt= new SelectListItem()
            {
                Value = "0",
                Text = "#اب نفسة#"
            };


            lstAccount.Insert(1, defIt);
            return lstAccount;
        }

        private List<SelectListItem> GetCurrency()
        {

            List<SelectListItem> lstAccount = _context.Currencies.Where(a=>a.CurrStatus==0).OrderBy(n => n.CrreChangeName).Select(n =>
             new SelectListItem()
             {
                 Value = n.CurrenciesId.ToString(),
                 Text = n.CurrenName
             }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "Select Currency"
            };

            lstAccount.Insert(0, defItem);

            return lstAccount;

        }

        private List<SelectListItem> GetFinAccType()
        {

            List<SelectListItem> lstAccount = _context.FinalAccountTypes.OrderBy(n => n.FinalAccountTypeId).Select(n =>
             new SelectListItem()
             {
                 Value = n.FinalAccountTypeId.ToString(),
                 Text = n.FinAccType
             }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "Select FinAccType"
            };

            lstAccount.Insert(0, defItem);

            return lstAccount;

        }
    }
}
