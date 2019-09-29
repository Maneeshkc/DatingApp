import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5001/api/';
  constructor(private http: HttpClient) { }

  Login(model: any) {
    return this.http.post(this.baseUrl + 'auth/login', model)
      .pipe(map((res: any) => {
        localStorage.setItem('token', res.token);
      }));
  }

  IsLogin() {
    if (localStorage.getItem('token') === null) {
      return false;
    }
    return true;
  }

  Register(model: any) {
    return this.http.post(this.baseUrl + 'auth/Register', model)
      .pipe(map((res: any) => {
        //localStorage.setItem('token', res.token);
      }));
  }


}
