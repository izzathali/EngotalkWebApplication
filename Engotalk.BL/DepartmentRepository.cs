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

        public async Task<IEnumerable<DepartmentM>> GetDepartments()
        {
            return await db.Departments.ToListAsync();
        }
    }
}
