using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Interfaces;
using POS.Models;
using POS.Models.DB;

namespace POS.Controllers
{
    public class CompanyProfileController : Controller
    {
        private readonly pay_recie_finRepository<CompanyProfile> CompanyProfile_Repo;

        public CompanyProfileController(pay_recie_finRepository<CompanyProfile> _CompanyProfile_Repo)
        {
            CompanyProfile_Repo = _CompanyProfile_Repo;
        }
        // GET: CompanyProfile
        public ActionResult Index()
        {
            var ComapnyList= CompanyProfile_Repo.List().ToList();
            return View(ComapnyList);
        }

        // GET: CompanyProfile/Details/5
        public ActionResult Details(int id)
        {
            var singleCompany = CompanyProfile_Repo.Find(id);
            return View(singleCompany);
        }

        // GET: CompanyProfile/Create
        public ActionResult Create()
        {
            var singleCompany = new CompanyProfile();
            return View(singleCompany);
        }

        // POST: CompanyProfile/Create
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

        // GET: CompanyProfile/Edit/5
        public ActionResult Edit(int id)
        {
            var SingleCompany= CompanyProfile_Repo.Find(id);
            return View(SingleCompany);
        }

        // POST: CompanyProfile/Edit/5
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

        // GET: CompanyProfile/Delete/5
        public ActionResult Delete(int id)
        {
            var SingleCompany = CompanyProfile_Repo.Find(id);
            return View(SingleCompany);
        }

        // POST: CompanyProfile/Delete/5
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
