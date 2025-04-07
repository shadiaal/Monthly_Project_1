import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router'; // Import RouterModule here

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, RouterModule],  // Add RouterModule to the imports array
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {

  constructor(
    private router: Router
  ) { }


}
