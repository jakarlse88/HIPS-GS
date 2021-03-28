using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class PractitionerName
    {
        public int NameId { get; set; }
        public int PractitionerId { get; set; }

        public virtual Practitioner Practitioner { get; set; }
    }
}
