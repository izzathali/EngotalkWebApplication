using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Model
{
    public class DepartmentM
    {
        [Key]
        public int DepartmentId { get; set; }
        [Column(TypeName="nvarchar(250)")]
        [Display(Name="Department")]
        public string Department { get; set; } = string.Empty;
        public int UniversityId { get; set; }
        public UniversityM? university { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<CourseM> courses { get; set; }
    }
}
