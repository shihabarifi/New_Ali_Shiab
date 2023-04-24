using System.Linq;
using System.Threading.Tasks;

using POS.Tools;
using POS.Models.DB;
using POS.Models;
using System.Collections.Generic;


namespace POS.Interfaces
{
    public interface ICheckExpens
    {
        public string GetErrors();
        PaginatedList<CheckExpensVoucher> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        PaginatedList<CheckExpensVoucher> GetItemscheques(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        PaginatedList<CheckExpensVoucher> GetItemsStagelist(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);

        CheckExpensVoucher GetItem(string id); // read particular item

        bool Create(CheckExpensVoucher checkExpensVoucher);
        bool Edit(CheckExpensVoucher checkExpensVoucher);
        bool Delete(CheckExpensVoucher checkExpensVoucher);

        bool Cheque(CheckExpensVoucher checkExpensVoucher);
        public bool IsExNumberExists(string exNumber);
       


        public string GetNewEXNumber();


    }
}
