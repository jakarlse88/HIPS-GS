using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class GroupBiography
    {
        public int GroupId { get; set; }
        public int BiographyId { get; set; }

        public virtual Biography Biography { get; set; }
        public virtual Group Group { get; set; }
    }
}
