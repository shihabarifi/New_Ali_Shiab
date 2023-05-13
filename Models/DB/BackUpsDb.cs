using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("BackUpsDB")]
    public partial class BackUpsDb
    {
        [Key]
        [Column("Backup_Id")]
        public int BackupId { get; set; }
        [Column("system_users")]
        public string? SystemUsers { get; set; }
        public string? Filename { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StampDate { get; set; }
    }
}
