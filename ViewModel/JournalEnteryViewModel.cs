using System;
using System.Collections.Generic;
using POS.Models.DB;

namespace POS.viewModels
{
    public class JournalEnteryViewModel
    {
        public JournalEnteryViewModel()
        {
            MainJournalEnteries = new List<MainJournalEntery>();
        }
      
        public List<MainJournalEntery> MainJournalEnteries { get; set; }
        public List<bool> MainJournalEnteriesIsStage { get; set; }

       
    }
}
