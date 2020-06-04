using System;
using Microsoft.EntityFrameworkCore;

namespace cw8.Models
{
    public class s16945Context : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Doctor> Doctor { get; set; }

        public s16945Context(DbContextOptions<s16945Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient);
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();

                var p1 = new Patient
                {
                    IdPatient = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Birthdate = DateTime.Now
                };
                entity.HasData(p1);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(e => e.IdPrescription);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();

                entity.HasOne(e => e.Patient).WithMany(p => p.Prescriptions).HasForeignKey(e => e.IdPatient);
                entity.HasOne(e => e.Doctor).WithMany(p => p.Prescriptions).HasForeignKey(e => e.IdDoctor);

                var p1 = new Prescription
                {
                    IdPrescription = 1,
                    Date = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(60),
                    IdPatient = 1,
                    IdDoctor = 1
                };

                entity.HasData(p1);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();

                var d1 = new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    Email = "doctor@doctor.com"
                };

                entity.HasData(d1);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();

                var m1 = new Medicament
                {
                    IdMedicament = 1,
                    Name = "Some medicament",
                    Description = "Works like a charm",
                    Type = "AB123"
                };

                entity.HasData(m1);
            });

            modelBuilder.Entity<PrescriptionMedicament>(entity =>
            {
                entity.HasKey(e => e.IdMedicament);
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.HasKey(e => e.IdPrescription);
                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Dose).IsRequired(false);
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();

                entity.HasOne(e => e.Medicament).WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(e => e.IdMedicament);
                entity.HasOne(e => e.Prescription).WithMany(p => p.PrescriptionMedicaments)
                    .HasForeignKey(e => e.IdPrescription);

                var pm1 = new PrescriptionMedicament
                {
                    IdMedicament = 1,
                    IdPrescription = 1,
                    Dose = 50,
                    Details = "Be careful"
                };

                entity.HasData(pm1);
            });
        }
    }
}