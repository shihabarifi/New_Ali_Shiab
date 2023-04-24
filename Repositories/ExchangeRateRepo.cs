
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
    public class ExchangeRateRepo : IExchangeRate
    {
        private readonly posDbContext _context;
        private string _errors = "";
        public ExchangeRateRepo(posDbContext context)
        {
            _context=context;
        }
        public bool Create(CurrenciesExchangeRate currenciesExchange)
        {
            return false;
           
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
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(d => d.CurreExchangeRate).ToList();
                else
                    items = items.OrderByDescending(d => d.CurreExchangeRate).ToList();
            }

            return items;
        }




        public CurrenciesExchangeRate GetItem(int id)
        {
            CurrenciesExchangeRate item = _context.CurrenciesExchangeRates.Where(u => u.Currencies == id && u.CurreExhhangeStatus==1)
                .Include(d => d.Currencies) 
                .FirstOrDefault();
            return item;
        }

        public PaginatedList<CurrenciesExchangeRate> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<CurrenciesExchangeRate> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.CurrenciesExchangeRates.Where(n => n.CurreExchangeDate.ToString().Contains(SearchText) || n.CurreExchangeRate.ToString().Contains(SearchText))
                    .ToList();
            }
            else
                items = _context.CurrenciesExchangeRates.ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<CurrenciesExchangeRate> retItems = new PaginatedList<CurrenciesExchangeRate>(items, pageIndex, pageSize);

            return retItems;
        }


     

        public bool Edit(CurrenciesExchangeRate currenciesExchange)
        {
            throw new NotImplementedException();
        }

        public bool Delete(CurrenciesExchangeRate currenciesExchange)
        {
            throw new NotImplementedException();
        }
    }
}
