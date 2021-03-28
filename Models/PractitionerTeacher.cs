using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class PractitionerTeacher
    {
        public int PractitionerId { get; set; }
        public int TeacherId { get; set; }

        public virtual Practitioner Practitioner { get; set; }
        public virtual Practitioner Teacher { get; set; }
    }
}
