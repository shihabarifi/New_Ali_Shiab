using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Interfaces;
using POS.Models.DB;

namespace POS.Controllers
{
    public class FinalAccounts : Controller
    {
        private readonly pay_recie_finRepository<FinalAccountType> finalAccount_Repo;

        public FinalAccounts(pay_recie_finRepository<FinalAccountType> finalAccount_Repo)
        {
            this.finalAccount_Repo = finalAccount_Repo;
        }
        // GET: FinalAccounts
        public ActionResult Index()
        {/// final accounts controller
            var FinalAccountList= finalAccount_Repo.List().ToList();
            return View(FinalAccountList);
        }

        // GET: FinalAccounts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FinalAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinalAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: FinalAccounts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FinalAccounts/Edit/5
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

        // GET: FinalAccounts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FinalAccounts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
