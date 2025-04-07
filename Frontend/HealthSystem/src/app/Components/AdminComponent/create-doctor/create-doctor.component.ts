// create-doctor.component.ts
import { Component } from '@angular/core';
import { CommonModule} from '@angular/common';

import {ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { AdminService } from '../../../Services/AdminServices/admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-doctor',
  templateUrl: './create-doctor.component.html',
  imports: [CommonModule, ReactiveFormsModule],
  styleUrls: ['./create-doctor.component.css']
})
export class CreateDoctorComponent {
  doctorForm: FormGroup;
  daysOfWeek = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
  genders = ['Male', 'Female'];
  clinics = ['General', 'Cardiology', 'Dermatology', 'Neurology', 'Pediatrics', 'Orthopedics'];
  isLoading = false;
  errorMessage = '';
  successMessage = '';

  constructor(
    private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router
  ) {
    this.doctorForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]],
      gender: ['Male', Validators.required],
      specialization: ['', Validators.required],
      clinic: ['General', Validators.required],
      workingHours: this.fb.array([this.createWorkingHoursGroup()])
    });
  }

  createWorkingHoursGroup(): FormGroup {
    return this.fb.group({
      day: ['Monday', Validators.required],
      startTime: ['09:00', Validators.required],
      endTime: ['17:00', Validators.required]
    });
  }

  get workingHoursArray() {
    return this.doctorForm.get('workingHours') as FormArray;
  }

  addWorkingHours() {
    this.workingHoursArray.push(this.createWorkingHoursGroup());
  }

  removeWorkingHours(index: number) {
    if (this.workingHoursArray.length > 1) {
      this.workingHoursArray.removeAt(index);
    }
  }

  onSubmit() {
    if (this.doctorForm.invalid) {
      this.errorMessage = 'Please fill all required fields correctly.';
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';

    const formData = this.doctorForm.value;
    const requestData = {
      FirstName: formData.firstName,
      MiddleName: formData.middleName,
      LastName: formData.lastName,
      Email: formData.email,
      PhoneNumber: formData.phoneNumber,
      Password: formData.password,
      Gender: formData.gender,
      Specialization: formData.specialization,
      Clinic: formData.clinic,
      WorkingHours: formData.workingHours.map((wh: any) => ({
        Day: wh.day,
        StartTime: wh.startTime,
        EndTime: wh.endTime
      }))
    };

    this.adminService.createDoctor(requestData).subscribe({
      next: (response) => {
        this.successMessage = 'Doctor created successfully!';
        this.isLoading = false;
        // Optionally reset form or navigate away
        // this.doctorForm.reset();
        // this.router.navigate(['/admin/doctors']);
      },
      error: (error) => {
        this.errorMessage = error.error?.message || 'Failed to create doctor. Please try again.';
        this.isLoading = false;
      }
    });
  }
}