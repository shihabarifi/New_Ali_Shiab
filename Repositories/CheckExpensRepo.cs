
using POS.Interfaces;
using POS.Models;
using POS.Models.DB;
using POS.StoredProcedure;
using POS.Tools;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using POS.Data;

namespace POS.Repositories
{
    public class CheckExpensRepo : ICheckExpens
    {
        private readonly posDbContext _context; // for connecting to efcore.

        private string _errors = "";

        public string GetErrors()
        {
            return _errors;
        }


        public CheckExpensRepo(posDbContext context) // will be passed by dependency injection.
        {
            _context = context;
        }


        public bool Create(CheckExpensVoucher checkExpensVoucher)
        {
            // bool retVal=false;
            _errors = "";
            try
            {
                //if (!IsDescriptionValid(checkExpensVoucher)) return false;

                if (IsExNumberExists(checkExpensVoucher.CheckNumber)) return false;

                _context.CheckExpensVouchers.Add(checkExpensVoucher);
                _context.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }

        }

        public bool Delete(CheckExpensVoucher checkExpensVoucher)
        {


            bool retVal = false;
            _errors = "";
            try
            {


                _context.Attach(checkExpensVoucher);
                _context.Entry(checkExpensVoucher).State = EntityState.Modified;


                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.Message;
            }
            return retVal;

        }


        public bool Cheque(CheckExpensVoucher checkExpensVoucher)
        {


            bool retVal = false;
            _errors = "";
            try
            {


                _context.Attach(checkExpensVoucher);
                _context.Entry(checkExpensVoucher).State = EntityState.Modified;


                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Cheque Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }

        public bool Edit(CheckExpensVoucher checkExpensVoucher)
        {


            bool retVal = false;
            _errors = "";
            try
            {
               

                _context.Attach(checkExpensVoucher);
                _context.Entry(checkExpensVoucher).State = EntityState.Modified;
               

                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Update Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }


        private List<CheckExpensVoucher> DoSort(List<CheckExpensVoucher> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(n => n.CheckExpensVoucherNumber).ToList();
                else
                    items = items.OrderByDescending(n => n.CheckExpensVoucherNumber).ToList();
            }
         
            else
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(d => d.CheckDatetime).ToList();
                else
                    items = items.OrderByDescending(d => d.CheckDatetime).ToList();
            }

            return items;
        }

        public PaginatedList<CheckExpensVoucher> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 10)
        {
            List<CheckExpensVoucher> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.CheckExpensVouchers.Where(n =>n.IsDelete == 0 && n.CheckExpensVoucherNumber.Contains(SearchText) || n.CheckDatetime.ToString().Contains(SearchText))
                     .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a=>a.DebitChildAccountNavigation)
                     // .Include(u => u.SystemUsersNavigation)

                    .ToList();
            }
            else
                items = _context.CheckExpensVouchers.Where(d => d.IsDelete == 0)
                  .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.DebitChildAccountNavigation)
                    //   .Include(u => u.SystemUsersNavigation)

                    .ToList();
            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<CheckExpensVoucher> retItems = new PaginatedList<CheckExpensVoucher>(items, pageIndex, 10);

            return retItems;
        }

      

        public CheckExpensVoucher GetItem(string id)
        {



            CheckExpensVoucher item = _context.CheckExpensVouchers.Where(i => i.CheckExpensVoucherNumber == id)
                .Include(c=>c.DebitChildAccountNavigation)
            . FirstOrDefault();

            
            return item  ;
        }




        public bool IsExNumberExists(string exNumber)
        {
            int ct = _context.CheckExpensVouchers.Where(n => n.CheckNumber.ToLower() == exNumber.ToLower()).Count();
            if (ct > 0)
            {
                _errors = " Name " + exNumber + " Exists Already";
                return true;
            }
               
            else
                return false;
        }
    

        public string GetNewEXNumber()
        {
            string exnumber = "";

            var LastPoNumber = _context.CheckExpensVouchers.Max(cd => cd.CheckExpensVoucherNumber);
            if (LastPoNumber == null)
                exnumber = "CX00001";
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.Substring(2, 5).ToString(), out lastdigit);


                exnumber = "CX" + (lastdigit + 1).ToString().PadLeft(5, '0');
            }



            return exnumber;
        }

        PaginatedList<CheckExpensVoucher> ICheckExpens.GetItemscheques(string SortProperty, SortOrder sortOrder, string SearchText, int pageIndex, int pageSize)
        {
            List<CheckExpensVoucher> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.CheckExpensVouchers.Where(n => n.IsDelete == 0 && n.CheckExpendCheques == 0 && n.CheckExpensVoucherNumber.Contains(SearchText) || n.CheckDatetime.ToString().Contains(SearchText))
                     .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.DebitChildAccountNavigation)
                   //  .Include(u => u.SystemUsersNavigation)

                    .ToList();
            }
            else
                items = _context.CheckExpensVouchers.Where(d => d.IsDelete == 0 && d.CheckExpendCheques == 0)
                  .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.DebitChildAccountNavigation)
                       //.Include(u => u.SystemUsersNavigation)

                    .ToList();
            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<CheckExpensVoucher> retItems = new PaginatedList<CheckExpensVoucher>(items, pageIndex, 10);

            return retItems;
        }

        public PaginatedList<CheckExpensVoucher> GetItemsStagelist(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<CheckExpensVoucher> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.CheckExpensVouchers.Where(n => n.IsDelete == 0 &&n.CheckStatus==0 && n.CheckExpendCheques == 1 && n.CheckExpensVoucherNumber.Contains(SearchText) || n.CheckDatetime.ToString().Contains(SearchText))
                     .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.DebitChildAccountNavigation)
                   //  .Include(u => u.SystemUsersNavigation)

                    .ToList();
            }
            else
                items = _context.CheckExpensVouchers.Where(d => d.IsDelete == 0 && d.CheckStatus == 0 && d.CheckExpendCheques == 1)
                  .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.DebitChildAccountNavigation)
                     //  .Include(u => u.SystemUsersNavigation)

                    .ToList();
            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<CheckExpensVoucher> retItems = new PaginatedList<CheckExpensVoucher>(items, pageIndex, 10);

            return retItems;
        }
    }
}
