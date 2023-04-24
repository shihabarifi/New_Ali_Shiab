using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Company_Profile")]
    public partial class CompanyProfile
    {
        [Key]
        [Column("Company_Profile_Id")]
        public int CompanyProfileId { get; set; }
        [StringLength(50)]
        public string? CompanyName { get; set; }
        [StringLength(50)]
        public string? PhoneNumber { get; set; }
        [StringLength(50)]
        public string? CompanyIcon { get; set; }
        [StringLength(50)]
        public string? UserEmail { get; set; }
        [Column("system_Users")]
        [StringLength(450)]
        public string? SystemUsers { get; set; }
    }
}
