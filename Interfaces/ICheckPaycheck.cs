using System.Linq;
using System.Threading.Tasks;

using POS.Tools;
using POS.Models.DB;
using POS.Models;
using System.Collections.Generic;

namespace POS.Interfaces
{
    public interface ICheckPaycheck
    {
        public string GetErrors();
        PaginatedList<CheckPaycheckVoucher> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all

        PaginatedList<CheckPaycheckVoucher> GetItemscheques(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all

        PaginatedList<CheckPaycheckVoucher> GetItemsStage(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);

        CheckPaycheckVoucher GetItem(string id); // read particular item

        bool Create(CheckPaycheckVoucher checkPaycheckVoucher);
        bool Edit(CheckPaycheckVoucher checkPaycheckVoucher);
        bool Delete(CheckPaycheckVoucher checkPaycheckVoucher);
        public bool IsExNumberExists(string exNumber);

        bool Cheque(CheckPaycheckVoucher checkPaycheckVoucher); 

        public string GetNewEXNumber();


    }
}
