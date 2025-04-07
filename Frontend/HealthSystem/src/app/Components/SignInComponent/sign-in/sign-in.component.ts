import { Component } from '@angular/core';
import { SignInService } from '../../../Services/SignInServices/sign-in.service';
import { FormsModule } from '@angular/forms'; 
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; 
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  standalone: true,
  imports: [FormsModule, CommonModule, HttpClientModule],
  providers: [SignInService],
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SigninComponent {
  userID: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private signInService: SignInService, private router: Router) {}

  signIn(): void {
    if (!this.userID || !this.password) {
      this.errorMessage = 'Please enter both ID and password.';
      return;
    }

    this.signInService.signIn(this.userID, this.password).subscribe({
      next: (response) => {
        // Store the token in localStorage (or sessionStorage, if preferred)
        this.signInService.storeToken(response.token);
        localStorage.setItem('token', response.token); // Add this line

        

        // Store the userId in localStorage after successful login
        localStorage.setItem('userID', this.userID); // <-- Store userId here!
        console.log('User ID stored:', this.userID);
        

        // Redirect based on user role
        this.redirectUser(response.role);
      },
      error: (err) => {
        console.error('Sign-in error', err);
        this.errorMessage = 'Invalid email or password.';
      }
    });
  }

  private redirectUser(role: string): void {
    // Redirect user based on their role (Admin, Doctor, Patient)
    switch (role) {
      case 'Admin':
        this.router.navigate(['/admin-dashboard']);
        break;
      case 'Doctor':
        this.router.navigate(['/doctor-dashboard']);
        break;
      case 'Patient':
        this.router.navigate(['/patient-dashboard']);
        break;
      default:
        this.router.navigate(['/']);
    }
  }
}

