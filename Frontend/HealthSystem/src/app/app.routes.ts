import { Routes } from '@angular/router';
import { SigninComponent } from './Components/SignInComponent/sign-in/sign-in.component';
import { PatientDashboardComponent } from './Components/PatientComponent/patient-dashboard/patient-dashboard.component';


export const routes: Routes = [
  { path: '', redirectTo: '/signin', pathMatch: 'full' },
  { path: 'signin', component: SigninComponent },
  { path: 'patient-dashboard', component: PatientDashboardComponent }
];

/*
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: '/signin', pathMatch: 'full' },
  { path: 'signin', component: SigninComponent },

  {
    path: 'patient-dashboard',
    component: PatientDashboardComponent,
    canActivate: [authGuard(['Patient'])]
  },
  {
    path: 'doctor-dashboard',
    //component: DoctorDashboardComponent,
    canActivate: [authGuard(['Doctor'])]
  },
  {
    path: 'admin-dashboard',
    //component: AdminDashboardComponent,
    canActivate: [authGuard(['Admin'])]
  },
  {
    path: 'unauthorized',
   // loadComponent: () => import('./Components/Unauthorized/unauthorized.component').then(m => m.UnauthorizedComponent)
  }
];*/