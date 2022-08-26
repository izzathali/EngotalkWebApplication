using Engotalk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.IBL
{
    public interface ICourseRepository
    {
        public Task<int> AddCourseTitle(CourseTitleM courseTitle);
        public Task<int> AddCourse(CourseM course);
        public Task<IEnumerable<CourseTitleM>> GetCourseTitles();
        public Task<IEnumerable<CourseM>> GetCourses();

    }
}
