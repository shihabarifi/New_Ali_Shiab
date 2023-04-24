using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Detailed_Expens_Voucher")]
    public partial class DetailedExpensVoucher
    {
        [Key]
        [Column("Detailed_Expens_Voucher_Id")]
        public int DetailedExpensVoucherId { get; set; }
        [Column("main_expens_voucher_number")]
        [StringLength(50)]
        public string MainExpensVoucherNumber { get; set; } = null!;
        [Column("DetailedExpensVoucherAmount_RLY")]
        public double DetailedExpensVoucherAmountRly { get; set; }
        [Column("DetailedExpensVoucherAmount_UDO")]
        public double? DetailedExpensVoucherAmountUdo { get; set; }
        [StringLength(50)]
        public string? DetailedExpensVoucherAmountDescription { get; set; }
        [StringLength(50)]
        public string DebitChildAccount { get; set; } = null!;

        [ForeignKey("DebitChildAccount")]
        [InverseProperty("DetailedExpensVouchers")]
        public virtual AccountingManual DebitChildAccountNavigation { get; set; } = null!;
        [ForeignKey("MainExpensVoucherNumber")]
        [InverseProperty("DetailedExpensVouchers")]
        public virtual MainExpensVoucher MainExpensVoucherNumberNavigation { get; set; } = null!;

        [NotMapped]
        [MaxLength(100)]
        public string ArabicAccName { get; set; } = "";

        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
