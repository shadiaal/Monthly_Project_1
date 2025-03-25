using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HealthSystem.Models
{
	public class User
	{
		[Key]
		public Guid UserID { get; set; } = Guid.NewGuid();

		[Required]
		[StringLength(20, ErrorMessage = "First name cannot exceed 20 characters.")]
		public string FirstName { get; set; }

		[StringLength(20, ErrorMessage = "Middle name cannot exceed 20 characters.")]
		public string MiddleName { get; set; }

		[Required]
		[StringLength(20, ErrorMessage = "Last name cannot exceed 20 characters.")]
		public string LastName { get; set; }

		
		
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Format")]
		public string Email { get; set; }

		[Required]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits.")]
		public string PhoneNumber { get; set; }

		[Required]
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long, include at least one letter and one number.")]
		public string Password { get; set; }

		[Required]
		public UserRole Role { get; set; }

		public Doctor Doctor { get; set; }
		public Patient Patient { get; set; }
	}

	public enum UserRole
	{
		Admin,
		Doctor,
		Patient
	}

	public enum Gender
	{
		Male,
		Female
	}
}
