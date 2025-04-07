import { Component } from '@angular/core';
import { AdminService } from '../../../Services/AdminServices/admin.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { HttpErrorResponse } from '@angular/common/http';
import { Location } from '@angular/common'; // Import Location service for page refresh

@Component({
  selector: 'app-create-appointment',
  imports: [CommonModule, FormsModule],
  templateUrl: './appointment-create.component.html',
  styleUrls: ['./appointment-create.component.css'],
})
export class AppointmentCreateComponent {
  date: string = '';
  clinic: number = 3;  // Default clinic is Pediatrics
  availableAppointments: any[] = [];
  selectedTime: string = '';
  selectedDoctor: any = null;
  selectedDoctorId: string = '';
  patientId: string = ''; 
  showModal: boolean = false;  
  errorMessage: string = '';
  successMessage: string = ''; // Success message for alert

  constructor(private adminService: AdminService, private location: Location) {}

  // Method to fetch available appointments based on date and clinic
  getAvailableAppointments() {
    if (this.date && this.clinic) {
      this.adminService
        .getAvailableAppointments(this.date, this.clinic)
        .subscribe(
          (response) => {
            this.availableAppointments = response.availableAppointments || [];
            console.log('available app object; ', this.availableAppointments);
          },
          (error) => {
            console.error('Error fetching available appointments:', error);
          }
        );
    }
  }

  // Open the modal to display appointment details
  openModal(doctor: any, timeSlot: string, doctorId: string) {
    this.selectedDoctor = doctor;
    this.selectedDoctorId = doctorId;
    this.selectedTime = timeSlot;
    this.showModal = true;  // Show the modal
  }

  // Close the modal
  closeModal() {
    this.showModal = false;  // Hide the modal
    this.patientId = '';  // Clear the patient ID input
    this.errorMessage = ''; // Clear any previous errors
    this.successMessage = ''; // Clear any previous success messages
  }

  // Method to handle form submission (creating the appointment)
  createAppointment() {
    // Validate that all necessary fields are filled
    if (!this.patientId || !this.selectedTime || !this.selectedDoctorId) {
      this.errorMessage = 'Please select all fields.';
      return;
    }

    // Create the appointment request object
    const request = {
      PatientID: this.patientId,
      DoctorID: this.selectedDoctorId, 
      AppointmentDate: this.date,
      AppointmentTime: this.selectedTime,
    };
    console.log('Appointment request object:', request);

    // Call the createAppointment API
    this.adminService.createAppointment(request).subscribe(
      (response) => {
        // Handle success response
        console.log('Appointment created successfully', response);
        this.successMessage = 'Appointment created successfully!';  // Show success message
        this.showModal = false; // Close the modal after successful creation
        
        // Refresh the page after appointment creation
        setTimeout(() => {
          this.location.replaceState(this.location.path());  // Refresh current route
        }, 1000); // 1 second delay before refresh
      },
      (error: HttpErrorResponse) => {
        // Handle error response
        console.error('Error creating appointment:', error);
        this.errorMessage = error.error.message || 'Failed to create appointment.';
      }
    );
  }
}
