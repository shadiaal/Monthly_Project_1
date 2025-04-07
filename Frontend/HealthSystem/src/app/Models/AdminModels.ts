// Models/AdminModels.ts
export interface Doctor {
    user: {
      id: string;
      firstName: string;
      middleName: string;
      lastName: string;
      email: string;
      phoneNumber: string;
    };
    gender: string;
    specialization: string;
    clinic: string;
    workingHours: WorkingHours[];
  }
  
  export interface WorkingHours {
    day: string;
    startTime: string;
    endTime: string;
  }
  
  export interface CreateDoctorRequest {
    FirstName: string;
    MiddleName: string;
    LastName: string;
    Email: string;
    PhoneNumber: string;
    Password: string;
    Gender: string;
    Specialization: string;
    Clinic: string;
    WorkingHours: WorkingHoursRequest[];
  }
  
  export interface WorkingHoursRequest {
    Day: string;
    StartTime: string;
    EndTime: string;
  }
  