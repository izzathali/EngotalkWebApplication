using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.ViewModel
{
    public class DepartmentVM
    {
        public int? DepartmentId { get; set; }
        public string Department { get; set; }
        public string? Course { get; set; }
        public string? Country { get; set; }
        public string? University { get; set; }

        public List<DepartmentVM>? DepartmentList { get; set; }
    }
}
