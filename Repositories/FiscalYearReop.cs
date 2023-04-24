using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using POS.Data;

namespace POS.Repositories
{
    public class FiscalYearReop : IFiscalYear
    {
        private readonly posDbContext _context;
        private string _errors = "";
        public FiscalYearReop(posDbContext context)
        {
            _context = context;
          
        }
        public bool Create(FiscalYear fiscalYear)
        {
            try
            {
               

                if (IsItemExists(fiscalYear.StartDate.ToString()))  return false;

                _context.FiscalYears.Add(fiscalYear);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }

        }

        public bool Delete(FiscalYear fiscalYear)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(FiscalYear fiscalYear)
        {
            try
            {

                _context.FiscalYears.Attach(fiscalYear);
                _context.Entry(fiscalYear).State = EntityState.Modified;
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                _errors = "Update Failed -Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }
        }

        public string GetErrors()
        {
            return _errors;
        }
        private List<FiscalYear> DoSort(List<FiscalYear> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.StartDate).ToList();
                else
                    items = items.OrderByDescending(n => n.StartDate).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(d => d.EndDate).ToList();
                else
                    items = items.OrderByDescending(d => d.EndDate).ToList();
            }

            return items;
        }
        public FiscalYear GetItem(int id)
        {
            FiscalYear item = _context.FiscalYears.Where(u => u.FiscalYearId == id).FirstOrDefault();
            return item;
        }

        public PaginatedList<FiscalYear> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<FiscalYear> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.FiscalYears.Where(n => n.FiscalYearName.Contains(SearchText) || n.StartDate.ToString().Contains(SearchText))
                    .ToList();
            }
            else
                items = _context.FiscalYears.ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<FiscalYear> retItems = new PaginatedList<FiscalYear>(items, pageIndex, pageSize);

            return retItems;
        }

        public bool IsItemExists(string id)
        {
            int ct = _context.FiscalYears.Where(n => n.StartDate.ToString() == id||n.EndDate.ToString()==id).Count();
            if (ct > 0)
            {
                _errors = " This Year " + id + " Exists Already";
                return true;
            }
            else
                return false;
        }
    }
}
