
using POS.Models;
using POS.Models.DB;
using POS.Tools;


namespace POS.Interfaces
{
    public interface IExchangeRate
    {
        PaginatedList<CurrenciesExchangeRate> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        CurrenciesExchangeRate GetItem(int id); // read particular item

        bool Create(CurrenciesExchangeRate currenciesExchange);

        bool Edit(CurrenciesExchangeRate currenciesExchange);

        bool Delete(CurrenciesExchangeRate currenciesExchange);

      

        public string GetErrors();
    }
}
