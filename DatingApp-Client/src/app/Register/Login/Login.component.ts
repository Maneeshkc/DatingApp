import { AuthService } from './../../_services/Auth.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-Login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {

  model: any = {};
  @Output() regEmitter = new EventEmitter();
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  gotoRegister() {
    this.regEmitter.emit(true);
  }

  Login() {
    this.authService.Login(this.model).subscribe((res) => {
      const token = localStorage.getItem('token');
      console.log(token);
      this.model = {};
      this.regEmitter.emit(true);

    }, (err) => { console.log(err); }, () => { this.router.navigate(['/members']); });
  }

}
