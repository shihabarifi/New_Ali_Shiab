using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace POS.Models.DB
{
    [Table("Main_Journal_Enteries")]
    public partial class MainJournalEntery
    {
        public MainJournalEntery()
        {
            DetailedJournalEnteries = new HashSet<DetailedJournalEntery>().ToList();
            GeneralLedgers = new HashSet<GeneralLedger>();
            TransactionsActivities = new HashSet<TransactionsActivity>();
        }

        [Key]
        [Column("Main_Journal_Enteries_Id")]
        public int MainJournalEnteriesId { get; set; }
        [Column("Main_Joural_Ent_Number")]
        [StringLength(50)]
        public string MainJouralEntNumber { get; set; } = null!;
        [Column("journal_enterie_types")]
        public int? JournalEnterieTypes { get; set; }
        [Column("fiscal_year")]
        public int? FiscalYear { get; set; }
        public double? MainJournalEnteriesAmount { get; set; }
        public int MainournalEnteriesStatus { get; set; }
        public int MainJournalReferenceNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? MainJournalDateTime { get; set; }
        [StringLength(1000)]
        public string? MainPaycheckGlobalNote { get; set; }
        [Column("isStage")]
        public int IsStage { get; set; }
        [Column("isDeleted")]
        public int? IsDeleted { get; set; }
        [Column("system_users")]
        [StringLength(450)]
        public string? SystemUsers { get; set; }

        [ForeignKey("FiscalYear")]
        [InverseProperty("MainJournalEnteries")]
        public virtual FiscalYear? FiscalYearNavigation { get; set; }
        [ForeignKey("JournalEnterieTypes")]
        [InverseProperty("MainJournalEnteries")]
        public virtual JournalEnterieType? JournalEnterieTypesNavigation { get; set; }
        [InverseProperty("MainJournalEnteriesNavigation")]
        public virtual List<DetailedJournalEntery> DetailedJournalEnteries { get; set; }
        [InverseProperty("MainJournalEnteries")]
        public virtual ICollection<GeneralLedger> GeneralLedgers { get; set; }
        [InverseProperty("MainJournalEnteriesNavigation")]
        public virtual ICollection<TransactionsActivity> TransactionsActivities { get; set; }
    }
}
