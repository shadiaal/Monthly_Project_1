using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace HealthSystem.Models
{
	public class Patient
	{
		[ForeignKey("User")]
		public Guid UserID { get; set; }

		[Required(ErrorMessage = "National ID is required.")]
		[StringLength(10, MinimumLength = 10, ErrorMessage = "National ID must be exactly 10 characters.")]
		public string NationalID { get; set; }

		[Required(ErrorMessage = "Date of Birth is required.")]
		public DateTime DateOfBirth { get; set; }

		[Required(ErrorMessage = "Gender is required.")]
		public Gender Gender { get; set; }

		public BloodType BloodType { get; set; }

		[StringLength(500, ErrorMessage = "Allergies information cannot exceed 500 characters.")]
		public string Allergies { get; set; }

		[StringLength(500, ErrorMessage = "Chronic diseases information cannot exceed 500 characters.")]
		public string ChronicDiseases { get; set; }

		public User User { get; set; }

		public List<Appointment> Appointments { get; set; }
	}
	public enum BloodType
	{
		A_Positive,
		A_Negative,
		B_Positive,
		B_Negative,
		AB_Positive,
		AB_Negative,
		O_Positive,
		O_Negative
	}
}
