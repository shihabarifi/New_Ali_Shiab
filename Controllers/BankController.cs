using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
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
    [Authorize]
    public class BankController : Controller
    {

        private readonly IBank _Repo;
        private readonly posDbContext _context;

        public BankController(IBank repo, posDbContext context) // here the repository will be passed by the dependency injection.
        {
            _Repo = repo;
           _context = context;
        }


        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("sub_accounting_manual");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Bank> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;
            ViewBag.AccHeadeerlist = GetAccounts();

            return View(items);
        }


        public IActionResult Create()
        {
            Bank item = new Bank();

            ViewBag.AccHeadeerlist = GetAccounts();
           
            return View(item);
        }

        [HttpPost]
        public IActionResult Create(Bank item)
        {
            item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
            item.BankId =int.Parse(item.SubAccountingManual);
            item.BankStatus = 0;
            bool bolret = false;
            string errMessage = "";
            try
            {

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
                TempData["SuccessMessage"] = "" + item.BankName + "  تم الإضافة بنجاح";
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Edit(int id)
        {
             Bank bank = _Repo.GetItem(id);
            ViewBag.AccHeadeerlist = GetAccounts();
            return View(bank);

        }

        [HttpPost]
        public IActionResult Edit(Bank bank)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {

                bank.BankId = int.Parse(bank.SubAccountingManual);
                bank.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

                bolret = _Repo.Edit(bank);


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
                return View(bank);
            }
            else
            {
                TempData["SuccessMessage"] = "" + bank.BankName + " تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));
            }
        }

     
        public IActionResult Delete(int id)
        {

            Bank item = _Repo.GetItem(id);
            ViewBag.AccHeadeerlist = GetAccounts();
            return View(item);
         

        }

        [HttpPost]
        public IActionResult Delete(Bank bank)
        {

            int status = bank.BankStatus == 0 ? 1 : 0;
            bool bolret = false;
            string errMessage = "";
            try
            {

                bank.BankId = int.Parse(bank.SubAccountingManual);
                bank.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
                bank.BankStatus = status;
                bolret = _Repo.Edit(bank);


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
                return View(bank);
            }
            else
            {
                if (status == 1)
                {
                    TempData["SuccessMessage"] = "" + bank.BankName + " تم التوقيف بنجاح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["SuccessMessage"] = "" + bank.BankName + " تم التنشيط بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
        }


        public IActionResult Details(int id) //Read
        {
            Bank item = _Repo.GetItem(id);
            ViewBag.AccHeadeerlist = GetAccounts();
            return View(item);
        }

        private List<SelectListItem> GetAccounts()
        {
            List<SelectListItem> lstAccount = _context.AccountingManuals.Where(n => n.ParentAccNumber== "112" && n.AccType=="فرعي" ).OrderBy(n => n.AccNumber).Select(n =>
                new SelectListItem()
                {
                    Value = n.AccNumber.ToString(),
                    Text = n.ArabicAccName
                }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Account----"
            };


            lstAccount.Insert(0, defItem);

            return lstAccount;
        }

    }
}
