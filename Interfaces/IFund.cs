using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using POS.Tools;
using POS.Models.DB;
using POS.Models;

namespace POS.Interfaces
{
    public interface IFund
    {
        PaginatedList<Fund> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Fund GetItem(int id); // read particular item

        bool Create(Fund fund);

        bool  Edit(Fund fund);

        bool Delete(Fund fund);

        public bool IsItemExists(int id);
     

        public string GetErrors();

    }
}


