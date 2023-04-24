using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Currencies_Exchange_Rate")]
    public partial class CurrenciesExchangeRate
    {
        public CurrenciesExchangeRate()
        {
            CheckExpensVouchers = new HashSet<CheckExpensVoucher>();
            CheckPaycheckVouchers = new HashSet<CheckPaycheckVoucher>();
            DetailedJournalEnteries = new HashSet<DetailedJournalEntery>();
            GeneralLedgers = new HashSet<GeneralLedger>();
            MainExpensVouchers = new HashSet<MainExpensVoucher>();
            MainPayChecks = new HashSet<MainPayCheck>();
        }

        [Key]
        [Column("Currencies_Exchange_Rate_Id")]
        public int CurrenciesExchangeRateId { get; set; }
        public double? CurreExchangeRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CurreExchangeDate { get; set; }
        public int? CurreExhhangeStatus { get; set; }
        [Column("system_users")]
        [StringLength(450)]
        public string? SystemUsers { get; set; }
        [Column("currencies")]
        public int? Currencies { get; set; }

        [ForeignKey("Currencies")]
        [InverseProperty("CurrenciesExchangeRates")]
        public virtual Currency? CurrenciesNavigation { get; set; }
        [InverseProperty("CurrenciesExchangeRateNavigation")]
        public virtual ICollection<CheckExpensVoucher> CheckExpensVouchers { get; set; }
        [InverseProperty("CurrenciesExchangeRateNavigation")]
        public virtual ICollection<CheckPaycheckVoucher> CheckPaycheckVouchers { get; set; }
        [InverseProperty("CurrenciesExchangeRateNavigation")]
        public virtual ICollection<DetailedJournalEntery> DetailedJournalEnteries { get; set; }
        [InverseProperty("CurrenciesExchangeRateNavigation")]
        public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; }
        [InverseProperty("CurrenciesExchangeRateNavigation")]
        public virtual ICollection<MainExpensVoucher> MainExpensVouchers { get; set; }
        [InverseProperty("CurrenciesExchangeRateNavigation")]
        public virtual ICollection<MainPayCheck> MainPayChecks { get; set; }
    }
}
