
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentsComponent } from './Components/DoctorComponent/appointments/appointments.component';
import { InformationComponent } from './Components/DoctorComponent/information/information.component';
import { SigninComponent } from './Components/SignInComponent/sign-in/sign-in.component';
import { DoctorDashboardComponent } from './Components/DoctorComponent/doctor-dashboard/doctor-dashboard.component';


export const routes: Routes = [
  { path: '', redirectTo: '/signin', pathMatch: 'full' },
  { path: 'signin', component: SigninComponent },
  {
    path: 'doctor-dashboard',
    component: DoctorDashboardComponent,
    children: [
      { path: 'information', component: InformationComponent },
      { path: 'appointments', component: AppointmentsComponent },
    ],
  },
  
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}





