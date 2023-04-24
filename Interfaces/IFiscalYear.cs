using POS.Models;
using POS.Models.DB;
using POS.Tools;

namespace POS.Interfaces
{
    public interface IFiscalYear
    {
        PaginatedList<FiscalYear> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        FiscalYear GetItem(int id); // read particular item

        bool Create(FiscalYear fiscalYear);

        bool Edit(FiscalYear fiscalYear);

        bool Delete(FiscalYear fiscalYear);

        public bool IsItemExists(string id);


        public string GetErrors();
    }
}
