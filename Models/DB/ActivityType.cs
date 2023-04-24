using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Activity_Type")]
    public partial class ActivityType
    {
        public ActivityType()
        {
            TransactionsActivities = new HashSet<TransactionsActivity>();
        }

        [Key]
        [Column("Activit_Type_Id")]
        public int ActivitTypeId { get; set; }
        [StringLength(50)]
        public string? ActivityName { get; set; }

        [InverseProperty("ActivityTypeNavigation")]
        public virtual ICollection<TransactionsActivity> TransactionsActivities { get; set; }
    }
}
