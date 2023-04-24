using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Main_PayCheck")]
    public partial class MainPayCheck
    {
        public MainPayCheck()
        {
            DetailedPayChecks = new HashSet<DetailedPayCheck>().ToList();
            GeneralLedgers = new HashSet<GeneralLedger>();
            TransactionsActivities = new HashSet<TransactionsActivity>();
        }

        [Key]
        [StringLength(50)]
        public string MainPaycheckNumber { get; set; } = null!;
        [Column("system_users")]
        [StringLength(450)]
        public string SystemUsers { get; set; } = null!;
        [Column("currencies_exchange_rate")]
        public int? CurrenciesExchangeRate { get; set; }
        [Column("fiscal_year")]
        public int FiscalYear { get; set; }
        [Column("funds")]
        public int Funds { get; set; }
        [Column("currencies")]
        public int Currencies { get; set; }
        public int MainPaycheckStatus { get; set; }
        [Column("MainPaycheckAmount_RLY")]
        public double MainPaycheckAmountRly { get; set; }
        [Column("MainPaycheckAmount_UDO")]
        public double? MainPaycheckAmountUdo { get; set; }
        public int? ReferenceNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MainPaycheckDate { get; set; }
        public int? IsDelete { get; set; }

        [ForeignKey("CurrenciesExchangeRate")]
        [InverseProperty("MainPayChecks")]
        public virtual CurrenciesExchangeRate? CurrenciesExchangeRateNavigation { get; set; }
        [ForeignKey("Currencies")]
        [InverseProperty("MainPayChecks")]
        public virtual Currency CurrenciesNavigation { get; set; } = null!;
        [ForeignKey("FiscalYear")]
        [InverseProperty("MainPayChecks")]
        public virtual FiscalYear FiscalYearNavigation { get; set; } = null!;
        [ForeignKey("Funds")]
        [InverseProperty("MainPayChecks")]
        public virtual Fund FundsNavigation { get; set; } = null!;
        [InverseProperty("MainPaycheckNavigation")]
        public virtual List<DetailedPayCheck> DetailedPayChecks { get; set; }
        [InverseProperty("MainPayCheckNumberNavigation")]
        public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; }
        [InverseProperty("MainPayCheckNavigation")]
        public virtual ICollection<TransactionsActivity> TransactionsActivities { get; set; }
    }
}
