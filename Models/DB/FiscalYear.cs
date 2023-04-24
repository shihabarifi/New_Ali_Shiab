using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Fiscal_Year")]
    public partial class FiscalYear
    {
        public FiscalYear()
        {
            AccountingManuals = new HashSet<AccountingManual>();
            CheckExpensVouchers = new HashSet<CheckExpensVoucher>();
            CheckPaycheckVouchers = new HashSet<CheckPaycheckVoucher>();
            GeneralLedgers = new HashSet<GeneralLedger>();
            MainExpensVouchers = new HashSet<MainExpensVoucher>();
            MainJournalEnteries = new HashSet<MainJournalEntery>();
            MainPayChecks = new HashSet<MainPayCheck>();
        }

        [Key]
        [Column("Fiscal_Year_Id")]
        public int FiscalYearId { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [StringLength(50)]
        public string? FiscalYearName { get; set; }
        public int? FiscalYearStatus { get; set; }
        [Column("system_Users")]
        [StringLength(450)]
        public string? SystemUsers { get; set; }

        [InverseProperty("FiscalYearNavigation")]
        public virtual ICollection<AccountingManual> AccountingManuals { get; set; }
        [InverseProperty("FiscalYearNavigation")]
        public virtual ICollection<CheckExpensVoucher> CheckExpensVouchers { get; set; }
        [InverseProperty("FiscalYearNavigation")]
        public virtual ICollection<CheckPaycheckVoucher> CheckPaycheckVouchers { get; set; }
        [InverseProperty("FiscalYearNavigation")]
        public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; }
        [InverseProperty("FiscalYearNavigation")]
        public virtual ICollection<MainExpensVoucher> MainExpensVouchers { get; set; }
        [InverseProperty("FiscalYearNavigation")]
        public virtual ICollection<MainJournalEntery> MainJournalEnteries { get; set; }
        [InverseProperty("FiscalYearNavigation")]
        public virtual ICollection<MainPayCheck> MainPayChecks { get; set; }
    }
}
