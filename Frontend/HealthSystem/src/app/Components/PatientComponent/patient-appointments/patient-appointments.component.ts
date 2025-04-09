import { Component, Input, OnInit } from '@angular/core';
import { PatientService } from '../../../Services/PatientServices/patient.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-patient-appointments',
  standalone: true,
  imports: [CommonModule, HttpClientModule, FormsModule],
  providers: [PatientService],
  templateUrl: './patient-appointments.component.html'
})
export class PatientAppointmentsComponent implements OnInit {
  @Input() userID!: string;
  appointments: any[] = [];

  constructor(private PatientService: PatientService) { }

  ngOnInit(): void {
    this.userID = localStorage.getItem('userID') || '';
    if (this.userID) {
      this.PatientService.getAppointments(this.userID).subscribe(
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

  get filteredAppointments() {
    return this.appointments.filter(appointment =>
      (!this.statusFilter || appointment.status === this.statusFilter)
    );
  }

}
