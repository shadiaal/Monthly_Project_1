import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private apiUrl = 'https://localhost:7021/api/admin';

  constructor(private http: HttpClient) { }

  getBarChartData(): Observable<any> {
    return this.http.get(`${this.apiUrl}/graph/barChart`);
  }

  getPieChartData(): Observable<any> {
    return this.http.get(`${this.apiUrl}/graph/piechart`);
  }

  createPatient(patientData: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/create-patient`, patientData);
  }
}