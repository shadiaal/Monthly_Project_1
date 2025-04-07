import { Component, Input, OnInit } from '@angular/core';
import { DoctorService } from '../../../Services/DoctorServices/doctor.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-appointments',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {
  @Input() userID!: string;
  appointments: any[] = [];
  statusFilter: string = '';  
  

  // Modal details
  isModalOpen: boolean = false;
  note: string = '';
  selectedAppointmentId!: number;

  constructor(private DoctorService: DoctorService) {}

  ngOnInit(): void {
    this.userID = localStorage.getItem('userID') || '';
    if (this.userID) {
    this.DoctorService.getAppointments(this.userID).subscribe(
      (data) => {  
        this.appointments = data?.$values || [];  
        console.log('appointments Data:', this.appointments); 
      },
      (error) => {
        console.error('Error fetching appointments:', error);
      }
    );
  }
  
  }

 
  get filteredAppointments() {
    return this.appointments.filter(appointment =>
      (!this.statusFilter || appointment.status === this.statusFilter)
    );
  }


  






















  //Open the module to add a note.
  openPopup(appointmentId: number) {
    this.selectedAppointmentId = appointmentId;
    this.isModalOpen = true;
  }

  // Close the module
  closeModal() {
    this.isModalOpen = false;
    this.note = '';
  }

  //Save note
  saveNote() {
    if (!this.note.trim()) {
      alert('Please write a note.');
      return;
    }

    this.DoctorService.updateNote(this.selectedAppointmentId, this.note).subscribe({
      next: () => {
        alert('Note saved successfully!');
        this.closeModal();
      },
      error: () => {
        console.error('Error saving note');
        alert('Failed to save the note. Please try again.');
      }
    });
  }










}























 











