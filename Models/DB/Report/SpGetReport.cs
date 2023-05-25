using System;
using System.Collections.Generic;
using POS.Models.DB;

namespace POS.Models.DB.Report
{
    public class SpGetReport
    {
         
        public string Main_ExpensVoucher_Number { get; set; } 
        public double MainExpensVoucherAmount_RLY { get; set; } 
        
        public string CurrenName { get; set; } 
        public string CurreType { get; set; } 
        public string FundName { get; set; } 

        public DateTime MainExpensVoucherDate { get; set; }

       

    }
}
