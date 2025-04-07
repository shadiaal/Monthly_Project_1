using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthSystem.Data;
using Microsoft.AspNetCore.Authorization;

namespace HealthSystem.Controllers
{

    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PatientController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET patient data by UserID
        [Authorize (Roles ="Patient")] 
        [HttpGet("getPatientData/{userId}")]
        public async Task<IActionResult> GetPatientData(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.Patient) 
                .Where(u => u.UserID == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var patientData = new
            {
                User = new
                {
                    user.UserID,
                    user.FirstName,
                    user.MiddleName,
                    user.LastName,
                    user.Email,
                    user.PhoneNumber,
                    role = user.Role.ToString()
                },
                Patient = new
                {
                    user.Patient.NationalID,
                    user.Patient.DateOfBirth,
                    Age = (int)((DateTime.Today - user.Patient.DateOfBirth).TotalDays / 365.25),
                    Gender = user.Patient.Gender.ToString(),
                    BloodType = user.Patient.BloodType.ToString(),
                    user.Patient.Allergies,
                    user.Patient.ChronicDiseases
                }
            };

            return Ok(patientData);
        }

        // 2. GET all patient's appointments by UserID

        [HttpGet("getAppointments/{userId}")]
        public async Task<IActionResult> GetAppointments(Guid userId)
        {
            var patient = await _context.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ThenInclude(d => d.User)
                .Where(p => p.UserID == userId)
                .FirstOrDefaultAsync();

            if (patient == null)
            {
                return NotFound("Patient not found.");
            }

            var appointments = patient.Appointments
                .Where(a => a.Doctor != null) 
                .Select(a => new
                {
                    a.AppointmentID,
                    a.AppointmentDate,
                    a.AppointmentTime,
                    status = a.Status.ToString(),
                    a.Note,
                    Doctor = a.Doctor != null ? new
                    {
                        FirstName = a.Doctor.User?.FirstName,
                        LastName = a.Doctor.User?.LastName,
                    } : null
                })
                .ToList();

            return Ok(appointments);
        }

    }
}