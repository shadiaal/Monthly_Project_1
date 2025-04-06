using HealthSystem.Data;
using HealthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;

namespace HealthSystem.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }
        // ------- Admin & statistics -------

        [HttpGet("graph/barChart")]
        public async Task<IActionResult> Barchart()
        {
            var patientsCount = await _context.Patients.CountAsync();
            var doctorsCount = await _context.Doctors.CountAsync();

            var BarchartData = new
            {
                patients = patientsCount,
                doctors = doctorsCount
            };

            return Ok(BarchartData);
        }


        [HttpGet("graph/piechart")]
        public async Task<IActionResult> Piechart()
        {
            var maleCount = await _context.Patients.CountAsync(p => p.Gender == Gender.Male);
            var femaleCount = await _context.Patients.CountAsync(p => p.Gender == Gender.Female);

            var PiechartData = new[]
            {
            new { name = "Male", value = maleCount },
            new { name = "Female", value = femaleCount },
        };

            return Ok(PiechartData);

        }


        // ------- Admin & Patient -------

        [HttpPost("create-patient")]
        public async Task<IActionResult> CreatePatient([FromBody] PatientCreateRequest request)
        {
            try
            {
                // Validate the request
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                // Check if email already exists
                if (await _context.Users.AnyAsync(u => u.Email == request.user.email))
                {
                    return BadRequest("Email already exists.");
                }

                // Check if national ID already exists
                if (await _context.Patients.AnyAsync(p => p.NationalID == request.nationalID))
                {
                    return BadRequest("National ID already exists.");
                }


                // Parse date string into year, month, day components
                DateTime dateOfBirth;
                try
                {
                    var dateParts = request.dateOfBirth.Split('-');
                    if (dateParts.Length != 3)
                    {
                        return BadRequest("Invalid date format. Use YYYY-MM-DD.");
                    }

                    int year = int.Parse(dateParts[0]);
                    int month = int.Parse(dateParts[1]);
                    int day = int.Parse(dateParts[2]);

                    dateOfBirth = new DateTime(year, month, day); 
                }
                catch
                {
                    return BadRequest("Invalid date format. Use YYYY-MM-DD.");
                }

                // Create the User
                var user = new User
                {
                    UserID = Guid.NewGuid(),
                    FirstName = request.user.firstName,
                    MiddleName = request.user.middleName,
                    LastName = request.user.lastName,
                    Email = request.user.email,
                    PhoneNumber = request.user.phoneNumber,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.user.password),
                Role = UserRole.Patient
                };

                // Create the Patient
                var patient = new Patient
                {
                    UserID = user.UserID,
                    NationalID = request.nationalID,
                    DateOfBirth = dateOfBirth,
                    Gender = Enum.Parse<Gender>(request.gender),
                    BloodType = Enum.Parse<BloodType>(request.bloodType.Replace("+", "_Positive").Replace("-", "_Negative")),
                    Allergies = request.allergies,
                    ChronicDiseases = request.chronicDiseases
                };

                // Add to database
                _context.Users.Add(user);
                _context.Patients.Add(patient);

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Patient created successfully",
                    userId = user.UserID
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        // ------- Admin & Doctor -------

        [HttpPost("create-doctor")]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorRequest request)
        {
            if (request == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid doctor data.");
            }

            // Step 1: Create a new User
            var user = new User
            {
                UserID = Guid.NewGuid(),
                FirstName = request.User.FirstName,
                MiddleName = request.User.MiddleName,
                LastName = request.User.LastName,
                Email = request.User.Email,
                PhoneNumber = request.User.PhoneNumber,
                Password = HashPassword(request.User.Password), // Hash the password securely
                Role = UserRole.Doctor // Ensure role is Doctor
            };

            // Add the user to the database
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();  // Save the user to get the UserID

            // Step 2: Create a new Doctor
            var doctor = new Doctor
            {
                UserID = user.UserID,
                Gender = Enum.TryParse(request.Gender, out Gender gender) ? gender : Gender.Male, // Default to Male if invalid
                Specialization = request.Specialization,
                Clinic = Enum.TryParse(request.Clinic, out ClinicType clinic) ? clinic : ClinicType.General, // Default to General if invalid
                User = user
            };

            // Add working hours for the doctor
            foreach (var workingHour in request.WorkingHours)
            {
                var hours = new WorkingHours
                {
                    UserID = doctor.UserID,
                    Day = Enum.TryParse(workingHour.Day, out dayOfWeek day) ? day : dayOfWeek.Monday, // Default to Monday if invalid
                    StartTime = TimeSpan.TryParse(workingHour.StartTime, out TimeSpan startTime) ? startTime : TimeSpan.Zero, // Default to 00:00 if invalid
                    EndTime = TimeSpan.TryParse(workingHour.EndTime, out TimeSpan endTime) ? endTime : TimeSpan.Zero, // Default to 00:00 if invalid
                    Doctor = doctor
                };
                doctor.WorkingHours.Add(hours);
            }

            // Step 3: Save the doctor to the database
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();  // Save the doctor and working hours

            // Step 4: Return success message
            return Ok(new { message = "Doctor created successfully" });
                }

                //method to hash the password using a hash algorithm
                private string HashPassword(string password)
                {
                    
                    return password; 
                }
            }




    // ------- DTO -------

    // Request model for patient creation
    public class PatientCreateRequest
    {
        public UserRequest user { get; set; }
        public string nationalID { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string bloodType { get; set; }
        public string allergies { get; set; }
        public string chronicDiseases { get; set; }
    }

    public class UserRequest
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
    }


    // DTO for creating a doctor
    public class CreateDoctorRequest
            {
                public UserDto User { get; set; }
                public string Gender { get; set; }
                public string Specialization { get; set; }
                public string Clinic { get; set; }
                public List<WorkingHoursDto> WorkingHours { get; set; }
            }

            public class UserDto
            {
                public string FirstName { get; set; }
                public string MiddleName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string PhoneNumber { get; set; }
                public string Password { get; set; }
                public string Role { get; set; }
            }

            public class WorkingHoursDto
            {
                public string Day { get; set; }
                public string StartTime { get; set; }
                public string EndTime { get; set; }
            }


}