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
    public class FundRepo :IFund
    {
        private readonly posDbContext _context;
        private string _errors = "";
        public FundRepo(posDbContext context)
        {
            _context = context;
        }
        public bool Create(Fund fund)
        {
            try
            {
             

                if (IsItemExists(fund.FundsId)) return false;

                _context.Funds.Add(fund);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }

        }

        public bool Delete(Fund fund)
        {
            try
            {

                _context.Funds.Attach(fund);
                _context.Entry(fund).State = EntityState.Modified;
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }
        }

        public bool Edit(Fund fund)
        {
            try
            {

                _context.Funds.Attach(fund);
                _context.Entry(fund).State = EntityState.Modified;
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




        private List<Fund> DoSort(List<Fund> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.FundName).ToList();
                else
                    items = items.OrderByDescending(n => n.FundName).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(d => d.FundsId).ToList();
                else
                    items = items.OrderByDescending(d => d.FundsId).ToList();
            }

            return items;
        }




        public Fund GetItem(int id)
        {
            Fund item = _context.Funds.Where(u => u.FundsId == id).FirstOrDefault();
            return item;
        }

        public PaginatedList<Fund> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Fund> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.Funds.Where(n => n.FundName.Contains(SearchText) || n.FundStatus.ToString().Contains(SearchText))
                    .ToList();
            }
            else
                items = _context.Funds.ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<Fund> retItems = new PaginatedList<Fund>(items, pageIndex, pageSize);

            return retItems;
        }

     
        public bool IsItemExists(int id)
        {
            int ct = _context.Funds.Where(n => n.FundsId == id).Count();
            if (ct > 0)
            {
                _errors = " Name " + id + " Exists Already";
                return true;
            }
            else
                return false;
        }

       

        


    }
}




