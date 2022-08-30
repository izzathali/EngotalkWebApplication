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

        [Display(Name = "Course Title")]
        public string Course { get; set; } = String.Empty;

        public int DepartmentId { get; set; }
        public DepartmentM? department { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "IELTS")]
        public string? IELTSBand { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "GRE")]
        public string? GREScore { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "TOEFL")]
        public string? TOEFLScore { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "SAT")]
        public string? SATScore { get; set; }
        //Cost string bcos of approximate amnt
        public string? Cost { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Course Duration")]
        public string? CourseDuration { get; set; }

        public bool IsDeleted { get; set; }


    }
}
