using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Model
{
    public class CollectionCategoryM
    {
        [Key]
        public int CollectionCategoryId { get; set; }
        public int CollectionCategory { get; set; }
        public string TestType { get; set; } = string.Empty;
    }
}
