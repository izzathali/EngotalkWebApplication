using Engotalk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.IBL
{
    public interface ICountryRepository
    {
        public Task<int> AddCountry(CountryM country);
        public Task<IEnumerable<CountryM>> GetCountriesAsync();
        public Task<CountryM> GetCountryByCountryId(int id);
        public IEnumerable<CountryM> GetCountries();
        public Task<int> UpdateCountry(CountryM country);
        public Task<int> DeleteCountry(int id);
    }
}
