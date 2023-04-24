using System.Linq;
using System.Threading.Tasks;

using POS.Tools;
using POS.Models.DB;
using POS.Models;
using System.Collections.Generic;

namespace POS.Interfaces
{
    public interface IExpensVoucher
    {
        public string GetErrors();
        PaginatedList<MainExpensVoucher> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all

        PaginatedList<MainExpensVoucher> GetItemsStage(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        MainExpensVoucher GetItem(string id); // read particular item

        bool Create(MainExpensVoucher mainExpensVoucher);
        bool Edit(MainExpensVoucher mainExpensVoucher);
        bool Delete(MainExpensVoucher mainExpensVoucher);
        bool Stagelist(MainExpensVoucher mainExpensVoucher);

        public string GetNewEXNumber();


    }
}
