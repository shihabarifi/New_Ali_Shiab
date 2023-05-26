using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Interfaces;
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
        private readonly ICurrency _CurrencyRepo;
        private readonly IFiscalYear _fiscalYearRepo;
        private readonly IExchangeRate _exchangeRateRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly posDbContext _context;
        public ReportsController( posDbContext context)
        {
         
            _context = context;
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



    }
}
