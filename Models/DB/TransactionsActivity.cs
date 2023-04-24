using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Transactions_Activity")]
    public partial class TransactionsActivity
    {
        [Key]
        [Column("Transactions_Activity_Id")]
        public int TransactionsActivityId { get; set; }
        [Column("activity_type")]
        public int ActivityType { get; set; }
        [Column("general_ledger")]
        public int GeneralLedger { get; set; }
        [Column("main_expens_voucher")]
        [StringLength(50)]
        public string MainExpensVoucher { get; set; } = null!;
        [Column("main_PayCheck")]
        [StringLength(50)]
        public string MainPayCheck { get; set; } = null!;
        [Column("main_journal_enteries")]
        public int MainJournalEnteries { get; set; }
        [Column("check_Paycheck")]
        [StringLength(50)]
        public string CheckPaycheck { get; set; } = null!;
        [Column("check_expens")]
        [StringLength(50)]
        public string CheckExpens { get; set; } = null!;
        [Column("sysyem_Users")]
        [StringLength(450)]
        public string SysyemUsers { get; set; } = null!;

        [ForeignKey("ActivityType")]
        [InverseProperty("TransactionsActivities")]
        public virtual ActivityType ActivityTypeNavigation { get; set; } = null!;
        [ForeignKey("CheckExpens")]
        [InverseProperty("TransactionsActivities")]
        public virtual CheckExpensVoucher CheckExpensNavigation { get; set; } = null!;
        [ForeignKey("CheckPaycheck")]
        [InverseProperty("TransactionsActivities")]
        public virtual CheckPaycheckVoucher CheckPaycheckNavigation { get; set; } = null!;
        [ForeignKey("GeneralLedger")]
        [InverseProperty("TransactionsActivities")]
        public virtual GeneralLedger GeneralLedgerNavigation { get; set; } = null!;
        [ForeignKey("MainExpensVoucher")]
        [InverseProperty("TransactionsActivities")]
        public virtual MainExpensVoucher MainExpensVoucherNavigation { get; set; } = null!;
        [ForeignKey("MainJournalEnteries")]
        [InverseProperty("TransactionsActivities")]
        public virtual MainJournalEntery MainJournalEnteriesNavigation { get; set; } = null!;
        [ForeignKey("MainPayCheck")]
        [InverseProperty("TransactionsActivities")]
        public virtual MainPayCheck MainPayCheckNavigation { get; set; } = null!;
    }
}
