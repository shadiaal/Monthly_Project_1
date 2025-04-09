// services/patient.service.ts
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private apiUrl = 'https://localhost:7021/api/patients';

  constructor(private http: HttpClient) { }




  // In patient.service.ts
  getPatientData(userID: string): Observable<any> {

    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    return this.http.get(`${this.apiUrl}/getPatientData/${userID}`, { headers });


  }


  getAppointments(userID: string): Observable<any> {

    const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    return this.http.get<any>(`${this.apiUrl}/getAppointments/${userID}`, { headers }).pipe(
      tap((data) => console.log('Appointments:', data))
    );
  }


}
