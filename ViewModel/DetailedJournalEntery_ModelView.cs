using System.Collections.Generic;
using POS.Models.DB;

namespace POS.viewModels
{
    public class DetailedJournalEntery_ModelView
    {

        public int DetailedJournalEnteriesId { get; set; }
        public string MainJournalEnteries { get; set; }
        public string DetailedournalDescription { get; set; }
        public int Currencies { get; set; }
        public string DebitChildAccount { get; set; }
        public string CreditChildAccount { get; set; }
        public double CreditAmountRly { get; set; }
        public double DebittAmountRly { get; set; }
        public double? CreditAmountUdo { get; set; }
        public double? DebittAmountUdo { get; set; }
        public int? CurrenciesExchangeRate { get; set; }

        public List<AccountingManual> CreditChildAccountList { get; set; }
        public List <CurrenciesExchangeRate> CurrenciesExchangeRateList { get; set; }
        public List <Currency> CurrenciesList { get; set; }
        public List <AccountingManual> DebitChildAccountList { get; set; }
    }

}
