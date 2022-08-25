using Engotalk.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Data
{
    public class EngotalkDbContext : DbContext
    {
        public EngotalkDbContext(DbContextOptions<EngotalkDbContext> options) : base(options)
        {

        }

        public DbSet<CountryM> Countries { get; set; }
        public DbSet<DepartmentM> Departments { get; set; }
        public DbSet<CourseTitleM> CourseTitles { get; set; }
        public DbSet<UniversityM> Universities { get; set; }
        public DbSet<UniversityDepartmentsM> UniversityDepartments { get; set; }
        public DbSet<CourseM> Courses { get; set; }

    }
}
