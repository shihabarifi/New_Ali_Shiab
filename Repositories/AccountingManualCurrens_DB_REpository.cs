using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using POS.Models.DB;
using POS.Data;

namespace POS.Repositories
{
    public class AccountingManualCurrens_Db_REpository
    {
        readonly posDbContext Db;

        public AccountingManualCurrens_Db_REpository(posDbContext _Db)
        {
            Db = _Db;
        }
        public IList<AccountsCurrency> AccountsCurrList(string AccountId)
        {
            return Db.AccountsCurrencies.Include(c=>c.CurrenciesNavigation).Where(i => i.AccountingManual == AccountId ).ToList();
        }
    }
}
