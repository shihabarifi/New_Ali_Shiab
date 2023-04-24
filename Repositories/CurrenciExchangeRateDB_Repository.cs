using System.Collections.Generic;
using System.Linq;
using POS.Data;
using POS.Interfaces;
using POS.Models.DB;

using POS.Repositories;

namespace POS.Repositories
{
    public class CurrenciExchangeRateDb_Repository : pay_recie_finRepository<CurrenciesExchangeRate>
    {
        public posDbContext Db;
        public CurrenciExchangeRateDb_Repository(posDbContext _Db)
        {
            Db = _Db;
            
            
        }


        public void Add(CurrenciesExchangeRate entity)
        {
            Db.CurrenciesExchangeRates.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _currencyExchange = Find(id);
            Db.CurrenciesExchangeRates.Remove(_currencyExchange);
            Db.SaveChanges();
        }

        public IList<CurrenciesExchangeRate> List()
        {

            return Db.CurrenciesExchangeRates.Where(element=>element.CurreExhhangeStatus==1).ToList();
        }



        public void Update(int id, CurrenciesExchangeRate NewEntity)
        {
            Db.Update(NewEntity);
            Db.SaveChanges();
        }



        public CurrenciesExchangeRate Find(int id)
        {
            var _currencyExchange = Db.CurrenciesExchangeRates.SingleOrDefault(b => b.CurrenciesExchangeRateId == id);
            return _currencyExchange;
        }

        IList<CurrenciesExchangeRate> pay_recie_finRepository<CurrenciesExchangeRate>.List(string CategoryName)
        {
            throw new System.NotImplementedException();
        }
    }
}
