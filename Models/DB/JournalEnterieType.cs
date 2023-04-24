using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Journal_Enterie_Types")]
    public partial class JournalEnterieType
    {
        public JournalEnterieType()
        {
            MainJournalEnteries = new HashSet<MainJournalEntery>();
        }

        [Key]
        [Column("Journal_Enterie_Types_Id")]
        public int JournalEnterieTypesId { get; set; }
        [StringLength(50)]
        public string? JournalEnteryName { get; set; }

        [InverseProperty("JournalEnterieTypesNavigation")]
        public virtual ICollection<MainJournalEntery> MainJournalEnteries { get; set; }
    }
}
