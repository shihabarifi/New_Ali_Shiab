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

using Microsoft.AspNetCore.Identity;
using POS.ViewModel;

namespace POS.Controllers
{
    [AllowAnonymous]
    public class PayCheckVoucherController : Controller
    {
        private readonly IPayCheckVoucher _Repo;
        private readonly IAccountingManual _AccountingManualRepo;
        private readonly IFund _FundRepo;
        private readonly ICurrency _CurrencyRepo;
        private readonly IFiscalYear _fiscalYearRepo;
        private readonly IExchangeRate _exchangeRateRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public PayCheckVoucherController(IPayCheckVoucher repo, IAccountingManual accountingManualRepo,
            IFund fundRepo, ICurrency currencyRepo,IFiscalYear fiscalYearRepo,IExchangeRate exchangeRateRepo, UserManager<ApplicationUser> userManager) // here the repository will be passed by the dependency injection.
        {
            _Repo = repo;
            _AccountingManualRepo = accountingManualRepo;
            _FundRepo = fundRepo;
            _CurrencyRepo = currencyRepo;
           _fiscalYearRepo = fiscalYearRepo;
            _exchangeRateRepo = exchangeRateRepo;
            _userManager = userManager;
        }
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("ExDate");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<MainPayCheck> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();

            TempData["CurrentPage"] = pg;

            MainPayCheck item = new MainPayCheck();

            item.DetailedPayChecks.Add(new DetailedPayCheck() { DetailedPayCheckId = 1 });
            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            item.MainPaycheckNumber = _Repo.GetNewEXNumber();
            var f = _fiscalYearRepo.GetItem(1);
            item.FiscalYear = f.FiscalYearId;
            item.SystemUsers = _userManager.GetUserAsync(User).Id.ToString();
            item.MainPaycheckStatus = 0;
            return View(items);
        }


        public IActionResult Stagelist(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("ExDate");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<MainPayCheck> items = _Repo.GetItemsStage(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();

            TempData["CurrentPage"] = pg;


            return View(items);
        }


        [HttpPost]
        public IActionResult Stagelist(string No)
        {
            Procedures _Procedures = new Procedures();

            string errMessage = "";
            try
            {

                string bolret = _Procedures.PayStages(No);

                TempData["SuccessMessage"] = "" + No + " تم الترحيل بنجاح";
                return RedirectToAction(nameof(Stagelist));
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message; return RedirectToAction(nameof(Stagelist));
            }

        }




        public IActionResult Create()
        {
            MainPayCheck item = new MainPayCheck();

            item.DetailedPayChecks.Add(new DetailedPayCheck() { DetailedPayCheckId = 1 });
            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            item.MainPaycheckNumber = _Repo.GetNewEXNumber();
            var f = _fiscalYearRepo.GetItem(1);
            item.FiscalYear = f.FiscalYearId;
            item.SystemUsers = _userManager.GetUserId(User);
            item.MainPaycheckStatus = 0;

            return View(item);
        }

        [HttpPost]
        public IActionResult Create(MainPayCheck item)
        {
            item.DetailedPayChecks.RemoveAll(a => a.DetailedPaycheckAmountRly == 0);
            //item.DetailedExpensVouchers.RemoveAll(a => a. == 0);
            //item.PoDetail.RemoveAll(d=>d.IsDeleted==true);

            bool bolret = false;
            string errMessage = "";
            try
            {
                item.IsDelete = 0;
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

                TempData["SuccessMessage"] = "" + item.MainPaycheckNumber + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpGet]
        public JsonResult GetAcc(int FundId)
        {
            Procedures _Procedures = new Procedures();
            List<Currency> Lcurr = new List<Currency>();
            Lcurr = _Procedures.GetAccCurrByAccNumber(FundId);
            return Json(new SelectList(Lcurr, "CurrenciesId", "CurrenName"));

        }

        [HttpGet]
        public JsonResult GetCurr(int CurrenciesId)
        {
            Procedures _Procedures = new Procedures();
            List<CurrenciesExchangeRate> Exch = new List<CurrenciesExchangeRate>();
            Exch = _Procedures.GetExchangeRateByCurr(CurrenciesId);
            return Json(new SelectList(Exch, "CurrenciesExchangeRateId", "CurreExchangeRate"));
        //    CurrenciesExchangeRate currenciesExchangeRate = new CurrenciesExchangeRate();
        //    currenciesExchangeRate = _exchangeRateRepo.GetItem(CurrenciesId);
        //    return Json(new SelectList(currenciesExchangeRate ));
        }


        public IActionResult Details(string id) //Read
        {
            MainPayCheck item = _Repo.GetItem(id);

            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();
         


            return View(item);
        }
        public IActionResult Delete(string id)
        {
            MainPayCheck item = _Repo.GetItem(id);
          
            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();

            TempData.Keep();
            return View(item);
        }


        [HttpPost]
        public IActionResult Delete(MainPayCheck mainPayCheck)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                mainPayCheck.IsDelete = 1;
                bolret = _Repo.Delete(mainPayCheck);
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
                return View(mainPayCheck);
            }
            else
            {
                TempData["SuccessMessage"] = "" + mainPayCheck.MainPaycheckNumber + " Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }

        }


        public IActionResult Edit(string id)
        {
            MainPayCheck item = _Repo.GetItem(id);

            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();

         

            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(MainPayCheck item)
        {

            item.DetailedPayChecks.RemoveAll(a => a.DetailedPaycheckAmountRly == 0);
            var f = _fiscalYearRepo.GetItem(1);
            item.FiscalYear = f.FiscalYearId;
            item.SystemUsers = _userManager.GetUserId(User);

            bool bolret = false;
            string errMessage = "";
            try
            {
                item.IsDelete = 0;
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
                TempData["SuccessMessage"] = "" + item.MainPaycheckNumber + " Modified Successfully";
                return RedirectToAction(nameof(Index));
            }
        }





        private List<SelectListItem> GetAccounts()
        {
            var lstAccount = new List<SelectListItem>();


            PaginatedList<AccountingManual> product = _AccountingManualRepo.GetItems("Name", SortOrder.Ascending, "فرعي", 1, 1000);
            lstAccount = product.Select(ut => new SelectListItem()
            {
                Value = ut.AccNumber.ToString(),
                Text = ut.ArabicAccName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Accounts----"
            };

            lstAccount.Insert(0, defItem);


            return lstAccount;
        }


        private List<SelectListItem> GetFunds()
        {
            var lstfund = new List<SelectListItem>();


            PaginatedList<Fund> fund = _FundRepo.GetItems("Name", SortOrder.Ascending, "0", 1, 1000);
            lstfund = fund.Select(sp => new SelectListItem()
            {
                Value = sp.FundsId.ToString(),
                Text = sp.FundName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Fund----"
            };

            lstfund.Insert(0, defItem);

            return lstfund;
        }

        private List<SelectListItem> GetCurrency()
        {
            var lstfund = new List<SelectListItem>();


            PaginatedList<Currency> fund = _CurrencyRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstfund = fund.Select(sp => new SelectListItem()
            {
                Value = sp.CurrenciesId.ToString(),
                Text = sp.CurrenName
            }).ToList();

           

            return lstfund;
        }

        private List<SelectListItem> GetExchangeCurrency()
        {
            var lstExC = new List<SelectListItem>();


            PaginatedList<CurrenciesExchangeRate> ExC = _exchangeRateRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
            lstExC = ExC.Select(sp => new SelectListItem()
            {
                Value = sp.CurrenciesExchangeRateId.ToString(),
                Text = sp.CurreExchangeRate.ToString()
            }).ToList();

            return lstExC;
        }


     

    }
}
