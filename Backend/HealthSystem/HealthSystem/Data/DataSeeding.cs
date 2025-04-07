using HealthSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthSystem.Data
{
    public class DataSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Users
            SeedData(modelBuilder);

        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            // Create GUIDs for users
            var user1ID = Guid.NewGuid();
            var doctor1ID = Guid.NewGuid();
            var doctor2ID = Guid.NewGuid();
            var doctor3ID = Guid.NewGuid();
            var doctor4ID = Guid.NewGuid();
            var doctor5ID = Guid.NewGuid();

            var patient1ID = Guid.NewGuid();
            var patient2ID = Guid.NewGuid();
            var patient3ID = Guid.NewGuid();
            var patient4ID = Guid.NewGuid();
            var patient5ID = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserID = user1ID,
                   FirstName = "Areej",
                   MiddleName = "Osama",  // Adding MiddleName
                   LastName = "Shareefi",
                   Email = "areej.shareefi@email.com",
                   PhoneNumber = "9876543210",
                   Password = "AdminPassword123",
                   Role = UserRole.Admin
               },
                new User
                {
                    UserID = patient1ID,
                    FirstName = "Alice",
                    MiddleName = "Marie",  // Adding MiddleName
                    LastName = "Smith",
                    Email = "alice.smith@email.com",
                    PhoneNumber = "3216549870",
                    Password = "PatientPassword123",
                    Role = UserRole.Patient
                },
                new User
                {
                    UserID = patient2ID,
                    FirstName = "Bob",
                    MiddleName = "John",  // Adding MiddleName
                    LastName = "Johnson",
                    Email = "bob.johnson@email.com",
                    PhoneNumber = "4321657890",
                    Password = "PatientPassword456",
                    Role = UserRole.Patient
                },
                new User
                {
                    UserID = patient3ID,
                    FirstName = "Charlie",
                    MiddleName = "David",  // Adding MiddleName
                    LastName = "Brown",
                    Email = "charlie.brown@email.com",
                    PhoneNumber = "5432168970",
                    Password = "PatientPassword789",
                    Role = UserRole.Patient
                },
                new User
                {
                    UserID = patient4ID,
                    FirstName = "David",
                    MiddleName = "Lee",  // Adding MiddleName
                    LastName = "Williams",
                    Email = "david.williams@email.com",
                    PhoneNumber = "6543210987",
                    Password = "PatientPassword101",
                    Role = UserRole.Patient
                },
                new User
                {
                    UserID = patient5ID,
                    FirstName = "Emma",
                    MiddleName = "Grace",  // Adding MiddleName
                    LastName = "Taylor",
                    Email = "emma.taylor@email.com",
                    PhoneNumber = "7654321098",
                    Password = "PatientPassword202",
                    Role = UserRole.Patient
                },

                // Doctors
                new User
                {
                    UserID = doctor1ID,
                    FirstName = "James",
                    MiddleName = "Edward",  // Adding MiddleName
                    LastName = "Wilson",
                    Email = "james.wilson@email.com",
                    PhoneNumber = "8765432109",
                    Password = "DoctorPassword123",
                    Role = UserRole.Doctor
                },
                new User
                {
                    UserID = doctor2ID,
                    FirstName = "Sophia",
                    MiddleName = "Ann",  // Adding MiddleName
                    LastName = "Davis",
                    Email = "sophia.davis@email.com",
                    PhoneNumber = "9876543211",
                    Password = "DoctorPassword456",
                    Role = UserRole.Doctor
                },
                new User
                {
                    UserID = doctor3ID,
                    FirstName = "Michael",
                    MiddleName = "Ray",  // Adding MiddleName
                    LastName = "Martinez",
                    Email = "michael.martinez@email.com",
                    PhoneNumber = "1234567891",
                    Password = "DoctorPassword789",
                    Role = UserRole.Doctor
                },
                new User
                {
                    UserID = doctor4ID,
                    FirstName = "Olivia",
                    MiddleName = "Marie",  // Adding MiddleName
                    LastName = "Lopez",
                    Email = "olivia.lopez@email.com",
                    PhoneNumber = "2345678901",
                    Password = "DoctorPassword101",
                    Role = UserRole.Doctor
                },
                new User
                {
                    UserID = doctor5ID,
                    FirstName = "Ethan",
                    MiddleName = "James",  // Adding MiddleName
                    LastName = "Hernandez",
                    Email = "ethan.hernandez@email.com",
                    PhoneNumber = "3456789012",
                    Password = "DoctorPassword202",
                    Role = UserRole.Doctor
                }


            );




            // Link Doctor with their User (this is the relationship that needs to be seeded)
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    UserID = doctor1ID, // The Doctor's UserID, linking to the User table
                    Gender = Gender.Male,
                    Specialization = "Cardiology",
                    Clinic = ClinicType.Cardiology
                },
                new Doctor
                {
                    UserID = doctor2ID,
                    Gender = Gender.Female,
                    Specialization = "Dermatology",
                    Clinic = ClinicType.Dermatology
                },
                new Doctor
                {
                    UserID = doctor3ID,
                    Gender = Gender.Male,
                    Specialization = "Pediatrics",
                    Clinic = ClinicType.Pediatrics
                },
                new Doctor
                {
                    UserID = doctor4ID,
                    Gender = Gender.Female,
                    Specialization = "Orthopedics",
                    Clinic = ClinicType.Orthopedics
                },
                new Doctor
                {
                    UserID = doctor5ID,
                    Gender = Gender.Male,
                    Specialization = "Neurology",
                    Clinic = ClinicType.Neurology
                }
            );

            // Seed Working Hours for Doctors
            modelBuilder.Entity<WorkingHours>().HasData(
                  new WorkingHours { WorkingHoursID = 1, UserID = doctor1ID, Day = dayOfWeek.Monday, StartTime = TimeSpan.FromHours(9), EndTime = TimeSpan.FromHours(17) },
                  new WorkingHours { WorkingHoursID = 2, UserID = doctor2ID, Day = dayOfWeek.Tuesday, StartTime = TimeSpan.FromHours(10), EndTime = TimeSpan.FromHours(16) },
                  new WorkingHours { WorkingHoursID = 3, UserID = doctor3ID, Day = dayOfWeek.Wednesday, StartTime = TimeSpan.FromHours(9), EndTime = TimeSpan.FromHours(14) },
                  new WorkingHours { WorkingHoursID = 4, UserID = doctor4ID, Day = dayOfWeek.Thursday, StartTime = TimeSpan.FromHours(11), EndTime = TimeSpan.FromHours(18) },
                  new WorkingHours { WorkingHoursID = 5, UserID = doctor5ID, Day = dayOfWeek.Friday, StartTime = TimeSpan.FromHours(8), EndTime = TimeSpan.FromHours(15) }
              );

            modelBuilder.Entity<Patient>().HasData(
                    new Patient
                    {
                        UserID = patient1ID,
                        NationalID = "1234567890",
                        DateOfBirth = new DateTime(1990, 5, 10),
                        Gender = Gender.Female,
                        BloodType = BloodType.A_Positive,
                        Allergies = "Peanuts, Dust",
                        ChronicDiseases = "Asthma"
                    },
                    new Patient
                    {
                        UserID = patient2ID,
                        NationalID = "2345678901",
                        DateOfBirth = new DateTime(1988, 7, 15),
                        Gender = Gender.Male,
                        BloodType = BloodType.O_Negative,
                        Allergies = "Penicillin",
                        ChronicDiseases = "Diabetes"
                    },
                    new Patient
                    {
                        UserID = patient3ID,
                        NationalID = "3456789012",
                        DateOfBirth = new DateTime(1995, 3, 20),
                        Gender = Gender.Male,
                        BloodType = BloodType.B_Positive,
                        Allergies = "Latex, Pollen",
                        ChronicDiseases = "None"
                    },
                    new Patient
                    {
                        UserID = patient4ID,
                        NationalID = "4567890123",
                        DateOfBirth = new DateTime(1983, 12, 5),
                        Gender = Gender.Female,
                        BloodType = BloodType.AB_Positive,
                        Allergies = "None",
                        ChronicDiseases = "Hypertension"
                    },
                    new Patient
                    {
                        UserID = patient5ID,
                        NationalID = "5678901234",
                        DateOfBirth = new DateTime(1992, 8, 18),
                        Gender = Gender.Female,
                        BloodType = BloodType.O_Positive,
                        Allergies = "Dust, Animal Dander",
                        ChronicDiseases = "Asthma"
                    }

                );

            // Seed Appointments
            modelBuilder.Entity<Appointment>().HasData(
                 new Appointment
                 {
                     AppointmentID = 1,
                     PatientUserID = patient1ID,
                     DoctorUserID = doctor1ID,
                     AppointmentDate = DateTime.Now.AddDays(1),
                     AppointmentTime = new TimeSpan(10, 0, 0),
                     Status = AppointmentStatus.Upcoming,
                     Note = "Initial check-up appointment."
                 },
                new Appointment
                {
                    AppointmentID = 2,
                    PatientUserID = patient2ID,
                    DoctorUserID = doctor1ID,
                    AppointmentDate = DateTime.Now.AddDays(-1),
                    AppointmentTime = new TimeSpan(9, 0, 0),
                    Status = AppointmentStatus.Past,
                    Note = "Follow-up appointment."
                },
                new Appointment
                {
                    AppointmentID = 3,
                    PatientUserID = patient3ID,
                    DoctorUserID = doctor2ID,
                    AppointmentDate = DateTime.Now.AddDays(3),
                    AppointmentTime = new TimeSpan(14, 30, 0),
                    Status = AppointmentStatus.Upcoming,
                    Note = "Dermatology consultation."
                },
                new Appointment
                {
                    AppointmentID = 4,
                    PatientUserID = patient4ID,
                    DoctorUserID = doctor3ID,
                    AppointmentDate = DateTime.Now.AddDays(5),
                    AppointmentTime = new TimeSpan(11, 0, 0),
                    Status = AppointmentStatus.Upcoming,
                    Note = "Pediatric consultation for vaccination."
                },
                new Appointment
                {
                    AppointmentID = 5,
                    PatientUserID = patient5ID,
                    DoctorUserID = doctor4ID,
                    AppointmentDate = DateTime.Now.AddDays(2),
                    AppointmentTime = new TimeSpan(16, 0, 0),
                    Status = AppointmentStatus.Upcoming,
                    Note = "Orthopedic consultation for knee pain."
                }
            );
        }

    }
}