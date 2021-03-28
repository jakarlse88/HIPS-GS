using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class LocationName
    {
        public int NameId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}
