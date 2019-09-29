import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/Auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  Login() {
    this.authService.Login(this.model).subscribe((res) => {
      const token = localStorage.getItem('token');
      this.alertify.success('success');

    }, (err) => { this.alertify.error(err); }, () => {
      this.router.navigate(['/members']);
    });
  }

  logout() {
    // tslint:disable-next-line: quotemark
    localStorage.removeItem("token");
    this.router.navigate(['/home']);

  }

  showProfile() {
    const token = localStorage.getItem("token");
    return token;
  }



}
