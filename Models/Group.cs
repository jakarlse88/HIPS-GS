using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class Group
    {
        public Group()
        {
            GroupBiographies = new HashSet<GroupBiography>();
            GroupExponents = new HashSet<GroupExponent>();
            NotableLocations = new HashSet<NotableLocation>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UdpatedBy { get; set; }
        public int FounderId { get; set; }
        public DateTime Founded { get; set; }
        public DateTime? Dissolved { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Practitioner Founder { get; set; }
        public virtual ICollection<GroupBiography> GroupBiographies { get; set; }
        public virtual ICollection<GroupExponent> GroupExponents { get; set; }
        public virtual ICollection<NotableLocation> NotableLocations { get; set; }
    }
}
