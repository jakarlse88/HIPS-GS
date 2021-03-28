using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class CategoryName
    {
        public int NameId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
