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
        public Task<IEnumerable<DepartmentVM>> GetDepartmentWithCourse(int CountryId);

    }
}
