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
    public class UniversityRepository : IUniversityRepository
    {
        private readonly EngotalkDbContext db;
        public UniversityRepository(EngotalkDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddUniversity(UniversityM university)
        {
            db.Universities.Add(university);

            return await db.SaveChangesAsync();
        }

        public async Task<int> AddUniversityDepartments(UniversityDepartmentsM universityDepartments)
        {
            db.UniversityDepartments.Add(universityDepartments);
            return await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<UniversityM>> GetUniversities()
        {
            return await db.Universities
                .Include(m => m.country)
                .ToListAsync();
        }

        public async Task<IEnumerable<UniversityDepartmentsM>> GetUniversityDepartmentsAsync()
        {
            return await db.UniversityDepartments
                .Include(m => m.university)
                .Include(n =>n.department)
                .Include(u => u.university.country)
                .ToListAsync();
        }
        public List<UniversityDepartmentsM> GetUniversityDepartments()
        {
            //return db.UniversityDepartments
            //   .Include(m => m.university)
            //   .Include(n => n.department)
            //   .Include(u => u.university.country)
            //   .GroupBy(i => new { i.university.country, i.university.University, i.department.Department }).ToList();

            return new List<UniversityDepartmentsM>();
        }
    }
}
