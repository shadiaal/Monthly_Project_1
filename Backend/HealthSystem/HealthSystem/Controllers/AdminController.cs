using HealthSystem.Data;
using HealthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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