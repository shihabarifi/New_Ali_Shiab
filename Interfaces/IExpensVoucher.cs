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
        IList<MainExpensVoucher> GetItems(); //read all

        IList<MainExpensVoucher> GetItemsStage();
        MainExpensVoucher GetItem(string id); // read particular item

        bool Create(MainExpensVoucher mainExpensVoucher);
        bool Edit(MainExpensVoucher mainExpensVoucher);
        bool Delete(MainExpensVoucher mainExpensVoucher);
        bool Stagelist(MainExpensVoucher mainExpensVoucher);

        public string GetNewEXNumber();


    }
}
