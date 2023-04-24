using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using POS.Tools;
using POS.Models;
using POS.Models.DB;

namespace POS.Interfaces
{
    public interface IAccountingManual
    {
        PaginatedList<AccountingManual> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        AccountingManual GetItem(string id); // read particular item

        bool Create(AccountingManual accountingManual);

        bool Edit(AccountingManual accountingManual);

        bool Delete(AccountingManual accountingManual);

        public string GetErrors();

    }
}


