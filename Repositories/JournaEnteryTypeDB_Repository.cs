using System.Collections.Generic;
using System.Linq;
using POS.Data;
using POS.Interfaces;
using POS.Models.DB;


namespace POS.Repositories
{
    public class JournaEnteryTypeDb_Repository : pay_recie_finRepository<JournalEnterieType>
    {
        posDbContext Db;

        public JournaEnteryTypeDb_Repository(posDbContext _Db)
        {
            Db = _Db;
        }


        public void Add(JournalEnterieType entity)
        {
            Db.JournalEnterieTypes.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _journalEnteryType = Find(id);
            Db.JournalEnterieTypes.Remove(_journalEnteryType);
            Db.SaveChanges();
        }

        public IList<JournalEnterieType> List()
        {

            return Db.JournalEnterieTypes.ToList();
        }



        public void Update(int id, JournalEnterieType NewEntity)
        {
            Db.Update(NewEntity);
            Db.SaveChanges();
        }



        public JournalEnterieType Find(int id)
        {
            var _journalEnteryType = Db.JournalEnterieTypes.SingleOrDefault(b => b.JournalEnterieTypesId == id);
            return _journalEnteryType;
        }

        IList<JournalEnterieType> pay_recie_finRepository<JournalEnterieType>.List(string CategoryName)
        {
            throw new System.NotImplementedException();
        }
    }
}
