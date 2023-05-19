using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Main_Expens_Voucher")]
    public partial class MainExpensVoucher
    {
        public MainExpensVoucher()
        {
            DetailedExpensVouchers = new HashSet<DetailedExpensVoucher>().ToList();
            GeneralLedgers = new HashSet<GeneralLedger>();
            TransactionsActivities = new HashSet<TransactionsActivity>();
        }

        [Key]
        [Column("Main_ExpensVoucher_Number")]
        [StringLength(50)]
        public string MainExpensVoucherNumber { get; set; } = null!;
        [Column("currencies_exchange_rate")]
        public int CurrenciesExchangeRate { get; set; }
        [Column("system_users")]
        [StringLength(450)]
        public string SystemUsers { get; set; } = null!;
        [Column("fiscal_year")]
        public int FiscalYear { get; set; }
        [Column("funds")]
        public int Funds { get; set; }
        [Column("currencies")]
        public int Currencies { get; set; }
        public int MainExpensVoucherStatus { get; set; }

        [Range(1, 10000000, ErrorMessage = "AmountRly should be greater than 0")]
        [DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        [Column("MainExpensVoucherAmount_RLY")]
        public double MainExpensVoucherAmountRly { get; set; }


        [Column("MainExpensVoucherAmount_UDO")]
        [Range(1, 10000000, ErrorMessage = "AmountUDO should be greater than 0")]
        [DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        public double? MainExpensVoucherAmountUdo { get; set; }
        public int? ReferenceNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MainExpensVoucherDate { get; set; }= DateTime.Now.Date;
        public int? IsDelete { get; set; }

        [ForeignKey("CurrenciesExchangeRate")]
        [InverseProperty("MainExpensVouchers")]
        public virtual CurrenciesExchangeRate CurrenciesExchangeRateNavigation { get; set; } = null!;
        [ForeignKey("Currencies")]
        [InverseProperty("MainExpensVouchers")]
        public virtual Currency CurrenciesNavigation { get; set; } = null!;
        [ForeignKey("FiscalYear")]
        [InverseProperty("MainExpensVouchers")]
        public virtual FiscalYear FiscalYearNavigation { get; set; } = null!;
        [ForeignKey("Funds")]
        [InverseProperty("MainExpensVouchers")]
        public virtual Fund FundsNavigation { get; set; } = null!;
        [InverseProperty("MainExpensVoucherNumberNavigation")]
        public virtual List<DetailedExpensVoucher> DetailedExpensVouchers { get; set; }
        [InverseProperty("MainExpensVoucherNumberNavigation")]
        public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; }
        [InverseProperty("MainExpensVoucherNavigation")]
        public virtual ICollection<TransactionsActivity> TransactionsActivities { get; set; }
    }
}
