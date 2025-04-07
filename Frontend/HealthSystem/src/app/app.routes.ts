import { Routes } from '@angular/router';
import { AdminComponent } from './Components/AdminComponent/admin/admin.component';

import { CreatePatientComponent } from './Components/AdminComponent/create-patient/create-patient.component';
import { AppComponent } from './app.component';
import { AdminDashboardComponent } from './Components/AdminComponent/admin-dashboard/admin-dashboard.component';
import { CreateDoctorComponent } from './Components/AdminComponent/create-doctor/create-doctor.component';
import { DoctorListComponent } from './Components/AdminComponent/doctor-list/doctor-list.component';
import { AppointmentCreateComponent } from './Components/AdminComponent/appointment-create/appointment-create.component';
export const routes: Routes = [
    { path: '', component: AppComponent },
    // { path: 'admin', component: AdminComponent },
    // { path: 'admin/createPatient', component: CreatePatientComponent },


    {
        path: 'admin',
        component: AdminComponent, // يحتوي على sidebar
        children: [
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', component: AdminDashboardComponent },
            { path: 'createPatient', component: CreatePatientComponent },
            { path: 'create-doctor', component: CreateDoctorComponent },
            { path: 'doctors', component: DoctorListComponent },
            { path: 'appointments/create', component: AppointmentCreateComponent },
        ],
    },

];
