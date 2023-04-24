using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Detailed_Journal_Enteries")]
    public partial class DetailedJournalEntery
    {
        [Key]
        [Column("Detailed_Journal_Enteries_Id")]
        public int DetailedJournalEnteriesId { get; set; }
        [Column("main_journal_enteries")]
        public int? MainJournalEnteries { get; set; }
        [StringLength(50)]
        public string? DetailedournalDescription { get; set; }
        [Column("currencies")]
        public int? Currencies { get; set; }
        [StringLength(50)]
        public string? DebitChildAccount { get; set; }
        [StringLength(50)]
        public string? CreditChildAccount { get; set; }
        [Column("CreditAmount_RLY")]
        public double? CreditAmountRly { get; set; }
        [Column("DebittAmount_RLY")]
        public double? DebittAmountRly { get; set; }
        [Column("CreditAmount_UDO")]
        public double? CreditAmountUdo { get; set; }
        [Column("DebittAmount_UDO")]
        public double? DebittAmountUdo { get; set; }
        [Column("currencies_exchange_rate")]
        public int? CurrenciesExchangeRate { get; set; }

        [ForeignKey("CreditChildAccount")]
        [InverseProperty("DetailedJournalEnteryCreditChildAccountNavigations")]
        public virtual AccountingManual? CreditChildAccountNavigation { get; set; }
        [ForeignKey("CurrenciesExchangeRate")]
        [InverseProperty("DetailedJournalEnteries")]
        public virtual CurrenciesExchangeRate? CurrenciesExchangeRateNavigation { get; set; }
        [ForeignKey("Currencies")]
        [InverseProperty("DetailedJournalEnteries")]
        public virtual Currency? CurrenciesNavigation { get; set; }
        [ForeignKey("DebitChildAccount")]
        [InverseProperty("DetailedJournalEnteryDebitChildAccountNavigations")]
        public virtual AccountingManual? DebitChildAccountNavigation { get; set; }
        [ForeignKey("MainJournalEnteries")]
        [InverseProperty("DetailedJournalEnteries")]
        public virtual MainJournalEntery? MainJournalEnteriesNavigation { get; set; }
    }
}
