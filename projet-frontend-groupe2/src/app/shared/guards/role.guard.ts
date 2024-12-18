import {CanActivate, CanActivateFn, Router} from '@angular/router';
import {Injectable} from '@angular/core';
import {AuthService} from '../services/auth/auth.service';
import {map, Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: any): Observable<boolean> {
    const allowedRoles = route.data['roles'];

    return this.authService.getRole().pipe(
      map((role) => {
        if (allowedRoles.includes(role)) {
          return true;
        }

        this.router.navigate(['/not-authorized']);
        return false;
      })
    );
  }
}
