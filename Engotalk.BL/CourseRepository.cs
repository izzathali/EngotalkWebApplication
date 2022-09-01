using Engotalk.Data;
using Engotalk.IBL;
using Engotalk.Model;
using Engotalk.ViewModel;
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

        public async Task<int> DeleteCourse(int id)
        {
            var course = db.Courses.Find(id);

            if (course != null)
            {
                course.IsDeleted = true;
                db.Courses.Update(course);
            }

            return await db.SaveChangesAsync();
        }

        public async Task<CourseM> GetCoursByCourseId(int id)
        {
            return await db.Courses
                .Where(i => i.IsDeleted == false)
                .Include(u => u.department)
                .Include(u => u.department.university)
                .Include(u => u.department.university.country)
                .FirstOrDefaultAsync(i => i.CourseId == id);
        }

        public async Task<IEnumerable<CourseM>> GetCourses()
        {
            return await db.Courses
                .Where(u =>
                u.IsDeleted == false &&
                u.department.IsDeleted == false &&
                u.department.university.IsDeleted == false &&
                u.department.university.country.IsDeleted == false
                )
                .Include(o => o.department)
                .Include(o => o.department.university)
                .Include(o => o.department.university.country)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseM>> GetCoursesByInstituteType(string InstType)
        {
            return await db.Courses
                .Where(u =>
                u.IsDeleted == false &&
                u.department.IsDeleted == false &&
                u.department.university.IsDeleted == false &&
                u.department.university.country.IsDeleted == false &&
                u.department.university.UniversityType == InstType
                )
                .Include(o => o.department)
                .Include(o => o.department.university)
                .Include(o => o.department.university.country)
                .ToListAsync();
        }

        public async Task<IEnumerable<CourseVM>> GetCoursesGroupByCountryAndUniversityAndDepartment()
        {
            var model = await db.Courses
               .Where(u =>
                u.IsDeleted == false &&
                u.department.IsDeleted == false &&
                u.department.university.IsDeleted == false &&
                u.department.university.country.IsDeleted == false
               )
               .GroupBy(o => new
               {
                   Country = o.department.university.country.CountryName,
                   University = o.department.university.University,
                   Location = o.department.university.Location,
                   Established = o.department.university.Established,
                   ExamsAccepted = o.department.university.ExamsAccepted,
                   Department = o.department.Department,
               })
               .Select(g => new CourseVM
               {
                   Country = g.Key.Country,
                   Univ = g.Select(u => new UniversityVM
                   {
                       University = g.Key.University,
                       Location = g.Key.Location,
                       Established = g.Key.Established,
                       ExamsAccepted = g.Key.ExamsAccepted
                   }).SingleOrDefault(),
                   Department = g.Key.Department,
                   courses = g.Select(i => new CourseVM
                   {
                       CourseId = i.CourseId,
                       Course = i.Course,
                       GREScore = i.GREScore,
                       IELTSBand = i.IELTSBand,
                       TOEFLScore = i.TOEFLScore,
                       SATScore = i.SATScore,
                       CourseDuration = i.CourseDuration,
                       Cost = i.Cost
                   }).ToList()
               }).ToListAsync();

            return model;
        }

    public async Task<IEnumerable<DepartmentVM>> GetDepartmentWithCourse(int CountryId)
    {
        var model = await db.Courses
            .Where(i =>
            i.IsDeleted == false &&
            i.department.IsDeleted == false &&
            i.department.university.IsDeleted == false &&
            i.department.university.country.IsDeleted == false &&
            i.department.university.CountryId == CountryId
            )
            .GroupBy(o => new
            {
                Department = o.department.Department,
                Course = o.Course
            })
            .Select(g => new DepartmentVM
            {
                Department = g.Key.Department,
                Course = g.Key.Course
            })
            .ToListAsync();

        return model;
    }

    public async Task<int> UpdateCourse(CourseM course)
    {
        db.Courses.Update(course);
        return await db.SaveChangesAsync();
    }
}
}
