using Engotalk.Model;
using Engotalk.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.IBL
{
    public interface IUniversityRepository
    {
        public Task<int> AddUniversity(UniversityM university);

        public Task<IEnumerable<UniversityM>> GetUniversities();
        public Task<IEnumerable<UniversityM>> GetUniversitiesByCountryId(int cid);
        public Task<IEnumerable<UniversityM>> GetUniversitiesOrderByLastAdded();

        public Task<IEnumerable<UniversityVM>> GetUniversitiesByCountryIdAndCourse(int cid,string course);
        public Task<IEnumerable<CollegeVM>> GetCollegesByCountryIdAndCourse(int cid,string course);
    }
}
