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
    public class BankRepo : IBank
    {
        private readonly posDbContext _context;
        private string _errors = "";
        public BankRepo(posDbContext context)
        {
            _context = context;
        }
        public bool Create(Bank bank)
        {
            try
            {

                if (IsExNumberExists(bank.BankId)) return false;
                _context.Banks.Add(bank);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }

        }

        public bool Delete(Bank bank)
        {

            try
            {
                
                _context.Banks.Attach(bank);
                _context.Entry(bank).State = EntityState.Modified;
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }


        }

        public bool Edit(Bank bank)
        {

            try
            {

                
               

                _context.Banks.Attach(bank);
                _context.Entry(bank).State = EntityState.Modified;
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




        private List<Bank> DoSort(List<Bank> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(n => n.BankName).ToList();
                else
                    items = items.OrderByDescending(n => n.BankName).ToList();
            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                    items = items.OrderBy(d => d.BankId).ToList();
                else
                    items = items.OrderByDescending(d => d.BankId).ToList();
            }

            return items;
        }




        public Bank GetItem(int id)
        {
            Bank item = _context.Banks.Where(u => u.BankId == id).FirstOrDefault();
            return item;
        }

        public PaginatedList<Bank> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<Bank> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.Banks.Where(n => n.BankName.Contains(SearchText) || n.BankStatus.ToString().Contains(SearchText))
                    .ToList();
            }
            else
                items = _context.Banks.ToList();

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<Bank> retItems = new PaginatedList<Bank>(items, pageIndex, pageSize);

            return retItems;
        }

        public bool IsExNumberExists(int exNumber)
        {
            int ct = _context.Banks.Where(n => n.BankId == exNumber).Count();
            if (ct > 0)
            {
                _errors = " Bank ? " + exNumber + " Exists Already";
                return true;
            }

            else
                return false;
        }


    }
}




