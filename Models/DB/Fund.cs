using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    public partial class Fund
    {
        public Fund()
        {
            MainExpensVouchers = new HashSet<MainExpensVoucher>();
            MainPayChecks = new HashSet<MainPayCheck>();
        }

        [Key]
        [Column("Funds_Id")]
        public int FundsId { get; set; }
        [StringLength(50)]
        public string? FundName { get; set; }
        public int FundStatus { get; set; }
        [Column("sub_accounting_manual")]
        [StringLength(50)]
        public string? SubAccountingManual { get; set; }
        [Column("system_Users")]
        [StringLength(450)]
        public string SystemUsers { get; set; } = null!;

        [ForeignKey("SubAccountingManual")]
        [InverseProperty("Funds")]
        public virtual AccountingManual? SubAccountingManualNavigation { get; set; }
        [InverseProperty("FundsNavigation")]
        public virtual ICollection<MainExpensVoucher> MainExpensVouchers { get; set; }
        [InverseProperty("FundsNavigation")]
        public virtual ICollection<MainPayCheck> MainPayChecks { get; set; }
    }
}
