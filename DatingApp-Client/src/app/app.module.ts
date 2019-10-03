import { MemberDetailsComponent } from './memebers/member-Details/member-Details.component';
import { MemberItemComponent } from './memebers/member-item/member-item.component';
import { UserService } from './_services/User.service';
import { routes } from './../route';
import { LoginComponent } from './Register/Login/Login.component';
import { AuthService } from './_services/Auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './Home/Home.component';
import { RegisterComponent } from './Register/Register.component';
import { MemebersComponent } from './memebers/memebers.component';
import { ListComponent } from './list/list.component';
import { MessagesComponent } from './messages/messages.component';
import { RouterModule } from '@angular/router';
import { RoutegardGuard } from './_guards/routegard.guard';
import { NgxGalleryModule } from 'ngx-gallery';

@NgModule({
   declarations: [
      AppComponent,
      NavbarComponent,
      HomeComponent,
      RegisterComponent,
      LoginComponent,
      MemebersComponent,
      ListComponent,
      MessagesComponent,
      MemberItemComponent,
      MemberDetailsComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      NgxGalleryModule,
      RouterModule.forRoot(routes)
   ],
   providers: [
      AuthService,
      RoutegardGuard,
      UserService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
