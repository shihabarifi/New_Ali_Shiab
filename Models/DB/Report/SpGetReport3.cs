using System;

namespace POS.Models.DB.Report
{
    public class SpGetReport3
    {
        public string Check_ExpensVoucherNumber { get; set; }
        public string CheckNumber { get; set; }
        public string BankName { get; set; }
        public string CurrenName { get; set; }

        public double CreditAmount_RLY { get; set; }
        public string CurreType { get; set; }
       
        public string ChequesType { get; set; }

        public DateTime CheckDatetime { get; set; }
    }
}
