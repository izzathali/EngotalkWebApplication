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
    public class CourseRepository : ICourseRepository
    {
        private readonly EngotalkDbContext db;
        public CourseRepository(EngotalkDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddCourse(CourseM course)
        {
            db.Courses.Add(course);

            return await db.SaveChangesAsync();
        }

        public async Task<int> AddCourseTitle(CourseTitleM courseTitle)
        {
            db.CourseTitles.Add(courseTitle);

            return await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseM>> GetCourses()
        {
            return await db.Courses
                .Include(m => m.universityDepartments)
                .Include(x => x.universityDepartments.university)
                .Include(p => p.universityDepartments.department)
                .Include(o => o.courseTitle)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseTitleM>> GetCourseTitles()
        {
            return await db.CourseTitles.ToListAsync();
        }
    }
}
