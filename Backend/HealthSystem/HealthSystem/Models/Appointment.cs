using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthSystem.Models
{
	public class Appointment
	{
		[Key]
		public int AppointmentID { get; set; }

		[ForeignKey("Patient")]
		[Required(ErrorMessage = "Patient is required.")]
		public Guid PatientUserID { get; set; }

		[ForeignKey("Doctor")]
		[Required(ErrorMessage = "Doctor is required.")]
		public Guid DoctorUserID { get; set; }

		[Required(ErrorMessage = "Appointment date is required.")]
		[DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
		[Display(Name = "Appointment Date")]
		public DateTime AppointmentDate { get; set; }

		[Required(ErrorMessage = "Appointment time is required.")]
		[DataType(DataType.Time, ErrorMessage = "Invalid time format.")]
		[Display(Name = "Appointment Time")]
		public TimeSpan AppointmentTime { get; set; }

		[Required(ErrorMessage = "Status is required.")]
		public AppointmentStatus Status { get; set; }

		[StringLength(500, ErrorMessage = "Note cannot exceed 500 characters.")]
		[Display(Name = "Appointment Note")]
		public string Note { get; set; }

		public Patient Patient { get; set; }
		public Doctor Doctor { get; set; }
	}

	public enum AppointmentStatus
	{
		Upcoming,
		Past,
		Current
	}
}
