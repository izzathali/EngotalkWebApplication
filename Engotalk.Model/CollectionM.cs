using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engotalk.Model
{
    public class CollectionM
    {
        [Key]
        public int CollectionId { get; set; }

        public string Collection { get; set; } = string.Empty;
        public string TestType { get; set; } = string.Empty;
        public int CollectionCategoryId { get; set; }
        public CollectionCategoryM? collectionCategory { get; set; }
    }
}
