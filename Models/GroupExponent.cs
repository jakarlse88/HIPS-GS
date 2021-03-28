using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class GroupExponent
    {
        public int GroupId { get; set; }
        public int PractitionerId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Practitioner Practitioner { get; set; }
    }
}
