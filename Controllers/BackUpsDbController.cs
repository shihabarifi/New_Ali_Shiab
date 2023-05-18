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
            var backupin = new BackUpsDb();
            backupin.BackupId = 1;
            backupin.Filename = "AliAbackUp";
            backupin.StampDate = DateTime.Now;
            var BackUpsList=backUpsDb_Repo.List().ToList();
            BackUpsList.Add(backupin);

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


        public IActionResult BackupDatabase(BackUpsDb backUpsDb)
    {
        string connectionString = "Data Source=DESKTOP-5LD4310\\MSSQLSERVER2;Initial Catalog=Fin;Integrated Security=True";
        string backupFilename = $"backup_{DateTime.Now.ToString("yyyyMMddHHmmss")}.bak";
        string backupQuery = $"BACKUP DATABASE Fin TO DISK = N'{backupFilename}'";
            // string system_users
        string SystemUsers = "6f94621c-3508-435c-98fe-c51cc63d076f";

            using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(backupQuery, connection))
            {
                command.ExecuteNonQuery();
            }
                DateTime backupDateTime = DateTime.Now;
                string insertQuery = $"INSERT INTO [dbo].[BackUpsDb] ([Filename], [system_users],[StampDate]) VALUES ('{backupFilename}','{SystemUsers}', '{backupDateTime.ToShortDateString()}')";


                //string insertQuery = $"INSERT INTO [dbo].[BackUpsDb] ([Filename]) VALUES ('{backupFilename}')";

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
            var SingleBackUp = backUpsDb_Repo.Find(id);

            return View(SingleBackUp);
        }
        public IActionResult DeleteBackup(string backUpDb)//string backupFilename
        {
            string connectionString = "Data Source=DESKTOP-5LD4310\\MSSQLSERVER2;Initial Catalog=Fin;Integrated Security=True";
            string deleteQuery = $"DELETE FROM [dbo].[BackUpsDb] WHERE [Filename] = '{backUpDb}'";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string backupPath = "C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER2\\MSSQL\\Backup\\" + backUpDb;
                    if (System.IO.File.Exists(backupPath))
                    {
                        System.IO.File.Delete(backupPath);
                    }


                    using (var command = new SqlCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }


        // POST: BackUpsDbController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BackUpsDb backUpsDb )
        {
            try
            {
                string backupPath = "C:\\Program Files\\Microsoft SQL Server\\MSSQL15.MSSQLSERVER2\\MSSQL\\Backup\\" + backUpsDb.Filename;
                if (System.IO.File.Exists(backupPath))
                {
                    System.IO.File.Delete(backupPath);
                }
                //backUpsDb_Repo.Delete(backUpsDb);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
