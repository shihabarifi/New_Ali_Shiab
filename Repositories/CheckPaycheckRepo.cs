
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
    public class CheckPaycheckRepo : ICheckPaycheck
    {
        private readonly posDbContext _context; // for connecting to efcore.

        private string _errors = "";

        public string GetErrors()
        {
            return _errors;
        }


        public CheckPaycheckRepo(posDbContext context) // will be passed by dependency injection.
        {
            _context = context;
        }


        public bool Create(CheckPaycheckVoucher checkPaycheckVoucher)
        {
            // bool retVal=false;
            _errors = "";
            try
            {
                //if (!IsDescriptionValid(checkExpensVoucher)) return false;

                if (IsExNumberExists(checkPaycheckVoucher.CheckNumber)) return false;

                _context.CheckPaycheckVouchers.Add(checkPaycheckVoucher);
                _context.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }

        }

        public bool Delete(CheckPaycheckVoucher checkPaycheckVoucher)
        {
            bool retVal = false;
            _errors = "";
            try
            {


                _context.Attach(checkPaycheckVoucher);
                _context.Entry(checkPaycheckVoucher).State = EntityState.Modified;


                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.Message;
            }
            return retVal;

        }

        public bool Edit(CheckPaycheckVoucher checkPaycheckVoucher)
        {


            bool retVal = false;
            _errors = "";
            try
            {


                _context.Attach(checkPaycheckVoucher);
                _context.Entry(checkPaycheckVoucher).State = EntityState.Modified;


                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Update Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }




        public bool Cheque(CheckPaycheckVoucher checkPaycheckVoucher)
        {


            bool retVal = false;
            _errors = "";
            try
            {


                _context.Attach(checkPaycheckVoucher);
                _context.Entry(checkPaycheckVoucher).State = EntityState.Modified;


                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Cheque Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }

        private List<CheckPaycheckVoucher> DoSort(List<CheckPaycheckVoucher> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(n => n.CheckPaycheckVoucherNumber).ToList();
                else
                    items = items.OrderByDescending(n => n.CheckPaycheckVoucherNumber).ToList();
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

        public PaginatedList<CheckPaycheckVoucher> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 10)
        {
            List<CheckPaycheckVoucher> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.CheckPaycheckVouchers.Where(n =>n.IsDelete==0&& n.CheckPaycheckVoucherNumber.Contains(SearchText) || n.CheckDatetime.ToString().Contains(SearchText))
                     .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a=>a.CreditChildAccountNavigation)
                     // .Include(u => u.SystemUsersNavigation)

                    .ToList();
            }
            else
                items = _context.CheckPaycheckVouchers.Where(d => d.IsDelete == 0)
                  .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.CreditChildAccountNavigation)
                    //   .Include(u => u.SystemUsersNavigation)

                    .ToList();
            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<CheckPaycheckVoucher> retItems = new PaginatedList<CheckPaycheckVoucher>(items, pageIndex, 10);

            return retItems;
        }




        public PaginatedList<CheckPaycheckVoucher> GetItemscheques(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 10)
        {
            List<CheckPaycheckVoucher> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.CheckPaycheckVouchers.Where(n => n.IsDelete == 0 && n.CheckPayCheckCheques==0 && n.CheckPaycheckVoucherNumber.Contains(SearchText) || n.CheckDatetime.ToString().Contains(SearchText))
                     .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.CreditChildAccountNavigation)
                    // .Include(u => u.SystemUsersNavigation)

                    .ToList();
            }
            else
                items = _context.CheckPaycheckVouchers.Where(d => d.IsDelete == 0 && d.CheckPayCheckCheques == 0)
                  .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.CreditChildAccountNavigation)
                    //   .Include(u => u.SystemUsersNavigation)

                    .ToList();
            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<CheckPaycheckVoucher> retItems = new PaginatedList<CheckPaycheckVoucher>(items, pageIndex, 10);

            return retItems;
        }





        public CheckPaycheckVoucher GetItem(string id)
        {
            CheckPaycheckVoucher item = _context.CheckPaycheckVouchers.Where(i => i.CheckPaycheckVoucherNumber == id)
                 .Include(c => c.CreditChildAccountNavigation)
                .FirstOrDefault();
            


            return item;
        }




        public bool IsExNumberExists(string exNumber)
        {
            int ct = _context.CheckPaycheckVouchers.Where(n => n.CheckNumber.ToLower() == exNumber.ToLower()).Count();
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

            var LastPoNumber = _context.CheckPaycheckVouchers.Max(cd => cd.CheckPaycheckVoucherNumber);
            if (LastPoNumber == null)
                exnumber = "CP00001";
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.Substring(2, 5).ToString(), out lastdigit);


                exnumber = "CP" + (lastdigit + 1).ToString().PadLeft(5, '0');
            }



            return exnumber;
        }

        public PaginatedList<CheckPaycheckVoucher> GetItemsStage(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<CheckPaycheckVoucher> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.CheckPaycheckVouchers.Where(n => n.IsDelete == 0 && n.CheckStatus==0 && n.CheckPayCheckCheques == 1 && n.CheckPaycheckVoucherNumber.Contains(SearchText) || n.CheckDatetime.ToString().Contains(SearchText))
                     .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.CreditChildAccountNavigation)
                   //  .Include(u => u.SystemUsersNavigation)

                    .ToList();
            }
            else
                items = _context.CheckPaycheckVouchers.Where(d => d.IsDelete == 0 && d.CheckStatus == 0 && d.CheckPayCheckCheques == 1)
                  .Include(b => b.BanksNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      .Include(a => a.CreditChildAccountNavigation)
                    //   .Include(u => u.SystemUsersNavigation)

                    .ToList();
            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<CheckPaycheckVoucher> retItems = new PaginatedList<CheckPaycheckVoucher>(items, pageIndex, 10);

            return retItems;
        }
    }
}
