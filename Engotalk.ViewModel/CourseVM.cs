using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.ViewModel
{
    public class CourseVM
    {
        public string? Country { get; set; }
        public string? University { get; set; }
        public string? Department { get; set; }
        public int? CourseId { get; set; }
        public string? Course { get; set; }
        public string? IELTSBand { get; set; }
        public string? GREScore { get; set; }
        public string? TOEFLScore { get; set; }
        public string? SATScore { get; set; }
        public string? Cost { get; set; }
        public string? CourseDuration { get; set; }

        public UniversityVM? Univ { get; set; }
        public List<CourseVM>? courses { get; set; }
    }
}
