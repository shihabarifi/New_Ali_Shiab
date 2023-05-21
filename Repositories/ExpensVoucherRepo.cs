
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
    public class ExpensVoucherRepo : IExpensVoucher
    {
        private readonly posDbContext _context; // for connecting to efcore.

        private string _errors = "";

        public string GetErrors()
        {
            return _errors;
        }


        public ExpensVoucherRepo(posDbContext context) // will be passed by dependency injection.
        {
            _context = context;
        }


        public bool Create(MainExpensVoucher mainExpensVoucher)
        {
            // bool retVal=false;
            _errors = "";
            try
            {
             //   if (!IsDescriptionValid(mainExpensVoucher)) return false;

              //  if (IsExNumberExists(mainExpensVoucher.MainExpensVoucherDescription)) return false;

                _context.MainExpensVouchers.Add(mainExpensVoucher);
                _context.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }

        }

        public bool Delete(MainExpensVoucher mainExpensVoucher)
        {


            bool retVal = false;
            _errors = "";
            try
            {
                List<DetailedExpensVoucher> detailedExpensVoucher = _context.DetailedExpensVouchers.Where(d => d.MainExpensVoucherNumber == mainExpensVoucher.MainExpensVoucherNumber).ToList();
                _context.DetailedExpensVouchers.RemoveRange(detailedExpensVoucher);
                _context.SaveChanges();

                _context.Attach(mainExpensVoucher);
                _context.Entry(mainExpensVoucher).State = EntityState.Modified;
                _context.DetailedExpensVouchers.AddRange(mainExpensVoucher.DetailedExpensVouchers);

                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.Message;
            }
            return retVal;







        }

        public bool Edit(MainExpensVoucher mainExpensVoucher)
        {

            bool retVal = false;
            _errors = "";
            try
            {
                List<DetailedExpensVoucher> detailedExpensVoucher = _context.DetailedExpensVouchers.Where(d => d.MainExpensVoucherNumber == mainExpensVoucher.MainExpensVoucherNumber).ToList();
                _context.DetailedExpensVouchers.RemoveRange(detailedExpensVoucher);
                _context.SaveChanges();

                _context.Attach(mainExpensVoucher);
                _context.Entry(mainExpensVoucher).State = EntityState.Modified;
                _context.DetailedExpensVouchers.AddRange(mainExpensVoucher.DetailedExpensVouchers);

                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Update Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }


        private List<MainExpensVoucher> DoSort(List<MainExpensVoucher> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(n => n.MainExpensVoucherNumber).ToList();
                else
                    items = items.OrderByDescending(n => n.MainExpensVoucherNumber).ToList();
            }
         
            else
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(d => d.MainExpensVoucherDate).ToList();
                else
                    items = items.OrderByDescending(d => d.MainExpensVoucherDate).ToList();
            }

            return items;
        }

        public IList<MainExpensVoucher> GetItems()
        {
            List<MainExpensVoucher> items;

                items = _context.MainExpensVouchers.Where(n =>n.IsDelete!=1).OrderByDescending(n=>n.MainExpensVoucherNumber)
                     .Include(f => f.FundsNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                     // .Include(u => u.SystemUsersNavigation)
                      .Include(d=>d.DetailedExpensVouchers)
                        .ThenInclude(a => a.DebitChildAccountNavigation)
                    .ToList();
         
          

            return items;
        }

        public MainExpensVoucher GetItem(string id)
        {
            MainExpensVoucher item = _context.MainExpensVouchers.Where(i => i.MainExpensVoucherNumber == id)
               .Include(d => d.DetailedExpensVouchers)
               .ThenInclude(a => a.DebitChildAccountNavigation)
                .FirstOrDefault();


            item.DetailedExpensVouchers.ForEach(p => p.ArabicAccName = p.DebitChildAccountNavigation.ArabicAccName);


            return item;
        }




     





       
        public string GetNewEXNumber()
        {
            string exnumber = "";

            var LastPoNumber = _context.MainExpensVouchers.Max(cd => cd.MainExpensVoucherNumber);
            if (LastPoNumber == null)
                exnumber = "EX00001";
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.Substring(2, 5).ToString(), out lastdigit);


                exnumber = "EX" + (lastdigit + 1).ToString().PadLeft(5, '0');
            }



            return exnumber;
        }

        public IList<MainExpensVoucher> List()
        {
            throw new NotImplementedException();
        }

        public IList<MainExpensVoucher> GetItemsStage()
        {
            List<MainExpensVoucher> items;

                items = _context.MainExpensVouchers.Where(n => n.IsDelete == 0 && n.MainExpensVoucherStatus==0 ).OrderByDescending(n => n.MainExpensVoucherNumber)
                     .Include(f => f.FundsNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                     // .Include(u => u.SystemUsersNavigation)
                      .Include(d => d.DetailedExpensVouchers)

                    .ToList();
            return items;
           
        }

        public bool Stagelist(MainExpensVoucher mainExpensVoucher)
        {
            throw new NotImplementedException();
        }
    }
}
