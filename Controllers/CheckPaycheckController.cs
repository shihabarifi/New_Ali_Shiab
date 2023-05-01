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

namespace POS.Controllers
{
    [AllowAnonymous]
    public class CheckPaycheckController : Controller
    {
        private readonly ICheckPaycheck _Repo;
        private readonly IAccountingManual _AccountingManualRepo;
        private readonly IBank _BankRepo;
        private readonly ICurrency _CurrencyRepo;
        private readonly IExchangeRate _exchangeRateRepo;

        public CheckPaycheckController(ICheckPaycheck repo, IAccountingManual accountingManualRepo,
            IBank bankRepo, ICurrency currencyRepo, IExchangeRate exchangeRateRepo) // here the repository will be passed by the dependency injection.
        {
            _Repo = repo;
            _AccountingManualRepo = accountingManualRepo;
            _BankRepo = bankRepo;
            _CurrencyRepo = currencyRepo;
           _exchangeRateRepo = exchangeRateRepo;
        }
        public IActionResult Index(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("ExDate");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<CheckPaycheckVoucher> items = _Repo.GetItems(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;


            return View(items);
        }

        
        public IActionResult Chequelist(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("ExDate");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<CheckPaycheckVoucher> items = _Repo.GetItemscheques(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


            TempData["CurrentPage"] = pg;


            return View(items);
        }


        public IActionResult Cheque(string id)
        {
            CheckPaycheckVoucher item = _Repo.GetItem(id);

            ViewBag.AccountList = GetAccounts();
            ViewBag.BankList = GetBanks();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();
            TempData.Keep();
            return View(item);
        }

            [HttpPost]
        public IActionResult Cheque(CheckPaycheckVoucher item)
        {




            item.IsDelete = 0;
            item.DebittAmountRly = item.CreditAmountRly;
            item.DebittAmountUdo = item.CreditAmountUdo;
            item.CheckPayCheckCheques = 1;
            

            bool bolret = false;
            string errMessage = "";
            try
            {


                bolret = _Repo.Cheque(item);
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

                TempData["SuccessMessage"] = "" + item.CheckPaycheckVoucherNumber + " Chequed Successfully";
                return RedirectToAction(nameof(Index));
            }
        }



        public IActionResult Stagelist(string sortExpression = "", string SearchText = "", int pg = 1, int pageSize = 5)
        {
            SortModel sortModel = new SortModel();
            sortModel.AddColumn("name");
            sortModel.AddColumn("ExDate");
            sortModel.ApplySort(sortExpression);
            ViewData["sortModel"] = sortModel;

            ViewBag.SearchText = SearchText;

            PaginatedList<CheckPaycheckVoucher> items = _Repo.GetItemsStage(sortModel.SortedProperty, sortModel.SortedOrder, SearchText, pg, pageSize);


            var pager = new PagerModel(items.TotalRecords, pg, pageSize);
            pager.SortExpression = sortExpression;
            this.ViewBag.Pager = pager;


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

                string bolret = _Procedures.ChpyStages(No);

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
            CheckPaycheckVoucher item = new CheckPaycheckVoucher();

    
            ViewBag.AccountList = GetAccounts();
            ViewBag.BankList = GetBanks();
            item.CheckPaycheckVoucherNumber = _Repo.GetNewEXNumber();
            item.FiscalYear =7;
            item.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
            item.CheckStatus = 0;
            item.ChequesType = "يدوي";
            item.CheckPayCheckCheques = 0;


   

            return View(item);
        }

        [HttpPost]
        public IActionResult Create(CheckPaycheckVoucher item)
        {
            
            bool bolret = false;
            string errMessage = "";
            try
            {
                item.IsDelete = 0;
                item.DebittAmountRly = item.CreditAmountRly;
                item.DebittAmountUdo = item.CreditAmountUdo;
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
                TempData["SuccessMessage"] = "" + item.CheckPaycheckVoucherNumber + " Created Successfully";
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpGet]
        public JsonResult GetAcc(int BankId)
        {
            Procedures _Procedures = new Procedures();
            List<Currency> Lcurr = new List<Currency>();
            Lcurr = _Procedures.GetAccCurrByAccNumber(BankId);
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
            CheckPaycheckVoucher item = _Repo.GetItem(id);

           ViewBag.AccountList = GetAccounts();
            ViewBag.BankList = GetBanks();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();
           

            return View(item);
        }
        public IActionResult Delete(string id)
        {
            CheckPaycheckVoucher item = _Repo.GetItem(id);

            ViewBag.AccountList = GetAccounts();
            ViewBag.BankList = GetBanks();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();
            TempData.Keep();
            return View(item);
        }


        [HttpPost]
        public IActionResult Delete(CheckPaycheckVoucher item)
        {
            bool bolret = false;
            string errMessage = "";
            try
            {
                item.DebittAmountRly = item.CreditAmountRly;
                item.DebittAmountUdo = item.CreditAmountUdo;
                item.IsDelete = 1;
                bolret = _Repo.Delete(item);
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(item);

            }

            int currentPage = 1;
            if (TempData["CurrentPage"] != null)
                currentPage = (int)TempData["CurrentPage"];



            if (bolret == false)
            {
                errMessage = errMessage + "  " + _Repo.GetErrors();
                TempData["ErrorMessage"] = errMessage;
                ModelState.AddModelError("", errMessage);
                return View(item);
            }
            else
            {
                TempData["SuccessMessage"] = item.CheckPaycheckVoucherNumber + " Deleted Successfully";
                return RedirectToAction(nameof(Index), new { pg = currentPage });
            }

        }


        public IActionResult Edit(string id)
        {
            CheckPaycheckVoucher item = _Repo.GetItem(id);

            ViewBag.AccountList = GetAccounts();
            ViewBag.BankList = GetBanks();
            ViewBag.CurrencyList = GetCurrency();
            ViewBag.ExchangeRatelist = GetExchangeCurrency();



            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(CheckPaycheckVoucher item)
        {
            item.IsDelete = 0;
            item.DebittAmountRly = item.CreditAmountRly;
            item.DebittAmountUdo = item.CreditAmountUdo;
           

            bool bolret = false;
            string errMessage = "";
            try
            {


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

                TempData["SuccessMessage"] = "" + item.CheckPaycheckVoucherNumber + " Modified Successfully";
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
                Text = "----Select Account----"
            };

            lstAccount.Insert(0, defItem);

            return lstAccount;
        }


        private List<SelectListItem> GetBanks()
        {
            var lstfund = new List<SelectListItem>();


            PaginatedList<Bank> bank = _BankRepo.GetItems("Name", SortOrder.Ascending, "0", 1, 1000);
            lstfund = bank.Select(sp => new SelectListItem()
            {
                Value = sp.BankId.ToString(),
                Text = sp.BankName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Bank----"
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
