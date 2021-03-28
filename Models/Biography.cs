using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class Biography
    {
        public Biography()
        {
            GroupBiographies = new HashSet<GroupBiography>();
            PractitionerBiographies = new HashSet<PractitionerBiography>();
        }

        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int LanguageId { get; set; }

        public virtual ICollection<GroupBiography> GroupBiographies { get; set; }
        public virtual ICollection<PractitionerBiography> PractitionerBiographies { get; set; }
    }
}
