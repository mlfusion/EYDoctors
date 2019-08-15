using System;
using Doctors.Models;
using Microsoft.EntityFrameworkCore;

namespace Doctors.Data.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Doctor>()
                .HasMany(x => x.PatientRating)
                .WithOne(x => x.Doctor);

            builder.Entity<PatientRating>()
                .HasKey(k => new { k.DoctorId, k.Comments });

             builder.Entity<DoctorSpecialty>()
                 .HasKey(k => new { k.DoctorId, k.SpecialtyId });

            builder.Entity<DoctorSpecialty>()
                 .HasOne(x => x.Doctor)
                 .WithOne(x => x.DoctorSpecialty);

            builder.Entity<DoctorSpecialty>()
                .HasOne(x => x.Specialty)
                .WithOne(x => x.DoctorSpecialty);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MedicalSchool> MedicalSchools { get; set; }
        public DbSet<PatientRating> PatientRatings { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
       // public DbSet<User> Users { get; set; }
    }
}
