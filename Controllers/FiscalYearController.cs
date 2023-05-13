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
    [AllowAnonymous]
    public class FiscalYearController : Controller
    {
        private readonly IFiscalYear _Repo;
        private readonly posDbContext _context;

        public FiscalYearController(IFiscalYear repo, posDbContext context) // here the repository will be passed by the dependency injection.
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

            PaginatedList<FiscalYear> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;

           
            return View(items);
        }


        public IActionResult Create()
        {
            FiscalYear item = new FiscalYear();

            
            return View(item);
        }

        [HttpPost]
        public IActionResult Create(FiscalYear item)
        {
            item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
           
            item.FiscalYearStatus = 1;

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
                TempData["SuccessMessage"] = "تم الإضافة " + item.FiscalYearName + "  بنجاح";
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Edit(int id)
        {
            FiscalYear fiscalYear = _Repo.GetItem(id);
            
            return View(fiscalYear);

        }

        [HttpPost]
        public IActionResult Edit(FiscalYear fiscalYear)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {


                fiscalYear.FiscalYearStatus = 0;
                fiscalYear.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

                bolret = _Repo.Edit(fiscalYear);


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
                return View(fiscalYear);
            }
            else
            {
                TempData["SuccessMessage"] = "" + fiscalYear.FiscalYearName + " تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Delete(int id)
        {
            FiscalYear fiscalYear= _Repo.GetItem(id);
            
            return View(fiscalYear);

        }

        [HttpPost]
        public IActionResult Delete(FiscalYear fiscalYear)
        {

            bool bolret = false;
            string errMessage = "";
            try
            {

                if(fiscalYear.FiscalYearStatus == 0 || fiscalYear ==null )
                {
                 fiscalYear.FiscalYearStatus=1;
                }
                else
                {
                    fiscalYear.FiscalYearStatus = 0;
                }
               // fiscalYear.FiscalYearStatus = fiscalYear.FiscalYearStatus == 1 ? 0 : 1;
                fiscalYear.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

                bolret = _Repo.Edit(fiscalYear);


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
                return View(fiscalYear);
            }
            else
            {
                TempData["SuccessMessage"] = "" + fiscalYear.FiscalYearName + " تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));
            }


        }




        public IActionResult Details(int id) //Read
        {
            FiscalYear item = _Repo.GetItem(id);
           
            return View(item);
        }
    }
}
