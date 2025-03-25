using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
using HealthSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace HealthSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define DbSet properties for each model
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Define relationships between entities

            //define PK keys for entities
            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.UserID);
            modelBuilder.Entity<Patient>()
                .HasKey(d => d.UserID);

            // One-to-One: User -> Patient
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.User)
                .WithOne()
                .HasForeignKey<Patient>(p => p.UserID)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a User will delete the associated Patient

            // One-to-One: User -> Doctor
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.UserID)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a User will delete the associated Doctor

            // One-to-Many: Doctor -> Appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorUserID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a Doctor if they have Appointments

            // One-to-Many: Patient -> Appointments
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientUserID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a Patient if they have Appointments

            // One-to-Many: Doctor -> WorkingHours
            modelBuilder.Entity<WorkingHours>()
                .HasOne(w => w.Doctor)
                .WithMany(d => d.WorkingHours)
                .HasForeignKey(w => w.UserID)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a Doctor will delete their WorkingHours

            base.OnModelCreating(modelBuilder);
        }
    }
}