using POS.Data;
using POS.Interfaces;
using POS.Models.DB;

namespace POS.Repositories
{
    public class FinalAccountDB_Repo : pay_recie_finRepository<FinalAccountType>
    {
        posDbContext Db;

        public FinalAccountDB_Repo(posDbContext _Db)
        {
            Db = _Db;
        }

        public void Add(FinalAccountType entity)
        {
           Db.FinalAccountTypes.Add(entity);
        }

        public void Delete(int id)
        {
            var SingleObject=Find(id);
            Db.FinalAccountTypes.Remove(SingleObject);
        }

        public FinalAccountType Find(int id)
        {
           var singleAccountType=Db.FinalAccountTypes.Find(id);
            return singleAccountType;
        }

        public IList<FinalAccountType> List()
        {
            return Db.FinalAccountTypes.ToList();
        }

        public IList<FinalAccountType> List(string CategoryName)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, FinalAccountType entity)
        {
            throw new NotImplementedException();
        }
    }
}
