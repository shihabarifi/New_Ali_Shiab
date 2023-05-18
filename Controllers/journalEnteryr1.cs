using POS.Models.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using POS.Repositories;
      
using POS.viewModels;
      

using POS.Interfaces;
using Microsoft.AspNetCore.Authorization;
using POS.Data;
using POS.Models;
/*using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
*/




namespace POS.Controllers
{
    [AllowAnonymous]
    public class journalEnteryr1 : Controller
    {
        private readonly pay_recie_finRepository<MainJournalEntery> MainJourEnter_Repo;
        private readonly pay_recie_finRepository<DetailedJournalEntery> DetailedJourEnter_Repo;
       // private readonly posDbContext Db = new posDbContext();

        private readonly pay_recie_finRepository<AccountingManual> AccountingManual_Repo;
        private readonly pay_recie_finRepository<FiscalYear> FiscalYear_Repo;
        private readonly pay_recie_finRepository<Currency> Currencies_Repo;
        private readonly pay_recie_finRepository<CurrenciesExchangeRate> CurrenciesExchangeRate_Repo;
        private readonly pay_recie_finRepository<JournalEnterieType> JournalEnterieType_Repo;
        private readonly pay_recie_finRepository<GeneralLedger> GeneralLedger_Repo;
        private readonly AccountingManualCurrens_Db_REpository accountsCurrinces_Repo;


        public journalEnteryr1(
            pay_recie_finRepository<MainJournalEntery> MainJourEnter_Repo,
            pay_recie_finRepository<AccountingManual> AccountingManual_Repo,
            pay_recie_finRepository<FiscalYear> FiscalYear_Repo,
            pay_recie_finRepository<Currency> Currencies_Repo,
            pay_recie_finRepository<CurrenciesExchangeRate> CurrenciesExchangeRate_Repo,
            
            pay_recie_finRepository<JournalEnterieType> JournalEnterieType_Repo,
            pay_recie_finRepository<DetailedJournalEntery> DetailedJourEnter_Repo,
            pay_recie_finRepository<GeneralLedger> GeneralLedger_Repo,
            AccountingManualCurrens_Db_REpository accountsCurrinces_Repo
            )
        {
            this.MainJourEnter_Repo = MainJourEnter_Repo;
            this.AccountingManual_Repo = AccountingManual_Repo;
            this.FiscalYear_Repo = FiscalYear_Repo;
            this.Currencies_Repo = Currencies_Repo;
            this.CurrenciesExchangeRate_Repo = CurrenciesExchangeRate_Repo;
           
            this.JournalEnterieType_Repo = JournalEnterieType_Repo;
            this.DetailedJourEnter_Repo = DetailedJourEnter_Repo;
            this.GeneralLedger_Repo = GeneralLedger_Repo;
            this.accountsCurrinces_Repo = accountsCurrinces_Repo;








        }

        // GET: journalEnteryr1
        public ActionResult Index()
        {
            var _MainjournalEntery = MainJourEnter_Repo.List();

            return View(_MainjournalEntery);
        }

        // GET: journalEnteryr1/Details/5
        public ActionResult Details(int id)
        {
            var _MainjournalEntery = MainJourEnter_Repo.Find(id);
            return View(_MainjournalEntery);

        }

        // GET: journalEnteryr1/Create
        public ActionResult Create()
        {
            IEnumerable<FiscalYear> cachedData = DataCache.GetCachedData();
            Console.WriteLine("the cached data is : " + cachedData);
            //string journalEnteryNumber = GetJournalEnteryAutoNumber();
            // var CurrRateList=CurrenciesExchangeRate_Repo.List().ToList();
            bool FiscalYearIsOn = cachedData.Any(item => item.FiscalYearStatus == 1);
            if (!FiscalYearIsOn)
            {
                ViewBag.FiscalYearStatus = false;
                ViewBag.Message = " لايمكن اجراء اي عملية اضافية ،السنة المالية تم اغلاقها مسبقاً";
            }
            MainJournalEntery mainJournalEntery = new MainJournalEntery();

            mainJournalEntery.MainJouralEntNumber = GetJournalEnteryAutoNumber();
            mainJournalEntery.MainJournalDateTime = DateTime.Now;
            // mainJournalEntery.SystemUsers = mainJournalEntery.SystemUsers != 0 ? mainJournalEntery.SystemUsers : 1;
            mainJournalEntery.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
            mainJournalEntery.IsStage = 0;
            mainJournalEntery.IsDeleted = 0;

            mainJournalEntery.DetailedJournalEnteries.Add(new DetailedJournalEntery()
            {
                CurrenciesExchangeRate = 1,
            });

            ViewBag.FiscalYearList = FiscalYear_Repo.List().ToList();
            ViewBag.JournalEnterieTypesList = JournalEnterieType_Repo.List().ToList();
            //ViewBag.SystemUsersList = SystemUser_Repo.List().ToList();
            //ViewBag.MainJournalEnteries = GetJournalEnteryAutoNumber();
            ViewBag.CreditChildAccountList = AccountingManual_Repo.List("فرعي").ToList();
            /* var option = new JsonSerializerSettings
             {
                 PreserveReferencesHandling = PreserveReferencesHandling.None

             };*/
            // ViewBag.CurrenciesExchangeRateList = Json(CurrenciesExchangeRate_Repo.List().ToList());
            // var CurrRateList = CurrenciesExchangeRate_Repo.List().ToList();
            // var tempCurrExchangeList = JsonConvert.SerializeObject(CurrenciesExchangeRate_Repo.List().ToList(), new JsonSerializerSettings {ReferenceLoopHandling=ReferenceLoopHandling.Ignore });
            //  ViewBag.CurrenciesExchangeRateList= tempCurrExchangeList;
            // ViewBag.DebitChildAccountList = JsonConvert.SerializeObject(AccountingManual_Repo.List("فرعي").ToList().ToString(), new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            ViewBag.CurrenciesList = SelectingCurrenFirstItem();

            return View(mainJournalEntery);
        }


        // POST: journalEnteryr1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MainJournalEntery mainJournalEntery)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    
                    mainJournalEntery.FiscalYear = 7;
                    mainJournalEntery.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";
                    mainJournalEntery.IsDeleted = 0;
                    mainJournalEntery.IsStage= 0;
                    //mainJournalEntery.SystemUsers = mainJournalEntery.SystemUsers != 0 ? mainJournalEntery.SystemUsers : 1;
                    mainJournalEntery.MainournalEnteriesStatus = 0;
                    foreach(var i in mainJournalEntery.DetailedJournalEnteries)
                    {
                        if(i.CreditAmountRly>0|| i.CreditAmountUdo>0||i.DebittAmountRly > 0 || i.DebittAmountUdo > 0)
                        {
                          ///nothing to write  
                        }
                        else
                        {
                         mainJournalEntery.DetailedJournalEnteries.Remove(i);
                        }
                    }
                    MainJourEnter_Repo.Add(mainJournalEntery);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(mainJournalEntery);
                }
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
        
        [HttpGet("journalstage")]
        //GET: journalEnteryr1/JournalStage/
        public ActionResult JournalStage()
        {
            var JournalEnteryListViewModel = new JournalEnteryViewModel()
            {
                MainJournalEnteries = MainJourEnter_Repo.List().Where(x => x.IsStage == 0).ToList(),

            };
            return View(JournalEnteryListViewModel);
        }
        // POST: journalEnteryr1/JournalStage
        [HttpPost("journalstage")]
        [ValidateAntiForgeryToken]
        public ActionResult JournalStage(JournalEnteryViewModel journalEnteryViewModel)
        {
            try
            {
                for (int i = 0; i < journalEnteryViewModel.MainJournalEnteries.Count; i++)
                {
                    if (journalEnteryViewModel.MainJournalEnteriesIsStage[i] == true)
                    {
                        journalEnteryViewModel.MainJournalEnteries[i].IsStage = 1;

                        foreach (var j in journalEnteryViewModel.MainJournalEnteries[i].DetailedJournalEnteries)
                        {
                            var GeneralLedgerModel = new GeneralLedger()
                            {

                                MainJournalEnteriesId = j.MainJournalEnteries,
                                GenLedgerDateTime = DateTime.Now,
                                SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f",
                                TransactionIsStage = 1,
                                Currencies = j.Currencies,
                                AccountingManual = j.CreditChildAccount,
                                CurrenciesExchangeRate = (int)j.CurrenciesExchangeRate,
                                FiscalYear = journalEnteryViewModel.MainJournalEnteries[i].FiscalYear,
                                TransactionName = "قيد يومي",
                                DebittAmountRly = j.DebittAmountRly,
                                CreditAmountRly = j.CreditAmountRly,
                                DebitAmountWithTransCurre = j.DebittAmountUdo > 0 ? j.DebittAmountUdo : j.DebittAmountRly,
                                CreditAmountWithTransCurre = j.CreditAmountUdo > 0 ? j.CreditAmountUdo : j.CreditAmountRly,
                            };

                            GeneralLedger_Repo.Add(GeneralLedgerModel);
                        }
                        MainJourEnter_Repo.Update(journalEnteryViewModel.MainJournalEnteries[i].MainJournalEnteriesId, journalEnteryViewModel.MainJournalEnteries[i]);
                    }
                    else
                    {
                        journalEnteryViewModel.MainJournalEnteries[i].IsStage = 0;

                    }
                }
                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                return View(e);
            }

        }
        [HttpGet("journaAllstaged")]
        //GET: journalEnteryr1/JournalStage/
        public ActionResult JournaAllStaged()
        {
            var JournalEnteryListViewModel = new JournalEnteryViewModel()
            {
                MainJournalEnteries = MainJourEnter_Repo.List().Where(x => x.IsStage == 1).ToList(),


            };
            return View(JournalEnteryListViewModel);
        }
        // POST: journalEnteryr1/JournalStage
        [HttpPost("journaAllstaged")]
        [ValidateAntiForgeryToken]
        public ActionResult JournaAllStaged(JournalEnteryViewModel journalEnteryViewModel)
        {
            try
            {
                for (int i = 0; i < journalEnteryViewModel.MainJournalEnteries.Count; i++)
                {
                    if (journalEnteryViewModel.MainJournalEnteriesIsStage[i] == true)
                    {
                        journalEnteryViewModel.MainJournalEnteries[i].IsStage = 0;

                        foreach (var j in journalEnteryViewModel.MainJournalEnteries[i].DetailedJournalEnteries)
                        {

                            var GeneralLedgerModel = new GeneralLedger()
                            {

                                MainJournalEnteriesId = j.MainJournalEnteries,
                                // GenLedgerDateTime = DateTime.Now,
                                // SystemUsers = 1,
                                TransactionIsStage = 0,
                                //Currencies = j.Currencies,

                                AccountingManual = j.CreditChildAccount,
                                //CurrenciesExchangeRate = j.CurrenciesExchangeRate,
                                //FiscalYear = journalEnteryViewModel.MainJournalEnteries[i].FiscalYear,
                                // TransactionName = "قيد يومي",
                                //DebittAmountRly = j.DebittAmountRly,
                                // CreditAmountRly = j.CreditAmountRly,
                                //DebitAmountWithTransCurre = j.DebittAmountUdo > 0 ? j.DebittAmountUdo : j.DebittAmountRly,
                                //CreditAmountWithTransCurre = j.CreditAmountUdo > 0 ? j.CreditAmountUdo : j.CreditAmountRly,


                            };

                            GeneralLedger_Repo.Update((int)j.MainJournalEnteries, GeneralLedgerModel);

                        }
                        MainJourEnter_Repo.Update(journalEnteryViewModel.MainJournalEnteries[i].MainJournalEnteriesId, journalEnteryViewModel.MainJournalEnteries[i]);

                    }

                }
                return RedirectToAction(nameof(Index));
            }

            catch (Exception e)
            {
                return View(e);
            }
            // return View();
        }
        // GET: journalEnteryr1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: journalEnteryr1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: journalEnteryr1/Delete/5
        public ActionResult Delete(int id)
        {
            var _MainjournalEntery = MainJourEnter_Repo.Find(id);
            return View(_MainjournalEntery);

        }

        // POST: journalEnteryr1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MainJournalEntery mainJournalEntery)
        {
            try
            {
                mainJournalEntery.IsDeleted = 1;
                MainJourEnter_Repo.Update(id, mainJournalEntery);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public string GetJournalEnteryAutoNumber()
        {

            IList<MainJournalEntery> entries = MainJourEnter_Repo.List();
            if (entries == null || entries.Count == 0)
            {
                return 1.ToString();
            }
            else
            {
                var journalEnteryAutoNumber = int.Parse(entries.Max(x => x.MainJouralEntNumber)) + 1;
                return journalEnteryAutoNumber.ToString();
            }



        }
        public List<Currency> SelectingCurrenFirstItem()
        {
            var Currencies = Currencies_Repo.List().ToList();
            Currencies.Insert(0, new Currency { CurrenciesId = -1, CurrenName = "----- أختر عملة ------ " });
            return Currencies;

        }
        /*[HttpGet]
        public JsonResult GeturrExchange()
        {

            return Json(CurrenciesExchangeRate_Repo.List().ToList());
        }*/
        [HttpGet]
        public IActionResult GeturrExchange()
        {
            var content = new ContentResult();
            content.Content = JsonConvert.SerializeObject(CurrenciesExchangeRate_Repo.List().ToList(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            content.ContentType = "application/json";
            return content;
        }
        [HttpGet]
        public IActionResult GetDibitAccount()
        {
            var content = new ContentResult();
            content.Content = JsonConvert.SerializeObject(AccountingManual_Repo.List().ToList(), new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            content.ContentType = "application/json";
            return content;



        }

        [HttpGet]
        public JsonResult FetchAccountCurrs(string AccountNo)
        {
          
           var AccountsCurrenciesList = new List<AccountsCurrency>();
            var CurrenciesList = new List<Currency>();
            AccountsCurrenciesList = accountsCurrinces_Repo.AccountsCurrList(AccountNo).ToList();
           
            for(int i = 0; i < AccountsCurrenciesList.Count; i++)
            {
                var curr = new Currency()
                {
                    CurrenciesId = AccountsCurrenciesList[i].Currencies,
                    CurrenName = AccountsCurrenciesList[i].CurrenciesNavigation.CurrenName
                };
                CurrenciesList.Add(curr);
              
            } 

            return Json(new SelectList(CurrenciesList.ToList(), "CurrenciesId","CurrenName"));

        }
        public IActionResult ViewRep()
        {
            return View();
        }
        

    }
}
