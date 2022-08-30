using Engotalk.Model;
using Engotalk.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.IBL
{
    public interface ICourseRepository
    {
        public Task<int> AddCourse(CourseM course);
        public Task<IEnumerable<CourseM>> GetCourses();
        public Task<IEnumerable<CourseM>> GetCoursesByInstituteType(string InstType);
        public Task<CourseM> GetCoursByCourseId(int id);
        public Task<IEnumerable<DepartmentVM>> GetDepartmentWithCourse(int CountryId);
        public Task<int> UpdateCourse(CourseM course);
        public Task<int> DeleteCourse(int id);

    }
}
