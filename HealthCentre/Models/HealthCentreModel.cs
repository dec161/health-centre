using System.Data.Entity;

namespace HealthCentre.Models
{
    public partial class HealthCentreModel : DbContext
    {
        public HealthCentreModel()
            : base("name=HealthCentreModel")
        {
        }

        public virtual DbSet<DoctorType> DoctorType { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorType>()
                .HasMany(e => e.Visit)
                .WithRequired(e => e.DoctorType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gender>()
                .HasMany(e => e.Patient)
                .WithRequired(e => e.Gender)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Visit)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
