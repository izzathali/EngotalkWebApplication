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

        public async Task<int> DeleteCountry(int id)
        {
            var country = db.Countries.Find(id);

            if (country != null)
            {
                country.IsDeleted = true;
                db.Countries.Update(country);
            }

            return await db.SaveChangesAsync();

        }

        public IEnumerable<CountryM> GetCountries()
        {
            return db.Countries
                .Where(u => u.IsDeleted == false)
                .ToList();
        }

        public async Task<IEnumerable<CountryM>> GetCountriesAsync()
        {
            return await db.Countries
                .Where(u => u.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<CountryM> GetCountryByCountryId(int id)
        {
            return await db.Countries.Where(i => i.IsDeleted == false).FirstOrDefaultAsync(i => i.CountryId == id);
        }

        public async Task<int> UpdateCountry(CountryM country)
        {
            db.Countries.Update(country);
            return await db.SaveChangesAsync();
        }
    }
}
