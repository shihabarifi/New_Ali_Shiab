using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.Tools;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

using System.Linq;

namespace POS.Controllers
{
    
    public class CurrencyController : Controller
    {

        private readonly ICurrency _Repo;
       

        public CurrencyController(ICurrency repo) // here the repository will be passed by the dependency injection.
        {
            _Repo = repo;
          
        }


        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<Currency> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;


            return View(items);
        }


        public IActionResult Create()
        {
            Currency item = new Currency();

            ViewBag.ExchangeCurrencyId = GetCurrencyList();

            return View(item);
        }

        [HttpPost]
        public IActionResult Create(Currency item)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
                item.CurrStatus = 0;
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
                TempData["SuccessMessage"] = "" + item.CurrenName + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult Edit(int id)
        {
            Currency item = _Repo.GetItem(id);
            ViewBag.ExchangeCurrencyId = GetCurrencyList();
            return View(item);
            
        }

        [HttpPost]
        public IActionResult Edit(Currency item)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

                bolret = _Repo.Edit(item);


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
                TempData["SuccessMessage"] = "" + item.CurrenName + " تم التعديل بنجاح";
                return RedirectToAction(nameof(Index));
            }
        }





        public IActionResult Delete(int id)
        {
            Currency item = _Repo.GetItem(id);
            
            return View(item);

        }

        [HttpPost]
        public IActionResult Delete(Currency item)
        {
            int status = item.CurrStatus == 0 ? 1 : 0;
            bool bolret = false;
            string errMessage = "";
            try
            {

                item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
                item.CurrStatus = status;

                bolret = _Repo.Delete(item);


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
                if (status == 1)
                {
                    TempData["SuccessMessage"] = "تم التوقيف " + item.CurrenName + "  بنجاح";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["SuccessMessage"] = "تم التنشيط" + item.CurrenName + "  بنجاح";
                    return RedirectToAction(nameof(Index));
                }
            }
        }

        public IActionResult Details(int id) //Read
        {
            Currency item = _Repo.GetItem(id);
            ViewBag.ExchangeCurrencyId = GetCurrencyList();
            return View(item);
        }

        private List<SelectListItem> GetCurrencyList()
        {
            var lstItems = new List<SelectListItem>();


            PaginatedList<Currency> items = _Repo.GetItems("CurrenName", SortOrder.Ascending, "", 1, 1000);
            lstItems = items.Select(ut => new SelectListItem()
            {
                Value = ut.CurrenciesId.ToString(),
                Text = ut.CurrenName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select  Currency----"
            };

            lstItems.Insert(0, defItem);

            return lstItems;
        }





    }
}
