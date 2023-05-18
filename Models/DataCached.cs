using Microsoft.Extensions.Caching.Memory;
using POS.Data;
using POS.Models.DB;
using POS.Models.DbContextDir;

namespace POS.Models
{

    public static class DataCache
    {
        private static readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());

        static DataCache()
        {
            // Fetch the data from the database and store it in the cache when the class is first accessed
            IEnumerable<FiscalYear> cachedData = FetchDataFromDatabase();
            _cache.Set("FiscalYearKey", cachedData);
        }

        public static IEnumerable<FiscalYear> GetCachedData()
        {
            // Retrieve the data from the cache
            if (_cache.TryGetValue("FiscalYearKey", out IEnumerable<FiscalYear> cachedData))
            {
                return (IEnumerable<FiscalYear>)cachedData;
            }

            // Handle cache miss if necessary
            return Enumerable.Empty<FiscalYear>();
        }

        private static IEnumerable<FiscalYear> FetchDataFromDatabase()
        {
            // Fetch the data from the database and return it
            // Example:
            using (var dbContext = new FinContext())
            {
                return dbContext.FiscalYears.ToList();
            }
        }
    }

    //public static class DataCache
    //{
    //    private static readonly IEnumerable<FiscalYear> _cachedData;

    //    static DataCache()
    //    {
    //        _cachedData = FetchDataFromDatabase();
    //    }

    //    public static IEnumerable<FiscalYear> GetCachedData()
    //    {
    //        return _cachedData;
    //    }

    //    private static IEnumerable<FiscalYear> FetchDataFromDatabase()
    //    {
    //        // Fetch the data from the database and return it
    //        // Example:
    //        using (var dbContext = new FinContext())
    //        {
    //            return dbContext.FiscalYears.ToList();
    //        }
    //    }
    //}

}
