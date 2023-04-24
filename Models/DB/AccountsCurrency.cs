using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Accounts_Currencies")]
    public partial class AccountsCurrency
    {
        [Key]
        [Column("Accounts_Currencies_Id")]
        public int AccountsCurrenciesId { get; set; }
        [Column("accounting_manual")]
        [StringLength(50)]
        public string AccountingManual { get; set; } = null!;
        [Column("currencies")]
        public int Currencies { get; set; }
        [Column("opening_Balance")]
        public double? OpeningBalance { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [Column("system_User")]
        [StringLength(450)]
        public string? SystemUser { get; set; }

        [ForeignKey("AccountingManual")]
        [InverseProperty("AccountsCurrencies")]
        public virtual AccountingManual AccountingManualNavigation { get; set; } = null!;
        [ForeignKey("Currencies")]
        [InverseProperty("AccountsCurrencies")]
        public virtual Currency CurrenciesNavigation { get; set; } = null!;
    }
}
