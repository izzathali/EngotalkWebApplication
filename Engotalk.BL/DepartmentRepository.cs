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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EngotalkDbContext db;
        public DepartmentRepository(EngotalkDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddDepartment(DepartmentM department)
        {
            db.Departments.Add(department);

            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteDepartment(int id)
        {
            var department = db.Departments.Find(id);

            if (department != null)
            {
                department.IsDeleted = true;
                db.Departments.Update(department);
            }

            return await db.SaveChangesAsync();
        }

        public async Task<DepartmentM> GetDepartmentByDepartmentId(int id)
        {
            return await db.Departments.Where(i => i.IsDeleted == false).FirstOrDefaultAsync(i => i.DepartmentId == id);
        }

        public async Task<IEnumerable<DepartmentM>> GetDepartments()
        {
            return await db.Departments
                .Where(u => u.IsDeleted == false)
                .Include(m => m.university)
                .ToListAsync();
        }

        public async Task<IEnumerable<DepartmentM>> GetDepartmentsByUnivId(int univid)
        {
            return await db.Departments.Where(i => i.UniversityId == univid && i.IsDeleted == false).ToListAsync();

        }

        public async Task<IEnumerable<DepartmentVM>> GetDepartmentsGroupByUniversityAndCountry()
        {
            var model = await db.Departments
               .Where(i =>
               i.IsDeleted == false &&
               i.university.IsDeleted == false &&
               i.university.country.IsDeleted == false
               )
               .GroupBy(o => new
               {
                   Country = o.university.country.CountryName,
                   Unversity = o.university.University
               })
               .Select(g => new DepartmentVM
               {
                   Country = g.Key.Country,
                   University = g.Key.Unversity,
                   DepartmentList = g.Select(d =>
                   new DepartmentVM
                   {
                       DepartmentId = d.DepartmentId,
                       Department= d.Department
                   }).ToList()
               })
               .ToListAsync();

            return model;
        }

        public async Task<int> UpdateDepartment(DepartmentM department)
        {
            db.Departments.Update(department);
            return await db.SaveChangesAsync();
        }
    }
}
