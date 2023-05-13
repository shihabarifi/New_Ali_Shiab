using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Interfaces;
using POS.Models.DB;
using System.Data.SqlClient;

namespace POS.Controllers
{
    public class BackUpsDbController : Controller
    {
        private readonly pay_recie_finRepository<BackUpsDb> backUpsDb_Repo;

        public BackUpsDbController(pay_recie_finRepository<BackUpsDb> BackUpsDb_Repo)
        {
            backUpsDb_Repo = BackUpsDb_Repo;
        }
        // GET: BackUpsDbController
        public ActionResult Index()
        {
            var BackUpsList=backUpsDb_Repo.List().ToList();
            return View(BackUpsList);
        }

        // GET: BackUpsDbController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BackUpsDbController/Create
        public ActionResult Create()
        {
            var BackUpObject = new BackUpsDb();
            BackUpObject.StampDate = DateTime.Now;
            BackUpObject.SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

            
            return View(BackUpObject);
        }


public IActionResult BackupDatabase()
    {
        string connectionString = "Data Source=DESKTOP-5LD4310\\MSSQLSERVER2;Initial Catalog=Fin;Integrated Security=True";
        string backupFilename = $"backup_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bak";
        string backupQuery = $"BACKUP DATABASE Fin TO DISK = N'{backupFilename}'";

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(backupQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            string insertQuery = $"INSERT INTO [dbo].[Backups] ([Filename]) VALUES ('{backupFilename}')";

            using (var command = new SqlCommand(insertQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        return RedirectToAction(nameof(Index));
    }


public IActionResult RestoreDatabase(string backupFilename)
    {
            string connectionString = "Data Source=DESKTOP-5LD4310\\MSSQLSERVER2;Initial Catalog=Fin;Integrated Security=True";
            string restoreQuery = $"RESTORE DATABASE Fin FROM DISK = N'{backupFilename}' WITH REPLACE";

        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(restoreQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        return RedirectToAction(nameof(Index));
    }



    // POST: BackUpsDbController/Create
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

        // GET: BackUpsDbController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BackUpsDbController/Edit/5
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

        // GET: BackUpsDbController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BackUpsDbController/Delete/5
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
