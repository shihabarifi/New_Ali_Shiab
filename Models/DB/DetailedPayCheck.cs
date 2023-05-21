using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Detailed_PayCheck")]
    public partial class DetailedPayCheck
    {
        [Key]
        [Column("Detailed_PayCheck_Id")]
        public int DetailedPayCheckId { get; set; }

        [Column("main_paycheck")]
        [StringLength(50)]
        public string MainPaycheck { get; set; } = null!;

        [Range(1, 10000000, ErrorMessage = "AmountRly should be greater than 0")]
        [DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        [Column("DetailedPaycheckAmount_RLY")]
        public double DetailedPaycheckAmountRly { get; set; }

        [Range(1, 10000000, ErrorMessage = "AmountUdo should be greater than 0")]
        [DisplayFormat(DataFormatString = "{0:0.000}", ApplyFormatInEditMode = true)]
        [Column("DetailedPaycheckAmount_UDO")]
        public double? DetailedPaycheckAmountUdo { get; set; }
        [StringLength(50)]
        public string? DetailedPaycheckrDescription { get; set; }
        [StringLength(50)]
        public string CreditChildAccount { get; set; } = null!;


        [ForeignKey("CreditChildAccount")]
        [InverseProperty("DetailedPayChecks")]
        public virtual AccountingManual CreditChildAccountNavigation { get; set; } = null!;
        [ForeignKey("MainPaycheck")]
        [InverseProperty("DetailedPayChecks")]
        public virtual MainPayCheck MainPaycheckNavigation { get; set; } = null!;

        [NotMapped]
        [MaxLength(100)]
        public string ArabicAccName { get; set; } = "";

        [NotMapped]
        public bool IsDeleted { get; set; } = false;
    }
}
