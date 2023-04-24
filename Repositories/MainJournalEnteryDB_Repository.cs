using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using POS.Models.DB;

using POS.Interfaces;
using POS.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using POS.Data;

namespace POS.Repositories
{
    public class MainJournalEnteryDb_Repository : pay_recie_finRepository<MainJournalEntery>
    {
        private readonly posDbContext Db;
        private readonly ILogger<MainJournalEnteryDb_Repository> logger;
        // تم تعريفه لجعله المكان الوحيد لتعريف الجدول و الاعمدة التي تعتبر مفاتيح لجداول اجنبيه لتسهيل عمل التقارير
        //public static readonly Table Table = new("Main_Journal_Enteries", new List<string> { "fiscal_year", "journal_enterie_types" });
        public MainJournalEnteryDb_Repository(posDbContext _Db, ILogger<MainJournalEnteryDb_Repository> _logger)
        {
            Db = _Db;
            logger = _logger;
        }
        public void Add(MainJournalEntery entity)
        {
            try
            {
                Db.MainJournalEnteries.Add(entity);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                logger.LogError($"failed to  insert journal Enteries : {e}");

            }



        }

        public void Delete(int id)
        {
            var _JournalEntery = Find(id);
            Db.MainJournalEnteries.Remove(_JournalEntery);
            Db.SaveChanges();
        }


        // الدالة تقوم بتركيب باقي نص عملية الـ Select , على اساس الاعمدة و القيم الممرره
        //private string buildSearchQueries(Dictionary<string, int> columnsNameId)
        //{
        //    if (columnsNameId!= null && columnsNameId.Count !=0 )
        //    {
        //        string query = " ";
        //        List<string> searchQueries = new();
        //        int indexOfSelectedColumn = 0;
        //        int indexOfColumnName = 0;
                
        //        while (indexOfColumnName < columnsNameId.Count)
        //        {

        //            KeyValuePair<string, int> _column = columnsNameId.ElementAt(indexOfColumnName);
        //            if (_column.Value == -1)
        //            {
        //                indexOfColumnName++;
        //                continue;
        //            }
        //            while (indexOfSelectedColumn < Table.forigenColumnNames.Count)
        //            {
        //                if (Table.forigenColumnNames[indexOfSelectedColumn] == _column.Key)
        //                {
        //                    searchQueries.Add($" {_column.Key} = {_column.Value} ");
        //                    break;
        //                }
        //                indexOfSelectedColumn++;
        //            }
        //            indexOfSelectedColumn = 0;
        //            indexOfColumnName++;
        //        }

        //        if (searchQueries.Count == 0)
        //        {
        //            throw new Exception($"Specified forigen keys {String.Join(",",columnsNameId.Keys)} does not exist in [{Table.name}] table. ");
        //        }

        //        indexOfSelectedColumn = 0;
        //        while (indexOfSelectedColumn < searchQueries.Count)
        //        {
        //            if (indexOfSelectedColumn == 0)
        //            {
        //                query += $" {searchQueries[indexOfSelectedColumn]}";
        //            }
        //            else
        //            {
        //                query += $" AND {searchQueries[indexOfSelectedColumn]}";
        //            }
        //            indexOfSelectedColumn++;
        //        }

        //        return query;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
        // الدالة تقوم باخذ الصفوف من الجدول على اساس المعايير المحددة(اسماء الاعمدة و القيم) اذا كانت القيمة تساوي -1 فسيتم اهمال العمود في عملية تركيب نص البحث
        //public IList<MainJournalEntery> Filter(Dictionary<string, int> columnsNameId)
        //{
        //    String query = $"SELECT * FROM [Dbo].{Table.name}  ";
        //    try
        //    {

        //        if (columnsNameId != null && columnsNameId.Count != 0)
        //        {
        //            string searchQuery = this.buildSearchQueries(columnsNameId);
        //            if (searchQuery != null)
        //            {
        //                query += " WHERE " + searchQuery;
        //            }

        //        }
        //        return Db.MainJournalEnteries.FromSqlRaw(query).ToList();


        //    }
        //    catch (Exception e)
        //    {

        //        logger.LogError($"failed to get journal Enteries : {e}");
        //        return null;
        //    }

        //}
        // الدالة تقوم بأرجاع كل الصفوف التي تكون بين تاريخين محددين
        // بالاضافة الى امكانية اضافة معيار بحث اخر هو البحث على اساس الاعمدة التي تحتوي على مفاتييح اجنبية
        //public IList<MainJournalEntery> Filter(DateTime fromDate, DateTime toDate, Dictionary<string, int> columnsNameId)
        //{
        //    String query = $"SELECT * FROM [Dbo].[{Table.name}] WHERE MainJournalDateTime BETWEEN '{fromDate}' AND '{toDate}'";


        //    try
        //    {
        //        if (columnsNameId != null && columnsNameId.Count != 0)
        //        {
        //            string searchQuery = this.buildSearchQueries(columnsNameId);
        //            if (searchQuery != null)
        //            {
        //                query += " AND " + searchQuery;
        //            }

        //        }



        //        return Db.MainJournalEnteries.FromSqlRaw(query).ToList();

        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError($"failed to get all journal Enteries : {e}");
        //        return null;

        //    }

        //}

        // الدالة تقوم بأرجاع كل الصفوف التي تكون في تاريخ محدد
        // بالاضافة الى امكانية اضافة معيار بحث اخر هو البحث على اساس الاعمدة التي تحتوي على مفاتييح اجنبية
        //public IList<MainJournalEntery> Filter(DateTime inDate, Dictionary<string, int> columnsNameId)
        //{
        //    string query = $"SELECT * FROM [Dbo].[{Table.name}] WHERE MainJournalDateTime = '{inDate}' ";



        //    try
        //    {


        //        if (columnsNameId != null && columnsNameId.Count != 0)
        //        {
        //            string searchQuery = this.buildSearchQueries(columnsNameId);
        //            if (searchQuery != null)
        //            {
        //                query += " AND " + searchQuery;
        //            }

        //        }


        //        return Db.MainJournalEnteries.FromSqlRaw(query).ToList();


        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError($"failed to get all journal Enteries : {e}");
        //        return null;

        //    }

        //}

        public MainJournalEntery Find(int id)
        {
            try
            {
                var _JournalEntery = Db.MainJournalEnteries.Include(d => d.DetailedJournalEnteries)
                                                           .ThenInclude(d => d.CreditChildAccountNavigation)
                                                       .Include(d => d.DetailedJournalEnteries)
                                                           .ThenInclude(d => d.CurrenciesNavigation)
                                                       .Include(a => a.JournalEnterieTypesNavigation)
                                                       .Include(b => b.FiscalYearNavigation)
                                                       //   .Include(c => c.SystemUsersNavigation)
                                                       .SingleOrDefault(b => b.MainJournalEnteriesId == id);

                return _JournalEntery;

            }
            catch (Exception e)
            {
                logger.LogError($"failed to get all journal Enteries : {e}");
                return null;

            }


        }



        public void Update(int id, MainJournalEntery NewEntity)
        {
            try
            {
                var CurrentObject = Db.MainJournalEnteries.SingleOrDefault(p => p.MainJournalEnteriesId == id);
                if (CurrentObject == null)
                {

                    throw new System.Exception("There is an errer ???? No Object selected in the table");
                }
                if (NewEntity.IsDeleted == 1)
                {
                    CurrentObject.IsDeleted = 1;
                }
                else
                {
                    CurrentObject.IsStage = NewEntity.IsStage + 1 == 2 ? NewEntity.IsStage : 0;
                }

                // Db.MainJournalEnteries.Update(NewEntity);

                Db.SaveChanges();

            }
            catch (Exception e)
            {
                logger?.LogError($"Error When it was updating the data : {e}");

            }


        }



       public IList<MainJournalEntery> List()
        {

            try
            {
                return Db.MainJournalEnteries.Include(d => d.DetailedJournalEnteries)
                                                                    .ThenInclude(d => d.CreditChildAccountNavigation)
                                                                .Include(d => d.DetailedJournalEnteries)
                                                                    .ThenInclude(d => d.CurrenciesNavigation)
                                                               .Include(a => a.JournalEnterieTypesNavigation)
                                                               .Include(b => b.FiscalYearNavigation).
                                                            //   .Include(c => c.SystemUsersNavigation).
                                                               Where(isDeleted => isDeleted.IsDeleted == 0).ToList();
            }
            catch (Exception e)
            {
                logger.LogError($"Failed to get all journal Enteries Records : {e}");
                return null;
            }
        }

        IList<MainJournalEntery> pay_recie_finRepository<MainJournalEntery>.List(string CategoryName)
        {
            throw new System.NotImplementedException();
        }


    }
}



