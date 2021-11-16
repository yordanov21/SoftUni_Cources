using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Config;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.FirstName)
                      .IsUnicode();

                entity.Property(e => e.LastName)
                      .IsUnicode();

                entity.Property(e => e.Address)
                      .IsUnicode();

                entity.Property(e => e.Email)
                      .IsUnicode(false);

            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.Property(e => e.Comments)
                      .IsUnicode();

                //entity
                //.HasOne(x => x.Patient)
                //.WithMany(x => x.Visitations)
                //.HasForeignKey(x => x.PatientId);

                //entity
                //.HasOne(v => v.Doctor)
                //.WithMany(d => d.Visitations)
                //.HasForeignKey(v => v.DoctorId);

                //entity
                //.Property(x => x.Date)
                //.HasDefaultValueSql("GetDate()");
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsUnicode();

                entity.Property(e => e.Comments)
                      .IsUnicode();

            });

            modelBuilder.Entity<PatientMedicament>().HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsUnicode();

                entity.Property(e => e.Specialty)
                      .IsUnicode();
            }

            );
        
    }
    }
}
