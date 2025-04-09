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
 

  // Modal details
  isModalOpen: boolean = false;
  note: string = '';
  selectedAppointmentId!: number;

  


    @Input() userID!: string;
    appointments: any[] = [];
  
    constructor(private DoctorService: DoctorService) { }
  
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
  
  
    statusFilter: string = '';
  
   

    // get filteredAppointments() {
    //   if (!this.statusFilter) return this.appointments;
    
    //   const statusMap: { [key: string]: number } = {
    //     'Upcoming': 0,
    //     'Current': 1,
    //     'Past': 2
    //   };
    
    //   const selectedStatus = statusMap[this.statusFilter];
    //   return this.appointments.filter(appointment => appointment.status === selectedStatus);
    // }
    

    // getAppointmentStatus(appointmentDateString: string): string {
    //   const now = new Date();
    //   const appointmentDate = new Date(appointmentDateString);
    
    //   if (appointmentDate.toDateString() === now.toDateString()) {
    //     return 'Current';
    //   } else if (appointmentDate > now) {
    //     return 'Upcoming';
    //   } else {
    //     return 'Past';
    //   }
    // }
    



    // get filteredAppointments() {
    //   if (!this.statusFilter) return this.appointments;
  
    //   const now = new Date();
  
    //   return this.appointments.filter(appointment => {
    //     const appointmentDate = new Date(appointment.appointmentDate);
  
    //     if (this.statusFilter === 'Upcoming') {
    //       return appointmentDate > now;
    //     } else if (this.statusFilter === 'Current') {
    //       return appointmentDate.toDateString() === now.toDateString();
    //     } else if (this.statusFilter === 'Past') {
    //       return appointmentDate < now && appointmentDate.toDateString() !== now.toDateString();
    //     }
  
    //     return true;
    //   });
    // }
  
    

    get filteredAppointments() {
      if (!this.statusFilter) return this.appointments.map(appointment => this.updateAppointmentStatus(appointment));
    
      const now = new Date();
    
      return this.appointments.filter(appointment => {
        const appointmentDate = new Date(appointment.appointmentDate);
    
        if (this.statusFilter === 'Upcoming') {
          return appointmentDate > now;
        } else if (this.statusFilter === 'Current') {
          return appointmentDate.toDateString() === now.toDateString();
        } else if (this.statusFilter === 'Past') {
          return appointmentDate < now && appointmentDate.toDateString() !== now.toDateString();
        }
    
        return true;
      }).map(appointment => this.updateAppointmentStatus(appointment));
    }
    
    private updateAppointmentStatus(appointment: any) {
      const now = new Date();
      const appointmentDate = new Date(appointment.appointmentDate);
    
      if (appointmentDate > now) {
        appointment.statusText = 'Upcoming';
      } else if (appointmentDate.toDateString() === now.toDateString()) {
        appointment.statusText = 'Current';
      } else {
        appointment.statusText = 'Past';
      }
    
      return appointment;
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























 








