using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HIPS_GS.Models;

#nullable disable

namespace HIPS_GS.Data
{
    public partial class GroupContext : DbContext
    {
        public GroupContext()
        {
        }

        public GroupContext(DbContextOptions<GroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Biography> Biographies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryName> CategoryNames { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupBiography> GroupBiographies { get; set; }
        public virtual DbSet<GroupExponent> GroupExponents { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationCategory> LocationCategories { get; set; }
        public virtual DbSet<LocationName> LocationNames { get; set; }
        public virtual DbSet<NotableLocation> NotableLocations { get; set; }
        public virtual DbSet<Practitioner> Practitioners { get; set; }
        public virtual DbSet<PractitionerBiography> PractitionerBiographies { get; set; }
        public virtual DbSet<PractitionerName> PractitionerNames { get; set; }
        public virtual DbSet<PractitionerTeacher> PractitionerTeachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Biography>(entity =>
            {
                entity.ToTable("Biography", "group");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(3000);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category", "group");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoryName>(entity =>
            {
                entity.HasKey(e => new { e.NameId, e.CategoryId })
                    .HasName("PK_categoryname");

                entity.ToTable("CategoryName", "group");

                entity.HasIndex(e => e.CategoryId, "fkIdx_267");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryNames)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoryName_Category");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group", "group");

                entity.HasIndex(e => e.FounderId, "fkIdx_161");

                entity.HasIndex(e => e.CategoryId, "fkIdx_260");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Dissolved).HasColumnType("datetime");

                entity.Property(e => e.Founded).HasColumnType("datetime");

                entity.Property(e => e.UdpatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Category");

                entity.HasOne(d => d.Founder)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.FounderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Practitioner");
            });

            modelBuilder.Entity<GroupBiography>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.BiographyId })
                    .HasName("PK_groupbiography");

                entity.ToTable("GroupBiography", "group");

                entity.HasIndex(e => e.BiographyId, "fkIdx_416");

                entity.HasIndex(e => e.GroupId, "fkIdx_419");

                entity.HasOne(d => d.Biography)
                    .WithMany(p => p.GroupBiographies)
                    .HasForeignKey(d => d.BiographyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupBiography_Biography");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupBiographies)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupBiography_Group");
            });

            modelBuilder.Entity<GroupExponent>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.PractitionerId })
                    .HasName("PK_stylepractitioner");

                entity.ToTable("GroupExponent", "group");

                entity.HasIndex(e => e.PractitionerId, "fkIdx_208");

                entity.HasIndex(e => e.GroupId, "fkIdx_211");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupExponents)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupExponent_Group");

                entity.HasOne(d => d.Practitioner)
                    .WithMany(p => p.GroupExponents)
                    .HasForeignKey(d => d.PractitionerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupExponent_Practitioner");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "group");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LocationCategory>(entity =>
            {
                entity.HasKey(e => new { e.LocationId, e.CategoryId })
                    .HasName("PK_locationcategory");

                entity.ToTable("LocationCategory", "group");

                entity.HasIndex(e => e.CategoryId, "fkIdx_410");

                entity.HasIndex(e => e.LocationId, "fkIdx_413");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.LocationCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationCategory_Category");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationCategories)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationCategory_Location");
            });

            modelBuilder.Entity<LocationName>(entity =>
            {
                entity.HasKey(e => new { e.NameId, e.LocationId })
                    .HasName("PK_locationname");

                entity.ToTable("LocationName", "group");

                entity.HasIndex(e => e.LocationId, "fkIdx_228");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.LocationNames)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LocationName_Location");
            });

            modelBuilder.Entity<NotableLocation>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.LocationId })
                    .HasName("PK_notablelocation");

                entity.ToTable("NotableLocation", "group");

                entity.HasIndex(e => e.GroupId, "fkIdx_222");

                entity.HasIndex(e => e.LocationId, "fkIdx_225");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.NotableLocations)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotableLocation_Group");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.NotableLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NotableLocation_Location");
            });

            modelBuilder.Entity<Practitioner>(entity =>
            {
                entity.ToTable("Practitioner", "group");

                entity.HasIndex(e => e.BirthLocationId, "fkIdx_242");

                entity.HasIndex(e => e.DeathLocationId, "fkIdx_245");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.DateOfDeath).HasColumnType("datetime");

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.BirthLocation)
                    .WithMany(p => p.PractitionerBirthLocations)
                    .HasForeignKey(d => d.BirthLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Practitioner_BirthLocation");

                entity.HasOne(d => d.DeathLocation)
                    .WithMany(p => p.PractitionerDeathLocations)
                    .HasForeignKey(d => d.DeathLocationId)
                    .HasConstraintName("FK_Practitioner_DeathLocation");
            });

            modelBuilder.Entity<PractitionerBiography>(entity =>
            {
                entity.HasKey(e => new { e.PractitionerId, e.BiographyId })
                    .HasName("PK_practitionerbiography");

                entity.ToTable("PractitionerBiography", "group");

                entity.HasIndex(e => e.BiographyId, "fkIdx_422");

                entity.HasIndex(e => e.PractitionerId, "fkIdx_447");

                entity.HasOne(d => d.Biography)
                    .WithMany(p => p.PractitionerBiographies)
                    .HasForeignKey(d => d.BiographyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PractitionerBiography_Biography");

                entity.HasOne(d => d.Practitioner)
                    .WithMany(p => p.PractitionerBiographies)
                    .HasForeignKey(d => d.PractitionerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PractitionerBiography_Practitioner");
            });

            modelBuilder.Entity<PractitionerName>(entity =>
            {
                entity.HasKey(e => new { e.NameId, e.PractitionerId })
                    .HasName("PK_foundername");

                entity.ToTable("PractitionerName", "group");

                entity.HasIndex(e => e.PractitionerId, "fkIdx_168");

                entity.HasOne(d => d.Practitioner)
                    .WithMany(p => p.PractitionerNames)
                    .HasForeignKey(d => d.PractitionerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FounderName_Founder");
            });

            modelBuilder.Entity<PractitionerTeacher>(entity =>
            {
                entity.HasKey(e => new { e.PractitionerId, e.TeacherId })
                    .HasName("PK_practitionerteacher");

                entity.ToTable("PractitionerTeacher", "group");

                entity.HasIndex(e => e.PractitionerId, "fkIdx_235");

                entity.HasIndex(e => e.TeacherId, "fkIdx_238");

                entity.HasOne(d => d.Practitioner)
                    .WithMany(p => p.PractitionerTeacherPractitioners)
                    .HasForeignKey(d => d.PractitionerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PractitionerTeacher_Practitioner");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.PractitionerTeacherTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PractitionerTeacher_Teacher");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
