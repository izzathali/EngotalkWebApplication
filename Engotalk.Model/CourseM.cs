using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Model
{
    public class CourseM
    {
        [Key]
        public int CourseId { get; set; }
        [Display(Name="Course Title")]
        public int CourseTitleId { get; set; }
        public CourseTitleM courseTitle { get; set; }
        public int UniversityDepartmentId { get; set; }
        public UniversityDepartmentsM universityDepartments { get; set; }
        public decimal Band { get; set; }
        public decimal Cost { get; set; }
        [Column(TypeName ="nvarchar(200)")]
        [Display(Name ="Course Duration")]
        public string CourseDuration { get; set; }

    }
}
