import { RoutegardGuard } from './app/_guards/routegard.guard';
import { LoginComponent } from './app/Register/Login/Login.component';
import { MemebersComponent } from './app/memebers/memebers.component';
import { ListComponent } from './app/list/list.component';
import { MessagesComponent } from './app/messages/messages.component';
import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { HomeComponent } from './app/Home/Home.component';
export const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '', runGuardsAndResolvers: 'always', canActivate: [RoutegardGuard],
        children: [{ path: 'messages', component: MessagesComponent },
        { path: 'list', component: ListComponent },
        { path: 'members', component: MemebersComponent }]
    }
    ,
    { path: '**', redirectTo: '', pathMatch: 'full' }

];
