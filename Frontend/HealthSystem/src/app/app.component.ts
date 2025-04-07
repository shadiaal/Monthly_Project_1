import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
@Component({
  selector: 'app-root',
  standalone: true,  
  imports: [RouterOutlet, RouterModule],  
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']  
})
export class AppComponent {
  title = 'HealthSystem';

  // constructor(private router: Router) {}

  // // Navigate to Doctor Info Page
  // navigateToInfo() {
  //   this.router.navigate(['/Information']);
  // }

  // // Navigate to Appointments Page
  // navigateToAppointments() {
  //   this.router.navigate(['/appointments']);
  // }
  // // Navigate to Login Page
  // navigateToLogin(){
  //   this.router.navigate(['/Login']);
  // }
}
