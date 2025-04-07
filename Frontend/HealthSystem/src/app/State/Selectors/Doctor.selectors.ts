// import { createFeatureSelector, createSelector } from '@ngrx/store';
// // import { DoctorState } from '../Reducers/Doctor.reducer';
// import { AppointmentsState } from '../Reducers/Doctor.reducer';






// // // Select the doctor state from the store
// // export const selectDoctorState = createFeatureSelector<DoctorState>('doctor');

// // // Selector to get doctor info from the state
// // // export const selectDoctorInfo = createSelector(
// // //   selectDoctorState,
// // //   (state: DoctorState) => state.doctorInfo
// // // );

// // export const selectDoctorInfo = (state: { doctor: DoctorState }) => state.doctor;


// // // export const selectDoctorInfo = createSelector(
// // //   selectDoctorState,
// // //   (state: DoctorState) => ({
// // //     firstName: state.firstName,
// // //     middleName: state.middleName,
// // //     lastName: state.lastName,
// // //     age: state.age,
// // //     birthDate: state.birthDate,
// // //     email: state.email,
// // //     phone: state.phone,
// // //     specialty: state.specialty,
// // //     gender: state.gender
// // //   })
// // // );


// // // Selector to get the loading state
// // export const selectLoading = createSelector(
// //   selectDoctorState,
// //   (state: DoctorState) => state.loading
// // );

// // // Selector to get the error state
// // export const selectError = createSelector(
// //   selectDoctorState,
// //   (state: DoctorState) => state.error
// // );

// // Get the full appointments state
// export const selectAppointmentsState = createFeatureSelector<AppointmentsState>('appointments');

// // Get all appointments
// export const selectAllAppointments = createSelector(
//   selectAppointmentsState,
//   (state) => state.appointments
// );

// // Get appointments for a specific doctor
// export const selectAppointmentsByDoctor = (doctorId: string) =>
//   createSelector(selectAllAppointments, (appointments) =>
//     appointments.filter(appointment => appointment.doctorUserID === doctorId)
//   );
