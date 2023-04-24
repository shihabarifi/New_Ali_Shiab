﻿
using POS.Models;
using POS.Models.DB;
using POS.Tools;


namespace POS.Interfaces
{
    public interface ICurrency
    {
        PaginatedList<Currency> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Currency GetItem(int id); // read particular item

        bool Create(Currency currency);

        bool Edit(Currency currency);

        bool Delete(Currency currency);

        public bool IsItemExists(string name);
        public bool IsItemExists(string name, int id);

        public bool IsCurrencyCombExists(int srcCurrencyId, int excCurrencyId);

        public string GetErrors();
    }
}
