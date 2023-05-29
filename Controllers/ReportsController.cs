using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.Models.DB.Report;
using POS.Tools;
using POS.ViewModel;
using System.Data.SqlClient;
using System.Text;

namespace POS.Controllers
{
    [AllowAnonymous]
    public class ReportsController : Controller
    {
        private readonly IExpensVoucher _Repo;
        private readonly IAccountingManual _AccountingManualRepo;
        private readonly IFund _FundRepo;
        private readonly pay_recie_finRepository<MainJournalEntery> mainJourEnter_Repo;
        private readonly ICurrency _CurrencyRepo;
        private readonly IFiscalYear _fiscalYearRepo;
        private readonly IExchangeRate _exchangeRateRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly posDbContext _context;
        private readonly IAccountingManual Accounts_repo;

        public ReportsController(pay_recie_finRepository<MainJournalEntery> MainJourEnter_Repo, ICurrency currencyRepo, posDbContext context, IAccountingManual _Accounts_repo)
        {
         
            _context = context;
            this.Accounts_repo = _Accounts_repo;
            mainJourEnter_Repo = MainJourEnter_Repo;
            _CurrencyRepo =currencyRepo;
        }

        List<SpGetReport> sqlpp = new List<SpGetReport>();


        private List<SelectListItem> GetFundsRrport()
        {
            var lstfund = new List<SelectListItem>();


            List<Fund> fund = _context.Funds.Where(f=>f.FundStatus==0).ToList();
            lstfund = fund.Select(sp => new SelectListItem()
            {

                Value = sp.FundsId.ToString(),
                Text = sp.FundName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----أختر الصندوق----"
            };

            lstfund.Insert(0, defItem);

            return lstfund;
        }

        private List<SelectListItem> GetCurrencyRrport()
        {
            var lstcurrencies = new List<SelectListItem>();


            List<Currency> currencies = _context.Currencies.Where(c => c.CurrStatus==0).ToList();
            lstcurrencies = currencies.Select(sp => new SelectListItem()
            {

                Value = sp.CurrenciesId.ToString(),
                Text = sp.CurrenName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----أختر العملة----"
            };

            lstcurrencies.Insert(0, defItem);

            return lstcurrencies;
        }


        private List<SelectListItem> GetExNumber()
        {
            var lstExpens = new List<SelectListItem>();


            IList<MainExpensVoucher> Expens = _context.MainExpensVouchers.Where(x => x.IsDelete == 0).ToList();
            lstExpens = Expens.Select(sp => new SelectListItem()
            {
                Value = sp.MainExpensVoucherNumber,
                Text = sp.MainExpensVoucherNumber
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----أختر رقم السند----"
            };

            lstExpens.Insert(0, defItem);

            return lstExpens;
        }




        public IActionResult ViewReportEx()
        {
            //ViewBag.MainExpensVouchers = _context.MainExpensVouchers.ToList();
            ViewBag.FundList = GetFundsRrport();
            ViewBag.CurrencyList = GetCurrencyRrport();
            ViewBag.ExList = GetExNumber();


            return View();
        }

        public IActionResult GetReportEx(DateTime StartDate, DateTime EndDate, string MainExpensVoucherNumber
            , string CurrenName, string FundName, int MainExpensVoucherStatus/*, int IsDelete*/)
        {
            string Id = "";
            string Currenyname = "";
            string Fundnames = "";

            if (MainExpensVoucherNumber != null && MainExpensVoucherNumber != ""
                || CurrenName != null && CurrenName != "" || FundName != null && FundName != "")
                Id = $"and Main_Expens_Voucher.Main_ExpensVoucher_Number={MainExpensVoucherNumber}";
            Currenyname = $"and Currencies.CurrenName={CurrenName}";
            Fundnames = $"and Funds.FundName={FundName}";



            var SpGetData = _context.SpGetReport
                       .FromSqlRaw("SpGetReport {0},{1},{2},{3},{4},{5}", StartDate, EndDate, MainExpensVoucherNumber, CurrenName, FundName, MainExpensVoucherStatus /* IsDelete*/).ToList();
            ViewBag.FundList = GetFundsRrport();
            ViewBag.CurrencyList = GetCurrencyRrport();
            ViewBag.ExList = GetExNumber();

            return View("ViewReportEx", SpGetData);


        }

        private List<SelectListItem> GetPyNumber()
        {
            var lstPay = new List<SelectListItem>();


            List<MainPayCheck> Pay =_context.MainPayChecks.Where(x => x.IsDelete==0).ToList();
            lstPay = Pay.Select(sp => new SelectListItem()
            {
                Value = sp.MainPaycheckNumber,
                Text = sp.MainPaycheckNumber
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select The Number----"
            };

            lstPay.Insert(0, defItem);

            return lstPay;
        }

        List<SpGetReport2> sqlPy= new List<SpGetReport2>();
        public IActionResult ViewReportPy()
        {
            //ViewBag.MainExpensVouchers = _context.MainExpensVouchers.ToList();
            ViewBag.FundList = GetFundsRrport();
            ViewBag.CurrencyList = GetCurrencyRrport();
            ViewBag.PyList = GetPyNumber();


            return View();
        }

        public IActionResult GetReportPy(DateTime StartDate, DateTime EndDate, string MainPaycheckNumber
           , string CurrenName, string FundName, int MainPaycheckStatus/*, int IsDelete*/)
        {
            string Id = "";
            string Currenyname = "";
            string Fundnames = "";

            if (MainPaycheckNumber != null && MainPaycheckNumber != ""
                || CurrenName != null && CurrenName != "" || FundName != null && FundName != "")
                Id = $"and Main_PayCheck.MainPaycheckNumber={MainPaycheckNumber}";
            Currenyname = $"and Currencies.CurrenName={CurrenName}";
            Fundnames = $"and Funds.FundName={FundName}";



            var SpGetData = _context.SpGetReport2
                       .FromSqlRaw("SpGetReport2 {0},{1},{2},{3},{4},{5}", StartDate, EndDate, MainPaycheckNumber, CurrenName, FundName, MainPaycheckStatus /* IsDelete*/).ToList();
            ViewBag.FundList = GetFundsRrport();
            ViewBag.CurrencyList = GetCurrencyRrport();
            ViewBag.PyList = GetPyNumber();

            return View("ViewReportPy", SpGetData);


        }

        public IActionResult AccountingReport(string sortExpression = "", string SearchText = "0", int pg = 1, int pageSize = 50)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("number");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<AccountingManual> items = Accounts_repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


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
        private List<SelectListItem> GetAccounts()
        {
            List<SelectListItem> lstAccount = _context.AccountingManuals.Where(n => n.AccType == "رئيسي").OrderBy(n => n.AccNumber).Select(n =>
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

            var defIt = new SelectListItem()
            {
                Value = "0",
                Text = "#اب نفسة#"
            };


            lstAccount.Insert(1, defIt);
            return lstAccount;
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
        public ActionResult JournalEntReport()
        {
            var _MainjournalEntery = mainJourEnter_Repo.List();

            return View(_MainjournalEntery);
        }
        public ActionResult DailyJournalReport()
        {
            DateTime currentDate = DateTime.Now.Date; // Get the current date without the time

            var _MainjournalEntery = mainJourEnter_Repo.List()
            .Where(element => element.MainJournalDateTime.HasValue &&
                      element.MainJournalDateTime.Value.Date == currentDate)
                        .ToList();
            return View(_MainjournalEntery);
        }
        public ActionResult LosesProfits()
        {
            IEnumerable<FiscalYear> cachedData = DataCache.GetCachedData();
             bool FiscalYearIsOn = cachedData.Any(item => item.FiscalYearStatus == 1);
            if (FiscalYearIsOn)
            {
                ViewBag.FiscalYearStatus = false;
                ViewBag.Message = " لايمكن اجراء اي عملية اضافية  أو استعراض التقارير الختامية،السنة المالية يجب اغلاقها مسبقاً";
            }
            return View();
        }
        public ActionResult BalanceSheet()
        {
            IEnumerable<FiscalYear> cachedData = DataCache.GetCachedData();
            bool FiscalYearIsOn = cachedData.Any(item => item.FiscalYearStatus == 1);
            if (!FiscalYearIsOn)
            {
                ViewBag.FiscalYearStatus = false;
                ViewBag.Message = " لايمكن اجراء اي عملية اضافية  أو استعراض التقارير الختامية،السنة المالية يجب اغلاقها مسبقاً";
            }
            return View();
        }



    }
}
