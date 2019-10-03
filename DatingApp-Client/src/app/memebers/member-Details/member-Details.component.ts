import { User } from './../../_models/User';
import { AlertifyService } from './../../_services/alertify.service';
import { UserService } from './../../_services/User.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage } from 'ngx-gallery';

@Component({
  selector: 'app-member-Details',
  templateUrl: './member-Details.component.html',
  styleUrls: ['./member-Details.component.css']
})
export class MemberDetailsComponent implements OnInit {
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[] = [];
  user: User;
  tabIndex = 1;
  constructor(private userService: UserService, private alerity: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.galleryOptions = [
      {
        width: '600px',
        height: '400px',
        thumbnailsColumns: 4
      },
      // max-width 800
      {
        breakpoint: 800,
        width: '100%',
        height: '600px',
        imagePercent: 80,
        thumbnailsPercent: 20,
        thumbnailsMargin: 20,
        thumbnailMargin: 20
      },
      // max-width 400
      {
        breakpoint: 400,
        preview: false
      }
    ];

    this.GetUserDetails();


  }

  GetUserDetails() {
    const userId: number = +this.route.snapshot.paramMap.get('id');
    this.userService.getUser(userId).subscribe(user => {
      this.user = user;
      if (this.user.photo != null) {
        for (let i = 0; i < this.user.photo.length; i++) {
          this.galleryImages.push({
            small: this.user.photo[i],
            medium: this.user.photo[i],
            big: this.user.photo[i]
        });
        }
      }
    }, error => this.alerity.error(error));
  }

  TabClick(index: number) {
    this.tabIndex = index;
    return;
  }

}
