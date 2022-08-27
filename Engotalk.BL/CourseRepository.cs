﻿using Engotalk.Data;
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
                .Where(u => u.IsDeleted == false)
                .Include(o => o.department)
                .Include(o => o.department.university)
                .Include(o => o.department.university.country)
                .ToListAsync();
        }

        public async Task<IEnumerable<DepartmentVM>> GetDepartmentWithCourse(int CountryId)
        {
            var model = await db.Courses.Where(i => i.IsDeleted == false && i.department.university.CountryId == CountryId)
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
