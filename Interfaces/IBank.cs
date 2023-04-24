using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using POS.Tools;
using POS.Models.DB;
using POS.Models;


namespace POS.Interfaces
{
    public interface IBank
    {
        PaginatedList<Bank> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Bank GetItem(int id); // read particular item

        bool Create(Bank bank);

        bool  Edit(Bank bank);

        bool Delete(Bank bank);


        public bool IsExNumberExists(int exNumber);
        public string GetErrors();

    }
}


