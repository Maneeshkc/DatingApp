import { AlertifyService } from './../_services/alertify.service';
import { User } from './../_models/User';
import { UserService } from './../_services/User.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-memebers',
  templateUrl: './memebers.component.html',
  styleUrls: ['./memebers.component.css']
})
export class MemebersComponent implements OnInit {
  users: User[];
  constructor(private userService: UserService, private alertfy: AlertifyService) { }

  ngOnInit() {
    this.GetMembers();
    console.log(this.users);

  }

  GetMembers() {
    this.userService.getUsers().subscribe(tempUser => {
      this.users = tempUser;
    },
      err => {
        return this.alertfy.error(err);
      });
  }

}
