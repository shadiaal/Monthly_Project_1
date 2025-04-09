import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SigninComponent } from './Components/SignInComponent/sign-in/sign-in.component'; // Correct path

@Component({
  selector: 'app-root',
  standalone: true,  
  imports: [RouterOutlet],  
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'HealthSystem';

}
