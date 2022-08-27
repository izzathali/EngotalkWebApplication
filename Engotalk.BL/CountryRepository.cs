using Engotalk.Data;
using Engotalk.IBL;
using Engotalk.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.BL
{
    public class CountryRepository : ICountryRepository
    {
        private readonly EngotalkDbContext db;
        public CountryRepository(EngotalkDbContext _db)
        {
            db = _db;
        }

        public async Task<int> AddCountry(CountryM country)
        {
            db.Countries.Add(country);
            return await db.SaveChangesAsync();
        }

        public IEnumerable<CountryM> GetCountries()
        {
            return db.Countries.ToList();
        }

        public async Task<IEnumerable<CountryM>> GetCountriesAsync()
        {
            return await db.Countries.ToListAsync();
        }
    }
}
