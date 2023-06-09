﻿using POS.Data;
using POS.Interfaces;
using POS.Models.DB;

namespace POS.Repositories
{
    public class CompanyProfile_Repo : pay_recie_finRepository<CompanyProfile>
    {
        posDbContext Db;

        public CompanyProfile_Repo(posDbContext _Db)
        {
            Db = _Db;
        }

        public void Add(CompanyProfile entity)
        {
           Db.CompanyProfiles.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var singleProfile=Find(id);
            if (singleProfile != null)
            {
                Db.CompanyProfiles.Remove(singleProfile);
                Db.SaveChanges();
            }

        }

        public CompanyProfile Find(int id)
        {
            return Db.CompanyProfiles.Find(id);
        }

        public IList<CompanyProfile> List()
        {
            return Db.CompanyProfiles.ToList();
        }

        public IList<CompanyProfile> List(string CategoryName)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, CompanyProfile entity)
        {
            Db.CompanyProfiles.Update(entity);
            Db.SaveChanges();
        }
    }
}
