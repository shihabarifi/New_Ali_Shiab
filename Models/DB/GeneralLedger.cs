using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("General_Ledger")]
    public partial class GeneralLedger
    {
        public GeneralLedger()
        {
            TransactionsActivities = new HashSet<TransactionsActivity>();
        }

        [Key]
        [Column("General_Ledger_Id")]
        public int GeneralLedgerId { get; set; }
        [Column("system_Users")]
        [StringLength(450)]
        public string? SystemUsers { get; set; }
        [Column("fiscal_year")]
        public int? FiscalYear { get; set; }
        [Column("accounting_manual")]
        [StringLength(50)]
        public string? AccountingManual { get; set; }
        [Column("currencies")]
        public int? Currencies { get; set; }
        [Column("currencies_exchange_rate")]
        public int CurrenciesExchangeRate { get; set; }
        [Column("Transaction_Is_Stage")]
        public int? TransactionIsStage { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? GenLedgerDateTime { get; set; }
        [Column("CreditAmount_RLY")]
        public double? CreditAmountRly { get; set; }
        [Column("DebittAmount_RLY")]
        public double? DebittAmountRly { get; set; }
        [Column("CreditAmountWith_TransCurre")]
        public double? CreditAmountWithTransCurre { get; set; }
        [Column("DebitAmountWith_TransCurre")]
        public double? DebitAmountWithTransCurre { get; set; }
        [StringLength(50)]
        public string? TransactionName { get; set; }
        [Column("Main_Expens_Voucher_Number")]
        [StringLength(50)]
        public string? MainExpensVoucherNumber { get; set; }
        [Column("Main_Journal_Enteries_id")]
        public int? MainJournalEnteriesId { get; set; }
        [Column("Main_PayCheck_Number")]
        [StringLength(50)]
        public string? MainPayCheckNumber { get; set; }
        [Column("Check_ExpensVoucher_Number")]
        [StringLength(50)]
        public string? CheckExpensVoucherNumber { get; set; }
        [Column("Check_PayCheckVoucher_Number")]
        [StringLength(50)]
        public string? CheckPayCheckVoucherNumber { get; set; }

        [ForeignKey("AccountingManual")]
        [InverseProperty("GeneralLedgers")]
        public virtual AccountingManual? AccountingManualNavigation { get; set; }
        [ForeignKey("CheckExpensVoucherNumber")]
        [InverseProperty("GeneralLedgers")]
        public virtual CheckExpensVoucher? CheckExpensVoucherNumberNavigation { get; set; }
        [ForeignKey("CheckPayCheckVoucherNumber")]
        [InverseProperty("GeneralLedgers")]
        public virtual CheckPaycheckVoucher? CheckPayCheckVoucherNumberNavigation { get; set; }
        [ForeignKey("CurrenciesExchangeRate")]
        [InverseProperty("GeneralLedgers")]
        public virtual CurrenciesExchangeRate CurrenciesExchangeRateNavigation { get; set; } = null!;
        [ForeignKey("Currencies")]
        [InverseProperty("GeneralLedgers")]
        public virtual Currency? CurrenciesNavigation { get; set; }
        [ForeignKey("FiscalYear")]
        [InverseProperty("GeneralLedgers")]
        public virtual FiscalYear? FiscalYearNavigation { get; set; }
        [ForeignKey("MainExpensVoucherNumber")]
        [InverseProperty("GeneralLedgers")]
        public virtual MainExpensVoucher? MainExpensVoucherNumberNavigation { get; set; }
        [ForeignKey("MainJournalEnteriesId")]
        [InverseProperty("GeneralLedgers")]
        public virtual MainJournalEntery? MainJournalEnteries { get; set; }
        [ForeignKey("MainPayCheckNumber")]
        [InverseProperty("GeneralLedgers")]
        public virtual MainPayCheck? MainPayCheckNumberNavigation { get; set; }
        [InverseProperty("GeneralLedgerNavigation")]
        public virtual ICollection<TransactionsActivity> TransactionsActivities { get; set; }
    }
}
