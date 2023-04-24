
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
    public class PayCheckVoucherRepo : IPayCheckVoucher
    {
        private readonly posDbContext _context; // for connecting to efcore.

        private string _errors = "";

        public string GetErrors()
        {
            return _errors;
        }


        public PayCheckVoucherRepo(posDbContext context) // will be passed by dependency injection.
        {
            _context = context;
        }


        public bool Create(MainPayCheck mainPayCheck)
        {
            // bool retVal=false;
            _errors = "";
            try
            {
              //  if (!IsDescriptionValid(mainPayCheck)) return false;

               // if (IsExNumberExists(mainPayCheck.MainPaycheckDescription)) return false;

                _context.MainPayChecks.Add(mainPayCheck);
                _context.SaveChanges();
                return true;


            }
            catch (Exception ex)
            {
                _errors = "Create Failed Sql Exception Occured , Error Info :" + ex.Message;
                return false;
            }

        }

        public bool Delete(MainPayCheck mainPayCheck)
        {
            bool retVal = false;
            _errors = "";
            try
            {
                List<DetailedPayCheck> detailedPayCheck = _context.DetailedPayChecks.Where(d => d.MainPaycheck == mainPayCheck.MainPaycheckNumber).ToList();
                _context.DetailedPayChecks.RemoveRange(detailedPayCheck);
                _context.SaveChanges();

                _context.Attach(mainPayCheck);
                _context.Entry(mainPayCheck).State = EntityState.Modified;
                _context.DetailedPayChecks.AddRange(mainPayCheck.DetailedPayChecks);

                _context.SaveChanges();
                retVal = true;
            }

            catch (Exception ex)
            {
                _errors = "Delete Failed -Sql Exception Occured , Error Info :" + ex.Message;
            }
            return retVal;



        }

        public bool Edit(MainPayCheck mainPayCheck)
        {
             bool retVal=false;
            _errors = "";
            try
            {
                List<DetailedPayCheck> detailedPayCheck = _context.DetailedPayChecks.Where(d => d.MainPaycheck == mainPayCheck.MainPaycheckNumber).ToList();
                _context.DetailedPayChecks.RemoveRange(detailedPayCheck);
                _context.SaveChanges();

                _context.Attach(mainPayCheck);
                _context.Entry(mainPayCheck).State = EntityState.Modified;
                _context.DetailedPayChecks.AddRange(mainPayCheck.DetailedPayChecks);

                _context.SaveChanges();
                retVal =true;
            }

            catch (Exception ex)
            {
                _errors = "Update Failed - Sql Exception Occured , Error Info : " + ex.Message;
            }
            return retVal;
        }
    
    

        private List<MainPayCheck> DoSort(List<MainPayCheck> items, string SortProperty, SortOrder sortOrder)
        {

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(n => n.MainPaycheckNumber).ToList();
                else
                    items = items.OrderByDescending(n => n.MainPaycheckNumber).ToList();
            }
         
            else
            {
                if (sortOrder == SortOrder.Descending)
                    items = items.OrderBy(d => d.MainPaycheckDate).ToList();
                else
                    items = items.OrderByDescending(d => d.MainPaycheckDate).ToList();
            }

            return items;
        }

        public PaginatedList<MainPayCheck> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 10)
        {
            List<MainPayCheck> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.MainPayChecks.Where(n => n.IsDelete==0 && n.MainPaycheckNumber.Contains(SearchText) || n.MainPaycheckDate.ToString().Contains(SearchText))
                     .Include(f => f.FundsNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      //.Include(u => u.SystemUsersNavigation)
                     .Include(a=>a.DetailedPayChecks)
                     
                    .ToList();

                
            }
            else
                items = _context.MainPayChecks.Where(d=>d.IsDelete==0)
                    .Include(f => f.FundsNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      
                     .Include(a => a.DetailedPayChecks)

                    .ToList();

           

            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<MainPayCheck> retItems = new PaginatedList<MainPayCheck>(items, pageIndex, 10);
            
            return retItems;
        }

        public MainPayCheck GetItem(string id)
        {
            MainPayCheck item = _context.MainPayChecks.Where(i => i.MainPaycheckNumber == id)
                .Include(d => d.DetailedPayChecks)
                .ThenInclude(a=>a.CreditChildAccountNavigation)
                
                .FirstOrDefault();
            //  item.MainPaycheckAmountRly.ForEach(item.MainPaycheckAmountUdo * item.CurrenciesExchangeRateNavigation.CurreExchangeRate);

           

            item.DetailedPayChecks.ForEach(p => p.ArabicAccName = p.CreditChildAccountNavigation.ArabicAccName);



            return item;
        }




      



        //private bool IsDescriptionValid(MainExpensVoucher item)
        //{
        //    if (item.MainExpensVoucherDescription.Length < 4 || item.MainExpensVoucherNumber == null)
        //    {
        //        _errors = "Description Must be atleast 4 Characters";
        //        return false;

        //    }
        //    return true;
        //}

        public string GetNewEXNumber()
        {
            string exnumber = "";

            var LastPoNumber = _context.MainPayChecks.Max(cd => cd.MainPaycheckNumber);
            if (LastPoNumber == null)
                exnumber = "PY00001";
            else
            {
                int lastdigit = 1;
                int.TryParse(LastPoNumber.Substring(2, 5).ToString(), out lastdigit);


                exnumber = "PY" + (lastdigit + 1).ToString().PadLeft(5, '0');
            }



            return exnumber;
        }

        public PaginatedList<MainPayCheck> GetItemsStage(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5)
        {
            List<MainPayCheck> items;

            if (SearchText != "" && SearchText != null)
            {
                items = _context.MainPayChecks.Where(n => n.IsDelete == 0 && n.MainPaycheckStatus == 0 && n.MainPaycheckNumber.Contains(SearchText) || n.MainPaycheckDate.ToString().Contains(SearchText))
                     .Include(f => f.FundsNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                     // .Include(u => u.SystemUsersNavigation)
                     .Include(a => a.DetailedPayChecks)

                    .ToList();


            }
            else
                items = _context.MainPayChecks.Where(d => d.IsDelete == 0 && d.MainPaycheckStatus == 0)
                    .Include(f => f.FundsNavigation)
                     .Include(c => c.CurrenciesNavigation)
                      .Include(x => x.CurrenciesExchangeRateNavigation)
                      .Include(y => y.FiscalYearNavigation)
                      //.Include(u => u.SystemUsersNavigation)
                     .Include(a => a.DetailedPayChecks)

                    .ToList();



            items = DoSort(items, SortProperty, sortOrder);

            PaginatedList<MainPayCheck> retItems = new PaginatedList<MainPayCheck>(items, pageIndex, 10);

            return retItems;
        }
    }
}
