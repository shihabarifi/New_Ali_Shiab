using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Final_Account_Type")]
    public partial class FinalAccountType
    {
        public FinalAccountType()
        {
            AccountingManuals = new HashSet<AccountingManual>();
        }

        [Key]
        [Column("Final_Account_Type_Id")]
        public int FinalAccountTypeId { get; set; }
        [StringLength(50)]
        public string? FinAccType { get; set; }

        [InverseProperty("FinalAccountTypeNavigation")]
        public virtual ICollection<AccountingManual> AccountingManuals { get; set; }
    }
}
