using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class PractitionerBiography
    {
        public int PractitionerId { get; set; }
        public int BiographyId { get; set; }

        public virtual Biography Biography { get; set; }
        public virtual Practitioner Practitioner { get; set; }
    }
}
