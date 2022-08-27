using Engotalk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.IBL
{
    public interface IDepartmentRepository
    {
        public Task<int> AddDepartment(DepartmentM department);
        public Task<IEnumerable<DepartmentM>> GetDepartments();
        public Task<IEnumerable<DepartmentM>> GetDepartmentsByUnivId(int univid);
    }
}
