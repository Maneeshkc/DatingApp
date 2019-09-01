import { AuthService } from './../_services/Auth.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent implements OnInit {

  model: any = {};
  @Output() logEmitter = new EventEmitter;
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  gotoLogin() {
    this.logEmitter.emit(false);
  }

  Register() {
    this.authService.Register(this.model).subscribe((res) => {
      // const token = localStorage.getItem('token');
      console.log(res);
      alert('Added');
    }, (err) => {alert("Error while Adding user " + err.error); });
  }

}
