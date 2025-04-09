import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../../Services/AdminServices/admin.service';
import { saveAs } from 'file-saver';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { Router } from '@angular/router';
@Component({
  selector: 'app-doctor-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatCardModule
  ],
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent implements OnInit {
  doctors: any[] = [];
  displayedColumns: string[] = ['name', 'email', 'specialization', 'clinic', 'actions'];
  isLoading = true;
  errorMessage = '';
  // Clinic type mapping
  clinicNames: { [key: number]: string } = {
    0: 'General',
    1: 'Cardiology',
    2: 'Dermatology',
    3: 'Pediatrics',
    4: 'Orthopedics',
    5: 'Neurology',
    6: 'Dentistry',
    7: 'Ophthalmology',
    8: 'Psychiatry',
    9: 'Gynecology'
  };
  constructor(private adminService: AdminService,private router: Router) {}

  ngOnInit(): void {
    this.loadDoctors();
  }

  loadDoctors(): void {
    this.isLoading = true;
    this.errorMessage = '';
    
    this.adminService.getDoctors().subscribe({
      next: (response) => {
        console.log('Doctors response:', response);
        this.doctors = response.$values;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = 'Failed to load doctors. Please try again later.';
        this.isLoading = false;
        console.error('Error loading doctors:', err);
      }
    });
  }

  downloadDoctorExcel(doctorId: string): void {
    this.adminService.downloadDoctorExcel(doctorId).subscribe({
      next: (data) => {
        const blob = new Blob([data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        saveAs(blob, `doctor_${doctorId}_data.xlsx`);
      },
      error: (err) => {
        console.error('Error downloading Excel:', err);
        alert('Failed to download Excel file. Please try again.');
      }
    });
  }

  navigateToCreateDoctor() {
    this.router.navigate(['/admin/create-doctor']);
  }
}