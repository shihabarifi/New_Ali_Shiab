using System;

namespace POS.Models.DB.Report
{
    public class SpGetReport2
    {
        public string MainPaycheckNumber { get; set; }
        public double MainPaycheckAmount_RLY { get; set; }

        public string CurrenName { get; set; }
        public string CurreType { get; set; }
        public string FundName { get; set; }

        public DateTime MainPaycheckDate { get; set; }
    }
}
