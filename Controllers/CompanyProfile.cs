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
        public string RemoveWwwRoot(string path)
        {
            return path.Replace("wwwroot/", "");
        }
        // GET: CompanyProfile
        public ActionResult Index()
        {
            var ComapnyList= CompanyProfile_Repo.List().ToList();

            //foreach (var company in ComapnyList)
            //{
            //    if (company.CompanyIcon.ToString() != null)
            //    {
            //        company.CompanyIcon = RemoveWwwRoot(company.CompanyIcon.ToString());

            //    }
            //}
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
        public  IActionResult Create(CompanyProfile companyProfile, IFormFile companyIconFile)
        {
            

            try
            {
                if (companyIconFile != null)
                {
                    
                    //// Update the CompanyIcon property with the image path
                    //companyProfile.CompanyIcon = imagePath;
                    string fileName = $"{companyProfile.CompanyName}_{DateTime.Now.Ticks}{Path.GetExtension(companyIconFile.FileName)}";

                    // Set the directory path where the image will be saved
                    string directoryPath = Path.Combine("wwwroot", "assets", "images", "companyprofile");

                    // Create the directory if it doesn't exist
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Set the file path where the image will be saved
                    string imagePath = Path.Combine(directoryPath, fileName);

                    // Save the uploaded image to the specified path
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        companyIconFile.CopyTo(fileStream);
                    }

                    // Update the CompanyIcon property with the image path
                    companyProfile.CompanyIcon = imagePath;

                }
                CompanyProfile_Repo.Add(companyProfile);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(companyProfile);
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
        public ActionResult Edit(CompanyProfile companyProfile, IFormFile companyIconFile)
        {
            try
            {
                if (companyIconFile != null)
                {

                    //// Update the CompanyIcon property with the image path
                    //companyProfile.CompanyIcon = imagePath;
                    string fileName = $"{companyProfile.CompanyName}_{DateTime.Now.Ticks}{Path.GetExtension(companyIconFile.FileName)}";

                    // Set the directory path where the image will be saved
                    string directoryPath = Path.Combine("wwwroot", "assets", "images", "companyprofile");

                    // Create the directory if it doesn't exist
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Set the file path where the image will be saved
                    string imagePath = Path.Combine(directoryPath, fileName);

                    // Save the uploaded image to the specified path
                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        companyIconFile.CopyTo(fileStream);
                    }

                    // Update the CompanyIcon property with the image path
                    companyProfile.CompanyIcon = imagePath;

                }
                CompanyProfile_Repo.Update(companyProfile.CompanyProfileId, companyProfile);
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
        public ActionResult Delete(int id, IFormCollection formCol)
        {
            try
            {
                CompanyProfile_Repo.Delete(id); 
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
