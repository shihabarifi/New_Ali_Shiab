using POS.Data;
using POS.Interfaces;
using POS.Models.DB;


namespace POS.Repositories
{
    public class BackUpDb_Repo: pay_recie_finRepository<BackUpsDb>
    {
        private readonly posDbContext Db;

        public BackUpDb_Repo(posDbContext _Db)
        {
            Db = _Db;
        }

        public void Add(BackUpsDb entity)
        {
            Db.BackUpsDbs.Add(entity);
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var SingleBackUp = Find(id);

            Db.BackUpsDbs.Remove(SingleBackUp);
           // throw new NotImplementedException();
        }

        public BackUpsDb Find(int id)
        {
            var SingleBackUp=Db.BackUpsDbs.Find(id);
            return SingleBackUp;
        }

        public IList<BackUpsDb> List()
        {
            return Db.BackUpsDbs.ToList();
        }

        public IList<BackUpsDb> List(string CategoryName)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, BackUpsDb entity)
        {
            throw new NotImplementedException();
        }
    }
}
