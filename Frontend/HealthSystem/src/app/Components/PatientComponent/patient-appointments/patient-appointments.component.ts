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

  constructor(private PatientService: PatientService) {}

  ngOnInit(): void {
    this.PatientService.getAppointments(this.userID).subscribe(
      (data) => {
        this.appointments = data;
      },
      (error) => {
        console.error('Error fetching appointments:', error);
        // Optionally display an error message to the user
      }
    );
    
}

statusFilter: string = '';

get filteredAppointments() {
  return this.appointments.filter(appointment =>
    (!this.statusFilter || appointment.status === this.statusFilter)
  );
}

}
