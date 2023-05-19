using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace POS.Controllers
{

    public class CurrenciesExchangeRateController : Controller
    {
        private readonly ICurrenciesExchangeRate _Repo;

        public CurrenciesExchangeRateController(ICurrenciesExchangeRate repo)
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

            PaginatedList<CurrenciesExchangeRate> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;


            return View(items);
        }
    }
}
