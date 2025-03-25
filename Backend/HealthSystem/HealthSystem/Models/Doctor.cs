using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System;

namespace HealthSystem.Models
{
	public class Doctor
	{
		[ForeignKey("User")]
		public Guid UserID { get; set; }

		[Required(ErrorMessage = "Gender is required.")]
		public Gender Gender { get; set; }

		[Required(ErrorMessage = "Specialization is required.")]
		[StringLength(100, ErrorMessage = "Specialization cannot exceed 100 characters.")]
		public string Specialization { get; set; }

		[Required(ErrorMessage = "Clinic is required.")]
		[EnumDataType(typeof(ClinicType), ErrorMessage = "Invalid clinic type.")]
		public ClinicType Clinic { get; set; }

		public User User { get; set; }
		public List<WorkingHours> WorkingHours { get; set; }
		public List<Appointment> Appointments { get; set; }
	}
	public enum ClinicType
	{
		General,
		Cardiology,
		Dermatology,
		Pediatrics,
		Orthopedics,
		Neurology,
		Dentistry,
		Ophthalmology,
		Psychiatry,
		Gynecology
	}

}
