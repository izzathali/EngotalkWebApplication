using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Model
{
    public class CourseTitleM
    {
        [Key]
        public int CourseTitleId { get; set; }
        [Column(TypeName = "nvarchar(400)")]
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; } = string.Empty;
    }
}
