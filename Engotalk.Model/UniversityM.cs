using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Model
{
    public class UniversityM
    {
        [Key]
        public int UniversityId { get; set; }
        [Column(TypeName ="nvarchar(500)")]
        public string UniversityType { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public CountryM? country { get; set; }
        public int CountryId { get; set; }
        public int? Rank { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Location { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string? Established { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "Exams Accepted")]
        public string? ExamsAccepted { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<DepartmentM> departments { get; set; }

    }
}
