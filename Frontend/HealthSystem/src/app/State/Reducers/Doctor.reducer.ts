// import { createReducer, on } from '@ngrx/store';
// import * as DoctorActions from '../Actions/Doctor.actions';
// import { Appointment } from '../../Services/DoctorServices/appointment.service'; 
// // Define the initial state for doctor info
// // export interface DoctorState {
// //   doctorInfo: { label: string; value: string }[];
// //   loading: boolean;
// //   error: string | null;
  
// // }

// // export interface DoctorState {
// //   firstName: string;
// //   middleName: string;
// //   lastName: string;
// //   age: number;
// //   birthDate: string;
// //   email: string;
// //   phone: string;
// //   specialty: string;
// //   gender: string; 
  
// //   loading: boolean;

// //   error: string | null;
// // }

// // // export const initialState: DoctorState = {
// // //   doctorInfo: [],
// // //   loading: false,
// // //   error: null
// // // };
// // export const initialState: DoctorState = {
// //   firstName: '',
// //   middleName: '',
// //   lastName: '',
// //   age: 0,
// //   birthDate: '',
// //   email: '',
// //   phone: '',
// //   specialty: '',
// //   gender: '',
// //   loading: false,
// //   error: null
// // };

// // // Reducer to handle actions and state changes
// // // export const doctorReducer = createReducer(
// // //   initialState,
// // //   on(DoctorActions.loadDoctorInfo, (state) => ({ ...state, loading: true, error: null })),
// // //   on(DoctorActions.loadDoctorInfoSuccess, (state, { doctorInfo }) => ({
// // //     ...state,
// // //     doctorInfo,
// // //     loading: false,
// // //     error: null
// // //   })),
// // //   on(DoctorActions.loadDoctorInfoFailure, (state, { error }) => ({
// // //     ...state,
// // //     error,
// // //     loading: false
// // //   }))
// // // );
// // export const doctorReducer = createReducer(
// //   initialState,
// //   on(DoctorActions.loadDoctorInfo, (state) => ({
// //     ...state,
// //     loading: true,
// //     error: null
// //   })),
// //   on(DoctorActions.loadDoctorInfoSuccess, (state, { doctorInfo }) => ({
// //     ...state,
// //     firstName: doctorInfo.firstName,
// //     middleName: doctorInfo.middleName,
// //     lastName: doctorInfo.lastName,
// //     age: doctorInfo.age,
// //     birthDate: doctorInfo.birthDate,
// //     email: doctorInfo.email,
// //     phone: doctorInfo.phone,
// //     specialty: doctorInfo.specialty,
// //     gender: doctorInfo.gender,
// //     loading: false,
// //     error: null
// //   })),
// //   on(DoctorActions.loadDoctorInfoFailure, (state, { error }) => ({
// //     ...state,
// //     error,
// //     loading: false
// //   }))
// // );

// export interface AppointmentsState {
//   appointments: Appointment[];
// }

// const initialStateAppointments: AppointmentsState = {
//   appointments: []
// };

// export const appointmentsReducer = createReducer(
//   initialStateAppointments,
//   on(DoctorActions.loadAppointmentsSuccess, (state, { appointments }) => ({
//     ...state,
//     appointments
//   }))
// );




