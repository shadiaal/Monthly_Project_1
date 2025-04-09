import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientSummaryComponent } from '../patient-summary/patient-summary.component';
import { PatientAppointmentsComponent } from '../patient-appointments/patient-appointments.component';
import { SignInService } from '../../../Services/SignInServices/sign-in.service';
import { HttpClientModule } from '@angular/common/http';
import { PatientService } from '../../../Services/PatientServices/patient.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-patient-dashboard',
  standalone: true,
  imports: [CommonModule, PatientSummaryComponent, PatientAppointmentsComponent, HttpClientModule],
  templateUrl: './patient-dashboard.component.html',
  styleUrls: ['./patient-dashboard.component.css']
})
export class PatientDashboardComponent implements OnInit {
  activeTab: string = 'summary';
  userID: string = '';
  patientName: string = '';

  constructor(
    private signInService: SignInService,
    private patientService: PatientService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.userID = localStorage.getItem('userID') || '';
    console.log('Hello from Patient Dashboard: User ID from localStorage:', this.userID);

    if (this.userID) {
      this.patientService.getPatientData(this.userID).subscribe(
        (data) => {
          this.patientName = `${data.user.firstName}`;
        },
        (error) => {
          console.error('Error fetching patient info:', error);
        }
      );
    }
  }

  showSummary() {
    this.activeTab = 'summary';
  }

  showAppointments() {
    this.activeTab = 'appointments';
  }

  navigateToInfo(): void {
    this.activeTab = 'summary';
  }

  navigateToAppointments(): void {
    this.activeTab = 'appointments';
  }

  // Navigate to Login Page
  showLogin() {
    localStorage.removeItem('userID');
    this.router.navigate(['/signin']);
  }
}



