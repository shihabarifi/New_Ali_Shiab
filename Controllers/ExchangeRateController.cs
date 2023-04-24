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
    public class ExchangeRateController : Controller
    {

        private readonly IExchangeRate _Repo;
        private readonly ICurrency _CurrencyRepo;
        private readonly posDbContext _context;

        public ExchangeRateController(IExchangeRate repo, ICurrency currencyRepo, posDbContext context) // here the repository will be passed by the dependency injection.
        {
            _Repo = repo;
            _CurrencyRepo = currencyRepo;
            _context = context;
        }


        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("description");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<CurrenciesExchangeRate> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;
            ViewBag.CurrencyList = GetCurrency();

            return View(items);
        }


        public IActionResult Create()
        {
            CurrenciesExchangeRate item = new CurrenciesExchangeRate();


          
            ViewBag.CurrencyList = GetCurrency();


            return View(item);
        }

        [HttpPost]
        public IActionResult Create(CurrenciesExchangeRate item)
        {
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
                TempData["SuccessMessage"] = "" + item.CurreExchangeRate + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Details(int id) //Read
        {
            CurrenciesExchangeRate item = _Repo.GetItem(id);
          
            return View(item);
        }

        
        private List<SelectListItem> GetCurrency()
        {

            List<SelectListItem> lstAccount = _context.Currencies.Where(a => a.CurrStatus == 0).OrderBy(n => n.CrreChangeName).Select(n =>
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
    }

}
