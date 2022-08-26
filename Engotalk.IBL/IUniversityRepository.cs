using Engotalk.Model;
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
        public Task<int> AddUniversityDepartments(UniversityDepartmentsM universityDepartments);

        public Task<IEnumerable<UniversityM>> GetUniversities();
        public Task<IEnumerable<UniversityDepartmentsM>> GetUniversityDepartmentsAsync();
        public List<UniversityDepartmentsM> GetUniversityDepartments();
    }
}
