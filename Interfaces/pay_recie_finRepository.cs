using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS.Models.DB;

namespace POS.Interfaces
{
   public interface pay_recie_finRepository<TEntity>
    {
        // repo_List List<TEntity>();
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(int id,TEntity entity);
        void Delete(int id);
        IList<TEntity> List(String CategoryName);
        
    }
}
