using System.Collections.Generic;
using System.Linq;
using POS.Data;
using POS.Interfaces;
using POS.Models.DB;

using POS.Repositories;

namespace POS.Repositories
{
    public class CurrenciesDb_REpository : pay_recie_finRepository<Currency>
    {
        posDbContext Db;

        public CurrenciesDb_REpository(posDbContext _Db)
        {
            Db = _Db;
        }


        public void Add(Currency entity)
        {
            Db.Currencies.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _currency = Find(id);
            Db.Currencies.Remove(_currency);
            Db.SaveChanges();
        }

        public IList<Currency> List()
        {

            return Db.Currencies.ToList();
        }



        public void Update(int id, Currency NewEntity)
        {
            Db.Update(NewEntity);
            Db.SaveChanges();
        }



        public Currency Find(int id)
        {
            var _currency = Db.Currencies.SingleOrDefault(b => b.CurrenciesId == id);
            return _currency;
        }

        IList<Currency> pay_recie_finRepository<Currency>.List(string CategoryName)
        {
            throw new System.NotImplementedException();
        }
    }
}

