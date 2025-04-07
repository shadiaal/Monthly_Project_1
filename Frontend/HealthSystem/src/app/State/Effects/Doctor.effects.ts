// import { Injectable } from '@angular/core';
// import { Actions, createEffect, ofType } from '@ngrx/effects';
// import { catchError, map, mergeMap, of } from 'rxjs';
// import { HttpErrorResponse } from '@angular/common/http';
// import * as DoctorActions from '../Actions/Doctor.actions';
// import { InformationService } from '../../Services/DoctorServices/information.service';
// import { AppointmentService } from '../../Services/DoctorServices/appointment.service'; 

// // @Injectable()
// // export class DoctorEffects {
// //   constructor(private actions$: Actions, private doctorService: InformationService) {}

// // //   loadDoctorInfo$ = createEffect(() =>
// //     this.actions$.pipe(
// //       ofType(DoctorActions.loadDoctorInfo),
// //       mergeMap(() =>
// //         this.doctorService.getDoctorInfo().pipe(
// //           map(data => {
// //             if (!data || typeof data !== 'object') {
// //               throw new Error('Invalid data format');
// //             }
// //             const doctorInfo = Object.entries(data).map(([key, value]) => ({ label: key, value }));
// //             return DoctorActions.loadDoctorInfoSuccess({ doctorInfo });
// //           }),
// //           catchError((error: HttpErrorResponse) =>
// //             of(DoctorActions.loadDoctorInfoFailure({ error: error.message }))
// //           )
// //         )
// //       )
// //     )
// //   );
// // }
// // loadDoctorInfo$ = createEffect(() =>
// //   this.actions$.pipe(
// //     ofType(DoctorActions.loadDoctorInfo),
// //     mergeMap(() =>
// //       this.doctorService.getDoctorInfo().pipe(
// //         map(data => {
// //           if (!data || typeof data !== 'object') {
// //             throw new Error('Invalid data format');
// //           }

         
// //           return DoctorActions.loadDoctorInfoSuccess({ doctorInfo: data });
// //         }),
// //         catchError((error: HttpErrorResponse) =>
// //           of(DoctorActions.loadDoctorInfoFailure({ error: error.message }))
// //         )
// //       )
// //     )
// //   )
// // );
// // }

// @Injectable()
// export class AppointmentsEffects {
//   constructor(private actions$: Actions, private appointmentService: AppointmentService) {}

//   loadAppointments$ = createEffect(() =>
//     this.actions$.pipe(
//       ofType(DoctorActions.loadAppointmentsByDoctor),
//       mergeMap(action =>
//         this.appointmentService.getAppointmentsByDoctor(action.doctorId).pipe(
//           map(appointments => DoctorActions.loadAppointmentsSuccess({ appointments }))
//         )
//       )
//     )
//   );
// }
