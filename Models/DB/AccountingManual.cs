using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Accounting_Manual")]
    public partial class AccountingManual
    {
        public AccountingManual()
        {
            AccountsCurrencies = new HashSet<AccountsCurrency>().ToList();
            Banks = new HashSet<Bank>();
            CheckExpensVouchers = new HashSet<CheckExpensVoucher>();
            CheckPaycheckVouchers = new HashSet<CheckPaycheckVoucher>();
            DetailedExpensVouchers = new HashSet<DetailedExpensVoucher>();
            DetailedJournalEnteryCreditChildAccountNavigations = new HashSet<DetailedJournalEntery>();
            DetailedJournalEnteryDebitChildAccountNavigations = new HashSet<DetailedJournalEntery>();
            DetailedPayChecks = new HashSet<DetailedPayCheck>();
            Funds = new HashSet<Fund>();
            GeneralLedgers = new HashSet<GeneralLedger>();
            InverseParentAccNumberNavigation = new HashSet<AccountingManual>();
        }

        [Key]
        [StringLength(50)]
        public string AccNumber { get; set; } = null!;
        [StringLength(50)]
        public string ParentAccNumber { get; set; } = null!;
        [StringLength(50)]
        public string AccStatus { get; set; } = null!;
        [StringLength(10)]
        public string AccLevel { get; set; } = null!;
        [StringLength(50)]
        public string ArabicAccName { get; set; } = null!;
        [StringLength(50)]
        public string? EnglishAccName { get; set; }
        [StringLength(50)]
        public string? AccType { get; set; }
        public double? AccMaxBalane { get; set; }
        [StringLength(50)]
        public string? AccKind { get; set; }
        [Column("fiscal_Year")]
        public int FiscalYear { get; set; }
        [Column("final_Account_Type")]
        public int FinalAccountType { get; set; }
        [Column("system_Users")]
        [StringLength(450)]
        public string? SystemUsers { get; set; }

        [ForeignKey("FinalAccountType")]
        [InverseProperty("AccountingManuals")]
        public virtual FinalAccountType FinalAccountTypeNavigation { get; set; } = null!;
        [ForeignKey("FiscalYear")]
        [InverseProperty("AccountingManuals")]
        public virtual FiscalYear FiscalYearNavigation { get; set; } = null!;
        [ForeignKey("ParentAccNumber")]
        [InverseProperty("InverseParentAccNumberNavigation")]
        public virtual AccountingManual ParentAccNumberNavigation { get; set; } = null!;
        [InverseProperty("AccountingManualNavigation")]
        public virtual List<AccountsCurrency> AccountsCurrencies { get; set; }
        [InverseProperty("SubAccountingManualNavigation")]
        public virtual ICollection<Bank> Banks { get; set; }
        [InverseProperty("DebitChildAccountNavigation")]
        public virtual ICollection<CheckExpensVoucher> CheckExpensVouchers { get; set; }
        [InverseProperty("CreditChildAccountNavigation")]
        public virtual ICollection<CheckPaycheckVoucher> CheckPaycheckVouchers { get; set; }
        [InverseProperty("DebitChildAccountNavigation")]
        public virtual ICollection<DetailedExpensVoucher> DetailedExpensVouchers { get; set; }
        [InverseProperty("CreditChildAccountNavigation")]
        public virtual ICollection<DetailedJournalEntery> DetailedJournalEnteryCreditChildAccountNavigations { get; set; }
        [InverseProperty("DebitChildAccountNavigation")]
        public virtual ICollection<DetailedJournalEntery> DetailedJournalEnteryDebitChildAccountNavigations { get; set; }
        [InverseProperty("CreditChildAccountNavigation")]
        public virtual ICollection<DetailedPayCheck> DetailedPayChecks { get; set; }
        [InverseProperty("SubAccountingManualNavigation")]
        public virtual ICollection<Fund> Funds { get; set; }
        [InverseProperty("AccountingManualNavigation")]
        public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; }
        [InverseProperty("ParentAccNumberNavigation")]
        public virtual ICollection<AccountingManual> InverseParentAccNumberNavigation { get; set; }
    }
}
