using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    public partial class Bank
    {
        public Bank()
        {
            CheckExpensVouchers = new HashSet<CheckExpensVoucher>();
            CheckPaycheckVouchers = new HashSet<CheckPaycheckVoucher>();
        }

        [Key]
        [Column("Bank_Id")]
        public int BankId { get; set; }
        [StringLength(50)]
        public string BankName { get; set; } = null!;
        public int? BankStatus { get; set; }
        [Column("sub_accounting_manual")]
        [StringLength(50)]
        public string SubAccountingManual { get; set; } = null!;
        [Column("system_Users")]
        [StringLength(450)]
        public string SystemUsers { get; set; } = null!;

        [ForeignKey("SubAccountingManual")]
        [InverseProperty("Banks")]
        public virtual AccountingManual SubAccountingManualNavigation { get; set; } = null!;
        [InverseProperty("BanksNavigation")]
        public virtual ICollection<CheckExpensVoucher> CheckExpensVouchers { get; set; }
        [InverseProperty("BanksNavigation")]
        public virtual ICollection<CheckPaycheckVoucher> CheckPaycheckVouchers { get; set; }
    }
}
