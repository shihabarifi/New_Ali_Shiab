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
    public class CurrenciesExchangeRateRepo : ICurrenciesExchangeRate
    {
        private readonly posDbContext _context;
        private string _errors = "";
        public CurrenciesExchangeRateRepo(posDbContext context)
        {
            _context = context;
        }
        public bool Create(CurrenciesExchangeRate currenciesExchangeRate)
        {
            try
            {


               // if (IsItemExists(currenciesExchangeRate.CurreExhhangeStatus)) return false;

                _context.CurrenciesExchangeRates.Add(currenciesExchangeRate);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }
        }

        public bool Delete(CurrenciesExchangeRate currenciesExchangeRate)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(CurrenciesExchangeRate currenciesExchangeRate)
        {
            throw new System.NotImplementedException();
        }


        public string GetErrors()
        {
            return _errors;
        }
        private List<CurrenciesExchangeRate> DoSort(List<CurrenciesExchangeRate> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.CurreExchangeDate).ToList();
                else
                    items = items.OrderByDescending(n => n.CurreExchangeDate).ToList();
            }
           

            return items;
        }

        public CurrenciesExchangeRate GetItem(int id)
        {
            CurrenciesExchangeRate item = _context.CurrenciesExchangeRates.Where(u => u.CurrenciesExchangeRateId == id).FirstOrDefault();
            return item;
        }

        public PaginatedList<CurrenciesExchangeRate> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<CurrenciesExchangeRate> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.CurrenciesExchangeRates.Where(n => n.CurreExchangeRate.ToString().Contains(SearchText) || n.CurrenciesNavigation.CurrenName.Contains(SearchText))
                    .Include(c => c.CurrenciesNavigation)
                    .ToList();
            }
            else
                items = _context.CurrenciesExchangeRates.Include(c => c.CurrenciesNavigation).ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<CurrenciesExchangeRate> retItems = new PaginatedList<CurrenciesExchangeRate>(items, pageIndex, pageSize);

            return retItems;
        }

        //public bool IsItemExists(int name)
        //{
        //    int ct = _context.CurrenciesExchangeRates.Where(n => n.Currencies=n.CurreExhhangeStatus==1).Count();
        //    if (ct > 0)
        //    {
        //        _errors = " Name " + name + " Exists Already";
        //        return true;
        //    }
        //    else
        //        return false;
        //}
    }
}
