using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using POS.Data;
using POS.Resource;

namespace POS.Controllers
{
    [Authorize]
    public class FundController : Controller
    {

        private readonly IFund _Repo;
        private readonly posDbContext _context;

        public FundController(IFund repo, posDbContext context) // here the repository will be passed by the dependency injection.
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

            PaginatedList<Fund> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

            ViewBag.AccHeadeerlist = GetAccounts();
            return View(items);
        }


        public IActionResult Create()
        {
            Fund item = new Fund();

            ViewBag.AccHeadeerlist = GetAccounts();

            return View(item);
        }

        [HttpPost]
        public IActionResult Create(Fund item)
        {
            item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
            item.FundsId = int.Parse(item.SubAccountingManual);
            item.FundStatus = 0;
           
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
                SessionMsg(Helper.Error, ResourceWeb.lbNotSaved, ResourceWeb.lbNotSavedMsgUser);
                return View(item);
            }
            else
            {
                SessionMsg(Helper.Success, ResourceWeb.lbSave, "   تم الإضافة" + item.FundName + "بنجاح + ");
                TempData["SuccessMessage"] = "تم الإضافة " + item.FundName + "  بنجاح";
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Edit(int id)
        {
            Fund fund = _Repo.GetItem(id);
            ViewBag.AccHeadeerlist = GetAccounts();
            return View(fund);

        }

        [HttpPost]
        public IActionResult Edit(Fund fund)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {

                fund.FundsId = int.Parse(fund.SubAccountingManual);
                fund.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

                bolret = _Repo.Edit(fund);
                SessionMsg(Helper.Success, ResourceWeb.lbSave, ResourceWeb.lbNotSavedMsgUserRole);

            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message;
                SessionMsg(Helper.Error, ResourceWeb.lbNotSaved, ResourceWeb.lbNotSavedMsgUser);
            }
            if (bolret == false)
            {
                SessionMsg(Helper.Error, ResourceWeb.lbNotSaved, ResourceWeb.lbNotSavedMsgUser);
                errMessage = errMessage + "  " + _Repo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(fund);
            }
            else
            {
                SessionMsg(Helper.Success, ResourceWeb.lbSave, "   تم التعديل بنجاح  " + fund.FundName );
              
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Delete(int id)
        {
            Fund fund = _Repo.GetItem(id);
            ViewBag.AccHeadeerlist = GetAccounts();
            return View(fund);

        }

        [HttpPost]
        public IActionResult Delete(Fund fund)
        {
            int status = fund.FundStatus == 0 ? 1 : 0;
            bool bolret = false;
            string errMessage = "";
            try
            {

                fund.FundsId = int.Parse(fund.SubAccountingManual);
                fund.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
                fund.FundStatus = status;
                bolret = _Repo.Edit(fund);


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
                return View(fund);
            }
            else
            {
                if (status == 1)
                {
                    TempData["SuccessMessage"] = "" + fund.FundName + " تم التوقيف بنجاح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["SuccessMessage"] = "" + fund.FundName + " تم التنشيط بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
        }


        private void SessionMsg(string MsgType, string Title, string Msg)
        {
            HttpContext.Session.SetString(Helper.MsgType, MsgType);
            HttpContext.Session.SetString(Helper.Title, Title);
            HttpContext.Session.SetString(Helper.Msg, Msg);
        }

        public IActionResult Details(int id) //Read
        {
            Fund item = _Repo.GetItem(id);
            ViewBag.AccHeadeerlist = GetAccounts();
            return View(item);
        }

        private List<SelectListItem> GetAccounts()
        {
            List<SelectListItem> lstAccount = _context.AccountingManuals.Where(n => n.ParentAccNumber== "111" && n.AccType=="فرعي" ).OrderBy(n => n.AccNumber).Select(n =>
                new SelectListItem()
                {
                    Value = n.AccNumber.ToString(),
                    Text = n.ArabicAccName
                }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----إختر صندوقاً----"
            };


            lstAccount.Insert(0, defItem);

            return lstAccount;
        }
    }
}
