using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class NotableLocation
    {
        public int GroupId { get; set; }
        public int LocationId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Location Location { get; set; }
    }
}
