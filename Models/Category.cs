using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryNames = new HashSet<CategoryName>();
            Groups = new HashSet<Group>();
            LocationCategories = new HashSet<LocationCategory>();
        }

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<CategoryName> CategoryNames { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<LocationCategory> LocationCategories { get; set; }
    }
}
