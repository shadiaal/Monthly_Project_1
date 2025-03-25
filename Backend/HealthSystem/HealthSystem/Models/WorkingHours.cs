using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthSystem.Models
{
	public class WorkingHours
	{
		[Key]
		public int WorkingHoursID { get; set; }

		[ForeignKey("Doctor")]
		public Guid UserID { get; set; }

		[Required(ErrorMessage = "Day is required.")]
		[EnumDataType(typeof(DayOfWeek), ErrorMessage = "Invalid day.")]
		public DayOfWeek Day { get; set; }
		public TimeSpan StartTime { get; set; }
		public TimeSpan EndTime { get; set; }

		public Doctor Doctor { get; set; }
	}
	public enum DayOfWeek
	{
		Sunday,
		Monday,
		Tuesday,
		Wednesday,
		Thursday,
		Friday,
		Saturday
		
	}
}
