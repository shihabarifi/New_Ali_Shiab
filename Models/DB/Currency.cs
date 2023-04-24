using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    public partial class Currency
    {
        public Currency()
        {
            AccountsCurrencies = new HashSet<AccountsCurrency>();
            CheckExpensVouchers = new HashSet<CheckExpensVoucher>();
            CheckPaycheckVouchers = new HashSet<CheckPaycheckVoucher>();
            CurrenciesExchangeRates = new HashSet<CurrenciesExchangeRate>();
            DetailedJournalEnteries = new HashSet<DetailedJournalEntery>();
            GeneralLedgers = new HashSet<GeneralLedger>();
            MainExpensVouchers = new HashSet<MainExpensVoucher>();
            MainPayChecks = new HashSet<MainPayCheck>();
        }

        [Key]
        [Column("Currencies_Id")]
        public int CurrenciesId { get; set; }
        [StringLength(50)]
        public string? CurrenName { get; set; }
        [StringLength(50)]
        public string? CurreType { get; set; }
        [StringLength(50)]
        public string? CurreSymbol { get; set; }
        [StringLength(50)]
        public string? CrreChangeName { get; set; }
        [Column("system_Users")]
        [StringLength(450)]
        public string? SystemUsers { get; set; }
        public int? CurrStatus { get; set; }

        [InverseProperty("CurrenciesNavigation")]
        public virtual ICollection<AccountsCurrency> AccountsCurrencies { get; set; }
        [InverseProperty("CurrenciesNavigation")]
        public virtual ICollection<CheckExpensVoucher> CheckExpensVouchers { get; set; }
        [InverseProperty("CurrenciesNavigation")]
        public virtual ICollection<CheckPaycheckVoucher> CheckPaycheckVouchers { get; set; }
        [InverseProperty("CurrenciesNavigation")]
        public virtual ICollection<CurrenciesExchangeRate> CurrenciesExchangeRates { get; set; }
        [InverseProperty("CurrenciesNavigation")]
        public virtual ICollection<DetailedJournalEntery> DetailedJournalEnteries { get; set; }
        [InverseProperty("CurrenciesNavigation")]
        public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; }
        [InverseProperty("CurrenciesNavigation")]
        public virtual ICollection<MainExpensVoucher> MainExpensVouchers { get; set; }
        [InverseProperty("CurrenciesNavigation")]
        public virtual ICollection<MainPayCheck> MainPayChecks { get; set; }
    }
}
