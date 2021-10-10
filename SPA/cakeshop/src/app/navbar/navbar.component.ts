import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public userservice : UserService
    , private router: Router) { }

  ngOnInit() {
    console.log(this.loggedIn());
    console.log(this.userservice.decodedToken);
  }

  loggedIn(){
    //const token = localStorage.getItem('token');
    //return !!token;
    return this.userservice.loggedIn();
  }

  logout(){
    console.log(this.userservice);
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.userservice.decodedToken = null;
    this.userservice.currentUser = null;
    this.router.navigate(['/cakelist']);
  }

}
