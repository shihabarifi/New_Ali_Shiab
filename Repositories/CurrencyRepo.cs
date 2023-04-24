
using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.Tools;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using POS.Data;

namespace POS.Repositories
{
    public class CurrencyRepo : ICurrency
    {
        private readonly posDbContext _context;
        private string _errors = "";
        public CurrencyRepo(posDbContext context)
        {
            _context=context;
        }
        public bool Create(Currency currency)
        {
            try
            {
              

                if(IsItemExists(currency.CurrenName))return false;

                _context.Currencies.Add(currency);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }
           
        }

        public bool Delete(Currency currency)
        {


            try
            {

                _context.Currencies.Attach(currency);
                _context.Entry(currency).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }
        }
        

        public bool Edit(Currency currency)
        {
            try
            {
                

               

                _context.Currencies.Attach(currency);
                _context.Entry(currency).State = EntityState.Modified;
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




        private List<Currency> DoSort(List<Currency> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.CurrenName).ToList();
                else
                    items = items.OrderByDescending(n => n.CurrenName).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(d => d.CurrenciesId).ToList();
                else
                    items = items.OrderByDescending(d => d.CurrenciesId).ToList();
            }

            return items;
        }




        public Currency GetItem(int id)
        {
            Currency item = _context.Currencies.Where(u => u.CurrenciesId == id).FirstOrDefault();
            return item;
        }

        public PaginatedList<Currency> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Currency> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.Currencies.Where(n => n.CurrStatus.ToString().Contains(SearchText) || n.CurrenName.Contains(SearchText))
                    .ToList();
            }
            else
                items = _context.Currencies.ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<Currency> retItems = new PaginatedList<Currency>(items, pageIndex, pageSize);

            return retItems;
        }

        public bool IsCurrencyCombExists(int srcCurrencyId, int excCurrencyId)
        {
            int ct = _context.Currencies.Where(n => n.CurrenciesId == srcCurrencyId && n.CurrenciesId==excCurrencyId).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }

        public bool IsItemExists(string name)
        {
            int ct = _context.Currencies.Where(n => n.CurrenName.ToLower() == name.ToLower()).Count();
            if (ct > 0)
            {
                _errors = " Name " + name + " Exists Already";
                return true;
            }
            else
                return false;
        }

        public bool IsItemExists(string name, int id)
        {
            int ct = _context.Currencies.Where(n => n.CurrenName.ToLower() == name.ToLower() && n.CurrenciesId != id).Count();
            if (ct > 0)
                return true;
            else
                return false;
        }

        

      
    }
}
