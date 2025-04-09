import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap,map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  private apiUrl = 'https://localhost:7021/api/doctor'; 

  constructor(private http: HttpClient) {}





getDoctorData(userID: string): Observable<any> {
  const token = localStorage.getItem('token');
  if (!token) {
    throw new Error('Token not found');
  }
  const headers = new HttpHeaders({
    'Authorization': `Bearer ${token}`
  });
  return this.http.get(`${this.apiUrl}/${userID}`, { headers });
}

    

getAppointments(userID: string): Observable<any> {
  const token = localStorage.getItem('token');
  if (!token) {
    throw new Error('Token not found');
  }
  const headers = new HttpHeaders({
    'Authorization': `Bearer ${token}`
  });
  return this.http.get<any>(`${this.apiUrl}/${userID}/appointments`,{ headers }).pipe(
    tap((data) => console.log('Appointments:', data))
  );
}

//  updateNote(appointmentId: number, note: string): Observable<any> {
//   const token = localStorage.getItem('token');
//   if (!token) {
//     throw new Error('Token not found');
//   }
//   const headers = new HttpHeaders({
//     'Authorization': `Bearer ${token}`
//   });
//     const url = `${this.apiUrl}/appointments/${appointmentId}/notes`; 
//     return this.http.put(url, { note }, { headers });


// }

// updateNote(appointmentId: number, note: string): Observable<any> {
//   const token = localStorage.getItem('token');
//   if (!token) {
//     throw new Error('Token not found');
//   }

//   const headers = new HttpHeaders({
//     'Authorization': `Bearer ${token}`,
//     'Content-Type': 'application/json'  // Ensure Content-Type is set to JSON
//   });

//   const url = `${this.apiUrl}/appointments/${appointmentId}/notes`;

//   // Send the note as a plain string
//   return this.http.put(url, note, { headers });
// }
updateNote(appointmentId: number, note: string): Observable<any> {
  const token = localStorage.getItem('token');
  if (!token) {
    throw new Error('Token not found');
  }

  const headers = new HttpHeaders({
    'Authorization': `Bearer ${token}`,
    'Content-Type': 'application/json'
  });

  const url = `${this.apiUrl}/appointments/${appointmentId}/notes`;

  return this.http.put(url, JSON.stringify(note), { headers }); 
}


}