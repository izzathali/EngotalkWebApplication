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
        public string? IELTSRequirment { get; set; }
        public string Band { get; set; } = String.Empty;

        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Listening Band")]
        public string? ListeningBand { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Reading Band")]
        public string? ReadingBand { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Writing Band")]
        public string? WritingBand { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Speaking Band")]
        public string? SpeakingBand { get; set; }

        public decimal Cost { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Course Duration")]
        public string CourseDuration { get; set; }
        public bool IsDeleted { get; set; }


    }
}
