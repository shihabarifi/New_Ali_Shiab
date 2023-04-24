using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using POS.Models.DB;
using POS.Repositories;

using POS.Interfaces;
using POS.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace POS.Repositories
{
    public class DetailedJournalEnteryDb_Repository : pay_recie_finRepository<DetailedJournalEntery>
    {
        private readonly posDbContext Db;
        private readonly ILogger<DetailedJournalEnteryDb_Repository> logger;
        // تم تعريفه لجعله المكان الوحيد لتعريف الجدول و الاعمدة التي تعتبر مفاتيح لجداول اجنبيه لتسهيل عمل التقارير
        //public static readonly Table Table = new Table("Detailed_Journal_Enteries", new List<string> { "main_journal_enteries", "currencies", "DebitChildAccount", "CreditChildAccount", "currencies_exchange_rate" });


        public DetailedJournalEnteryDb_Repository(posDbContext _Db, ILogger<DetailedJournalEnteryDb_Repository> _logger)
        {
            Db = _Db;
            logger = _logger;
        }
        public void Add(DetailedJournalEntery entity)
        {
            Db.DetailedJournalEnteries.Add(entity);
            Db.SaveChanges();
        }



        public void Delete(int id)
        {
            var _detailedJourEnteries = Find(id);
            Db.DetailedJournalEnteries.Remove(_detailedJourEnteries);
            Db.SaveChanges();
        }

        public DetailedJournalEntery Find(int id)
        {
            var _detailedJourEnteries = Db.DetailedJournalEnteries.SingleOrDefault(b => b.DetailedJournalEnteriesId == id);
            return _detailedJourEnteries;
        }

        public IList<DetailedJournalEntery> List()
        {

            return Db.DetailedJournalEnteries.ToList();
        }

        public void Update(int id, DetailedJournalEntery NewEntity)
        {
            /* var system_user = Find(id);
             system_user.PhoneNumber = NewEntity.PhoneNumber;
             system_user.UserName = NewEntity.UserName;
             system_user.UserEmail = NewEntity.UserEmail;
             system_user.UserPassword = NewEntity.UserPassword;
             system_user.UserStatus = NewEntity.UserStatus;
             system_user.UsersRolesTypes = NewEntity.UsersRolesTypes;*/
            Db.Update(NewEntity);
            Db.SaveChanges();


        }



        IList<DetailedJournalEntery> pay_recie_finRepository<DetailedJournalEntery>.List()
        {
            return Db.DetailedJournalEnteries.ToList();
        }

        IList<DetailedJournalEntery> pay_recie_finRepository<DetailedJournalEntery>.List(string CategoryName)
        {
            throw new System.NotImplementedException();
        }

        // الدالة تقوم بتركيب باقي نص عملية الـ Select , على اساس الاعمدة و القيم الممرره
        //private string buildSearchQueries(Dictionary<string, int> columnsNameId)
        //{
        //    if (columnsNameId != null && columnsNameId.Count != 0)
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
        //            throw new Exception($"Specified forigen keys {String.Join(",", columnsNameId.Keys)} does not exist in [{Table.name}] table. ");
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
        //public IList<DetailedJournalEntery> Filter(Dictionary<string, int> columnsNameId)
        //{

        //    String query = $"SELECT * FROM [Dbo].[{Table.name}]".ToString();
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

        //        System.Diagnostics.Debug.WriteLine($"Queried : {query}");

        //        return Db.DetailedJournalEnteries.FromSqlRaw(query).ToList();


        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError($"Failed to filter detailed journal entries based on specified column/s.Viwe exception for more information :\n {e}");
        //        return null;

        //    }
        //}
    }
}



