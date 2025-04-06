import { Routes } from '@angular/router';
import { AdminComponent } from './Components/AdminComponent/admin/admin.component';

import { CreatePatientComponent } from './Components/AdminComponent/create-patient/create-patient.component';
import { AppComponent } from './app.component';
import { AdminDashboardComponent } from './Components/AdminComponent/admin-dashboard/admin-dashboard.component';
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
        ],
    },

];
