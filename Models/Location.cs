using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class Location
    {
        public Location()
        {
            LocationCategories = new HashSet<LocationCategory>();
            LocationNames = new HashSet<LocationName>();
            NotableLocations = new HashSet<NotableLocation>();
            PractitionerBirthLocations = new HashSet<Practitioner>();
            PractitionerDeathLocations = new HashSet<Practitioner>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<LocationCategory> LocationCategories { get; set; }
        public virtual ICollection<LocationName> LocationNames { get; set; }
        public virtual ICollection<NotableLocation> NotableLocations { get; set; }
        public virtual ICollection<Practitioner> PractitionerBirthLocations { get; set; }
        public virtual ICollection<Practitioner> PractitionerDeathLocations { get; set; }
    }
}
