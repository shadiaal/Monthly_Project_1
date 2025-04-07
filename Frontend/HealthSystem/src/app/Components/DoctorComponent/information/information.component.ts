
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';
import { Component, Input, OnInit } from '@angular/core';
import { DoctorService } from '../../../Services/DoctorServices/doctor.service';
import { HttpClientModule } from '@angular/common/http'; 

@Component({
  selector: 'app-information',
  standalone: true,
  imports: [CommonModule,FormsModule],

  templateUrl: './information.component.html',
  providers: [DoctorService],
  styleUrl: './information.component.css'
})
export class InformationComponent implements OnInit {

  @Input() userID!: string;
  DoctorData: any;

  constructor(private DoctorService: DoctorService) {}

  ngOnInit(): void {
    this.userID = localStorage.getItem('userID') || '';

    if (this.userID) {
      this.DoctorService.getDoctorData(this.userID).subscribe({
        next: (data) => {
          this.DoctorData = data;
          console.log('Doctor Data:', data);
        },
        error: (error) => {
          console.error('Error fetching Doctor data:', error);
        }
      });
  
   }
    
  }
}


 
  
 












