using POS.Models.DB;
using System.Collections.Generic;
using System.Linq;

using POS.Interfaces;
using POS.Data;

namespace POS.Repositories
{
    public class GeneralLedgerDb_Repoditory:pay_recie_finRepository<GeneralLedger>
    {
        posDbContext Db;

        public GeneralLedgerDb_Repoditory(posDbContext _Db)
        {
            Db = _Db;
        }


        public void Add(GeneralLedger entity)
        {
            // Db.GeneralLedgers.Add(entity);
            var CurrentObject = Db.GeneralLedgers.SingleOrDefault(c => c.MainJournalEnteriesId == entity.MainJournalEnteriesId && c.AccountingManual == entity.AccountingManual);
            if (CurrentObject == null)
            {
                Db.Add(entity);
                 //throw new System.Exception("This journal Entery dosenot Staged At All");
            }
            else
            {
                CurrentObject.TransactionIsStage = entity.TransactionIsStage + 1 != 2 ? entity.TransactionIsStage : 0;
            }
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _GenerlLedger = Find(id);
            Db.GeneralLedgers.Remove(_GenerlLedger);
            Db.SaveChanges();
        }

        public IList<GeneralLedger> List()
        {

            return Db.GeneralLedgers.ToList();
        }



        public void Update(int id, GeneralLedger NewEntity)
        {
            var CurrentObject = Db.GeneralLedgers.SingleOrDefault(c=>c.MainJournalEnteriesId == NewEntity.MainJournalEnteriesId &&c.AccountingManual==NewEntity.AccountingManual);
            if(CurrentObject== null)
            {
                Db.Update(NewEntity);
               // throw new System.Exception("This journal Entery dosenot Staged At All");
            }
            else
            {
                CurrentObject.TransactionIsStage = NewEntity.TransactionIsStage+1 !=2 ?NewEntity.TransactionIsStage:0;
            }
            
             
            Db.SaveChanges();
        }

         

        public GeneralLedger Find(int id)
        {
            var _GenerlLedger = Db.GeneralLedgers.SingleOrDefault(b => b.GeneralLedgerId == id);
            return _GenerlLedger;
        }



        IList<GeneralLedger> pay_recie_finRepository<GeneralLedger>.List()
        {
            return Db.GeneralLedgers.ToList();
        }

        IList<GeneralLedger> pay_recie_finRepository<GeneralLedger>.List(string CategoryName)
        {
            throw new System.NotImplementedException();
        }
    }
}

