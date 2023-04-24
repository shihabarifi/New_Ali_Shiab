using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Check_Expens_Voucher")]
    public partial class CheckExpensVoucher
    {
        public CheckExpensVoucher()
        {
            GeneralLedgers = new HashSet<GeneralLedger>();
            TransactionsActivities = new HashSet<TransactionsActivity>();
        }

        [Key]
        [Column("Check_ExpensVoucherNumber")]
        [StringLength(50)]
        public string CheckExpensVoucherNumber { get; set; } = null!;
        [StringLength(50)]
        public string? CheckNumber { get; set; }
        [Column("banks")]
        public int Banks { get; set; }
        [Column("fiscal_Year")]
        public int FiscalYear { get; set; }
        [Column("Check_Expend_cheques")]
        public int? CheckExpendCheques { get; set; }
        public int? CheckStatus { get; set; }
        public int? ReferenceNumber { get; set; }
        [StringLength(50)]
        public string? ChequesType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ChequesDate { get; set; }
        [StringLength(50)]
        public string? CheckDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CheckDatetime { get; set; }
        [Column("currencies")]
        public int Currencies { get; set; }
        [StringLength(50)]
        public string? DebitChildAccount { get; set; }
        [Column("CreditAmount_RLY")]
        public double CreditAmountRly { get; set; }
        [Column("DebittAmount_RLY")]
        public double DebittAmountRly { get; set; }
        [Column("CreditAmount_UDO")]
        public double? CreditAmountUdo { get; set; }
        [Column("DebittAmount_UDO")]
        public double? DebittAmountUdo { get; set; }
        [Column("currencies_exchange_rate")]
        public int CurrenciesExchangeRate { get; set; }
        [Column("system_Users")]
        [StringLength(450)]
        public string SystemUsers { get; set; } = null!;
        public int? IsDelete { get; set; }

        [ForeignKey("Banks")]
        [InverseProperty("CheckExpensVouchers")]
        public virtual Bank BanksNavigation { get; set; } = null!;
        [ForeignKey("CurrenciesExchangeRate")]
        [InverseProperty("CheckExpensVouchers")]
        public virtual CurrenciesExchangeRate CurrenciesExchangeRateNavigation { get; set; } = null!;
        [ForeignKey("Currencies")]
        [InverseProperty("CheckExpensVouchers")]
        public virtual Currency CurrenciesNavigation { get; set; } = null!;
        [ForeignKey("DebitChildAccount")]
        [InverseProperty("CheckExpensVouchers")]
        public virtual AccountingManual? DebitChildAccountNavigation { get; set; }
        [ForeignKey("FiscalYear")]
        [InverseProperty("CheckExpensVouchers")]
        public virtual FiscalYear FiscalYearNavigation { get; set; } = null!;


        [NotMapped]
        [MaxLength(100)]
        public string ArabicAccName { get; set; } = "";

        [NotMapped]
        public bool IsDeleted { get; set; } = false;

        [InverseProperty("CheckExpensVoucherNumberNavigation")]
        public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; }
        [InverseProperty("CheckExpensNavigation")]
        public virtual ICollection<TransactionsActivity> TransactionsActivities { get; set; }
    }
}
