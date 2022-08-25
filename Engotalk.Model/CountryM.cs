using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Model
{
    public class CountryM
    {
        [Key]
        public int CountryId { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Display(Name = "Country ")]
        public string CountryName { get; set; } = string.Empty;
    }
}
