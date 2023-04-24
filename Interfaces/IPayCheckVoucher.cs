using System.Linq;
using System.Threading.Tasks;

using POS.Tools;
using POS.Models.DB;
using POS.Models;
using System.Collections.Generic;

namespace POS.Interfaces
{
    public interface IPayCheckVoucher
    {
        public string GetErrors();
        PaginatedList<MainPayCheck> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all

        PaginatedList<MainPayCheck> GetItemsStage(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5);
        MainPayCheck GetItem(string id); // read particular item

        bool Create(MainPayCheck mainPayCheck);
        bool Edit(MainPayCheck mainPayCheck);
        bool Delete(MainPayCheck mainPayCheck);
        //public bool IsExNumberExists(string exNumber);
        //public bool IsExNumberExists(string exNumber, int Id);

        //public bool IsDescrptinExists(string refNumber);
        //public bool IsDescrptinExists(string refumber, int Id);


        public string GetNewEXNumber();


    }
}
