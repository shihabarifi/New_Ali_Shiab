using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.StoredProcedure;
using POS.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using POS.Data;

namespace POS.Repositories
{
    public class AccountingManualRepo : IAccountingManual
    {

        private readonly posDbContext _context;
        private string _errors = "";
        public AccountingManualRepo(posDbContext context)
        {
            _context = context;
        }
        public bool Create(AccountingManual accountingManual)
        {
            try
            {
               

                _context.AccountingManuals.Add(accountingManual);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }

        }

        public bool Delete(AccountingManual accountingManual)
        {
            try
            {
                List<AccountsCurrency> accountsCurrency = _context.AccountsCurrencies.Where(d => d.AccountingManual == accountingManual.AccNumber).ToList();

                _context.AccountsCurrencies.RemoveRange(accountsCurrency);
                _context.SaveChanges();


                _context.AccountingManuals.Attach(accountingManual);
                _context.Entry(accountingManual).State = EntityState.Deleted;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.InnerException.Message;
                else
                    _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }
        }

        public bool Edit(AccountingManual accountingManual)
        {
            try
            {
                
                List<AccountsCurrency> accountsCurrency = _context.AccountsCurrencies.Where(d => d.AccountingManual== accountingManual.AccNumber).ToList();

                _context.AccountsCurrencies.RemoveRange(accountsCurrency);
                _context.SaveChanges();
                _context.AccountingManuals.Attach(accountingManual);
                _context.Entry(accountingManual).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Update Failed -Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }
        }

        public string GetErrors()
        {
            return _errors;
        }




        private List<AccountingManual> DoSort(List<AccountingManual> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(n => n.ArabicAccName).ToList();
                else
                    items = items.OrderByDescending(n => n.ArabicAccName).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(d => d.AccNumber).ToList();
                else
                    items = items.OrderByDescending(d => d.AccNumber).ToList();
            }

            return items;
        }




        public AccountingManual GetItem(string id)
        {
            AccountingManual item = _context.AccountingManuals.Where(u => u.AccNumber == id )
                .Include(c=>c.AccountsCurrencies)
                 .ThenInclude(a => a.CurrenciesNavigation)
                .FirstOrDefault();
            return item;
        }

        public PaginatedList<AccountingManual> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<AccountingManual> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.AccountingManuals.Where(n => n.AccType.Contains(SearchText) || n.ArabicAccName!=("xx") )
                    .Include(c => c.FinalAccountTypeNavigation)
                    .ToList();
            }
            else
                items = _context.AccountingManuals.Include(f=>f.FinalAccountTypeNavigation).ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<AccountingManual> retItems = new PaginatedList<AccountingManual>(items, pageIndex, pageSize);

            return retItems;
        }


     
      

       


      

    }
}
