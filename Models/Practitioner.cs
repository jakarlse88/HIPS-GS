using System;
using System.Collections.Generic;

#nullable disable

namespace HIPS_GS.Models
{
    public partial class Practitioner
    {
        public Practitioner()
        {
            GroupExponents = new HashSet<GroupExponent>();
            Groups = new HashSet<Group>();
            PractitionerBiographies = new HashSet<PractitionerBiography>();
            PractitionerNames = new HashSet<PractitionerName>();
            PractitionerTeacherPractitioners = new HashSet<PractitionerTeacher>();
            PractitionerTeacherTeachers = new HashSet<PractitionerTeacher>();
        }

        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public int BirthLocationId { get; set; }
        public int? DeathLocationId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Location BirthLocation { get; set; }
        public virtual Location DeathLocation { get; set; }
        public virtual ICollection<GroupExponent> GroupExponents { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<PractitionerBiography> PractitionerBiographies { get; set; }
        public virtual ICollection<PractitionerName> PractitionerNames { get; set; }
        public virtual ICollection<PractitionerTeacher> PractitionerTeacherPractitioners { get; set; }
        public virtual ICollection<PractitionerTeacher> PractitionerTeacherTeachers { get; set; }
    }
}
