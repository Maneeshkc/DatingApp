import { AuthService } from './../_services/Auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  Login() {
    this.authService.Login(this.model).subscribe((res) => {
      const token = localStorage.getItem('token');
      console.log(token);
    }, (err) => { console.log(err); });
  }

  logout() {
    // tslint:disable-next-line: quotemark
    localStorage.removeItem("token");
  }

  showProfile() {
    const token = localStorage.getItem("token");
    return token;
  }



}
