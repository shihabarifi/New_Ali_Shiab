using System.Collections.Generic;
using System.Linq;
using POS.Data;
using POS.Interfaces;
using POS.Models.DB;

using POS.Repositories;

namespace POS.Repositories
{
    public class FiscalYearsDb_Repository : pay_recie_finRepository<FiscalYear>
    {
        posDbContext Db;

        public FiscalYearsDb_Repository(posDbContext _Db)
        {
            Db = _Db;
        }


        public void Add(FiscalYear entity)
        {
            Db.FiscalYears.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _fiscalYear = Find(id);
            Db.FiscalYears.Remove(_fiscalYear);
            Db.SaveChanges();
        }

        public IList<FiscalYear> List()
        {

            return Db.FiscalYears.ToList();
        }



        public void Update(int id, FiscalYear NewEntity)
        {
            Db.Update(NewEntity);
            Db.SaveChanges();
        }



        public FiscalYear Find(int id)
        {
            var _fiscalYear = Db.FiscalYears.SingleOrDefault(b => b.FiscalYearId == id);
            return _fiscalYear;
        }

        IList<FiscalYear> pay_recie_finRepository<FiscalYear>.List(string CategoryName)
        {
            throw new System.NotImplementedException();
        }
    }
}