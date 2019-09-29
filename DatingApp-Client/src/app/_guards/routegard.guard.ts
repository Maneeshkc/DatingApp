import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/Auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoutegardGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router, private alertify: AlertifyService) { }
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (this.auth.IsLogin()) {
      return true;

    }
    this.alertify.error('not authorized to view this page');
    this.router.navigate(['/']);
  }
}
