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
using POS.Data;
using POS.Models.DB.Report;
using Microsoft.EntityFrameworkCore;

namespace POS.Controllers
{
    [AllowAnonymous]
    public class ExpensVoucherController : Controller
    {
        private readonly IExpensVoucher _Repo;
        private readonly IAccountingManual _AccountingManualRepo;
        private readonly IFund _FundRepo;
        private readonly ICurrency _CurrencyRepo;
        private readonly IFiscalYear _fiscalYearRepo;
        private readonly IExchangeRate _exchangeRateRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly posDbContext _context;

        public ExpensVoucherController(IExpensVoucher repo, IAccountingManual accountingManualRepo,
            IFund fundRepo, ICurrency currencyRepo, IFiscalYear fiscalYearRepo, 
            IExchangeRate exchangeRateRepo,UserManager<ApplicationUser> userManager,posDbContext context) // here the repository will be passed by the dependency injection.
        {
            _Repo = repo;
            _AccountingManualRepo = accountingManualRepo;
            _FundRepo = fundRepo;
            _CurrencyRepo = currencyRepo;
           _fiscalYearRepo = fiscalYearRepo;
            _exchangeRateRepo = exchangeRateRepo;
           _userManager = userManager;
            _context = context;
        }

        List<SpGetReport> sqlpp = new List<SpGetReport>();

        public IActionResult Index()
        {


            IList<MainExpensVoucher> items = _Repo.GetItems();

            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();

           


            return View(items);
        }




        public IActionResult Index2()
        {
           

            IList<MainExpensVoucher> items = _Repo.GetItems();


          

            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();

         


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

            IList<MainExpensVoucher> items = _Repo.GetItemsStage();

            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();


            return View(items);
        }

        [HttpPost]
        public IActionResult Stagelist(string No)
        {
               Procedures _Procedures = new Procedures();
          
            string errMessage = "";
            try
            {
               
              string  bolret = _Procedures.Stages(No);

                TempData["SuccessMessage"] = "" + No + " تم الترحيل بنجاح";
                return RedirectToAction(nameof(Stagelist));
            }
            catch (Exception ex)
            {
                errMessage = errMessage + " " + ex.Message; 
                return RedirectToAction(nameof(Stagelist));
            }
           
        }
            public IActionResult Create()
        {
            MainExpensVoucher item = new MainExpensVoucher();

            item.DetailedExpensVouchers.Add(new DetailedExpensVoucher() { DetailedExpensVoucherId = 1 });
            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            item.MainExpensVoucherNumber = _Repo.GetNewEXNumber();
            var f = _fiscalYearRepo.GetItem(1);
            item.FiscalYear = f.FiscalYearId;
            item.SystemUsers = _userManager.GetUserId(User);
            item.MainExpensVoucherStatus = 0;
            item.CurrenciesExchangeRate = 1;
            return View(item);
        }

        [HttpPost]
        public IActionResult Create(MainExpensVoucher item)
        {
            item.DetailedExpensVouchers.RemoveAll(a => a.DetailedExpensVoucherAmountRly == 0);
            //item.DetailedExpensVouchers.RemoveAll(d => d.IsDeleted == true);

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

                TempData["SuccessMessage"] = "" + item.MainExpensVoucherNumber + " Created Successfully";
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

        }


        public IActionResult Details(string id) //Read
        {
            MainExpensVoucher item = _Repo.GetItem(id);

            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();

            ViewBag.ExchangeRatelist = GetExchangeCurrency();

            return View(item);
        }
        public IActionResult Delete(string id)
        {
            MainExpensVoucher item = _Repo.GetItem(id);

            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();
            TempData.Keep();
            return View(item);
        }


        [HttpPost]
        public IActionResult Delete(MainExpensVoucher item)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                item.IsDelete = 1;
                bolret = _Repo.Delete(item);
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
                TempData["SuccessMessage"] = "" + item.MainExpensVoucherNumber + " Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            //else
            //{
            //    TempData["SuccessMessage"] = item.MainExpensVoucherNumber + " Deleted Successfully";
            //    return RedirectToAction(nameof(Index), new { pg = currentPage });
            //}

        }

        public IActionResult Edit(string id)
        {
            MainExpensVoucher item = _Repo.GetItem(id);

            ViewBag.AccountList = GetAccounts();
            ViewBag.FundList = GetFunds();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();



            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(MainExpensVoucher item)
        {
          

            item.DetailedExpensVouchers.RemoveAll(a => a.DetailedExpensVoucherAmountRly == 0);
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
                TempData["SuccessMessage"] = "" + item.MainExpensVoucherNumber + " Modified Successfully";
                return RedirectToAction(nameof(Index));
            }
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
                Text = "----Select Account----"
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

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Currency----"
            };

            lstfund.Insert(0, defItem);

            return lstfund;
        }



        //private List<SelectListItem> GetExchange()
        //{
        //    var lstfund = new List<SelectListItem>();


        //    PaginatedList<CurrenciesExchangeRate> fund = .GetItems("Name", SortOrder.Ascending, "", 1, 1000);
        //    lstfund = fund.Select(sp => new SelectListItem()
        //    {
        //        Value = sp.CurrenciesId.ToString(),
        //        Text = sp.CurrenName
        //    }).ToList();

        //    var defItem = new SelectListItem()
        //    {
        //        Value = "",
        //        Text = "----Select Currency----"
        //    };

        //    lstfund.Insert(0, defItem);

        //    return lstfund;
        //}


        //private List<SelectListItem> GetPoCurrency()
        //{
        //    var lstCurrency = new List<SelectListItem>();


        //    PaginatedList<Currency> supplier = _CurrencyRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
        //    lstCurrency = supplier.Select(sp => new SelectListItem()
        //    {
        //        Value = sp.Id.ToString(),
        //        Text = sp.Name
        //    }).ToList();

        //    var defItem = new SelectListItem()
        //    {
        //        Value = "",
        //        Text = "----Select PoCurrencies----"
        //    };

        //    lstCurrency.Insert(0, defItem);

        //    return lstCurrency;
        //}

        //private List<SelectListItem> GetBaseCurrency()
        //{
        //    var lstCurrency = new List<SelectListItem>();


        //    PaginatedList<Currency> supplier = _CurrencyRepo.GetItems("Name", SortOrder.Ascending, "YEM", 1, 1000);
        //    lstCurrency = supplier.Select(sp => new SelectListItem()
        //    {
        //        Value = sp.Id.ToString(),
        //        Text = sp.Name
        //    }).ToList();

        //    var defItem = new SelectListItem()
        //    {
        //        Value = "",
        //        Text = "----Select Base Currencies----"
        //    };

        //    lstCurrency.Insert(0, defItem);

        //    return lstCurrency;
        //}



        //private List<SelectListItem> GetExchangeRate()
        //{

        //    var lstCurrencies = new List<SelectListItem>();

        //    PaginatedList<Currency> currencies = _CurrencyRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
        //    lstCurrencies = currencies.Select(sp => new SelectListItem()
        //    {
        //        Value = sp.Id.ToString(),
        //        Text = sp.EchangeRate.ToString()
        //    }).ToList();


        //    return lstCurrencies;
        //}


        //private List<SelectListItem> GetUnitNames()
        //{
        //    var lstProducts = new List<SelectListItem>();


        //    PaginatedList<Product> product = _ProductRepo.GetItems("Name", SortOrder.Ascending, "", 1, 1000);
        //    lstProducts = product.Select(ut => new SelectListItem()
        //    {
        //        Value = ut.Code.ToString(),
        //        Text = ut.Units.Name
        //    }).ToList();

        //    var defItem = new SelectListItem()
        //    {
        //        Value = "",
        //        Text = "----Select Unit----"
        //    };

        //    lstProducts.Insert(0, defItem);

        //    return lstProducts;
        //}

    }
}
