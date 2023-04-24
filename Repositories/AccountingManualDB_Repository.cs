using System.Collections.Generic;
using System.Linq;
using POS.Data;
using POS.Interfaces;
using POS.Models.DB;

using POS.Repositories;

namespace POS.Repositories
{
    public class AccountingManualDb_Repository : pay_recie_finRepository<AccountingManual>
    {
        posDbContext Db;

        public AccountingManualDb_Repository(posDbContext _Db)
        {
            Db = _Db;
        }


        public void Add(AccountingManual entity)
        {
            Db.AccountingManuals.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _accountingManual = Find(id);
            Db.AccountingManuals.Remove(_accountingManual);
            Db.SaveChanges();
        }

         IList<AccountingManual> pay_recie_finRepository<AccountingManual>.List()
        {

            return Db.AccountingManuals.ToList();
        }



        public void Update(int id, AccountingManual NewEntity)
        {
            Db.Update(NewEntity);
            Db.SaveChanges();
        }



        public AccountingManual Find(int id)
        {
            var _accountingManual = Db.AccountingManuals.SingleOrDefault(b => b.AccNumber == id.ToString());
            return _accountingManual;
        }
        

        IList<AccountingManual> pay_recie_finRepository<AccountingManual>.List(string CategoryName)
        {
            return Db.AccountingManuals.Where(i => i.AccType == CategoryName && i.AccStatus=="1").ToList();
        }
    }
}
