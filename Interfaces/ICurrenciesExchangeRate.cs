using POS.Models;
using POS.Models.DB;
using POS.Tools;

namespace POS.Interfaces
{
    public interface ICurrenciesExchangeRate
    {
        PaginatedList<CurrenciesExchangeRate> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        CurrenciesExchangeRate GetItem(int id); // read particular item

        bool Create(CurrenciesExchangeRate currenciesExchangeRate);

        bool Edit(CurrenciesExchangeRate currenciesExchangeRate);

        bool Delete(CurrenciesExchangeRate currenciesExchangeRate);

       // public bool IsItemExists(int name);
       

        public string GetErrors();
    }
}
