import { User } from './../../_models/User';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-member-item',
  templateUrl: './member-item.component.html',
  styleUrls: ['./member-item.component.css']
})
export class MemberItemComponent implements OnInit {
  @Input() user: User;
  constructor() { }

  ngOnInit() {
  }

  GetAge(dob: Date) {
    if (dob) {
      //convert date again to type Date
      const bdate = new Date(dob);
      const timeDiff = Math.abs(Date.now() - bdate.getTime() );
      return Math.floor((timeDiff / (1000 * 3600 * 24)) / 365);
    }
  }

}
