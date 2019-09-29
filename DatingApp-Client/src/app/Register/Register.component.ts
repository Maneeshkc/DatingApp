import { AuthService } from './../_services/Auth.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {};
  @Output() logEmitter = new EventEmitter;
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  gotoLogin() {
    this.logEmitter.emit(false);
    this.router.navigate(['login']);
  }

  Register() {
    this.authService.Register(this.model).subscribe((res) => {
      // const token = localStorage.getItem('token');
      console.log(res);
      alert('Added');
    }, (err) => {alert("Error while Adding user " + err.error); });
  }

}
