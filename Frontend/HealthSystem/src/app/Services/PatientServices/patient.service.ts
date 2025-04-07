// services/patient.service.ts
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class PatientService {
  private apiUrl = 'http://localhost:5187/api/patients'; 

  constructor(private http: HttpClient) {}


  /*getPatientData(userID: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/getPatientData/${userID}`);
  }

  getAppointments(userID: string): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getAppointments/${userID}`);
  }*/

  // In patient.service.ts
getPatientData(userID: string): Observable<any> {

  const token = localStorage.getItem('token');

    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });

    return this.http.get(`${this.apiUrl}/getPatientData/${userID}`, { headers });

  /*return this.http.get(`${this.apiUrl}/getPatientData/${userID}`).pipe(
    tap((data) => console.log('Patient Data:', data))  // Add this line to log the response
  );*/
}

getAppointments(userID: string): Observable<any[]> {
  return this.http.get<any[]>(`${this.apiUrl}/getAppointments/${userID}`).pipe(
    tap((data) => console.log('Appointments:', data))  // Add this line to log the response
  );
}

}
