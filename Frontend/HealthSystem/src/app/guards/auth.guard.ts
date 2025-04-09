/*import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { SignInService } from '../Services/SignInServices/sign-in.service';

export const authGuard = (allowedRoles: string[]): CanActivateFn => {
  return () => {
    const router = inject(Router);
    const signInService = inject(SignInService);
    
    const token = signInService.getToken(); // Assuming JWT stored in localStorage
    const role = signInService.getUserRole(); // You should store role after login

    if (!token || !role) {
      router.navigate(['/signin']);
      return false;
    }

    if (!allowedRoles.includes(role)) {
      router.navigate(['/unauthorized']); // Optional: create an unauthorized page
      return false;
    }

    return true;
  };
};*/
