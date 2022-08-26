using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Model
{
    public class UniversityDepartmentsM
    {
        [Key]
        public int UniversityDepartmentId { get; set; }
        public int UniversityId { get; set; }
        public UniversityM? university { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentM? department { get; set; }
        public string UnivDept
        {
            get
            {
                return university.UnivWithCountry + " -- " + this.department.Department;
            }
        }


    }
}
