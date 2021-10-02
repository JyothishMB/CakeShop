import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

import { Loginmodel } from '../_models/loginmodel';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.apiUrl; 
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: any;

  constructor(private http: HttpClient) { }

  registerUser(user : User){
    return this.http.post(this.baseUrl+'Auth/Register', user);
  }

  login(loginmodel: Loginmodel){
    return this.http.post(this.baseUrl+'Auth/Login',loginmodel)
      .pipe(
        map((response : any) => {
          const user = response;
          if (user){
            debugger;
            localStorage.setItem('token', user.token);
            localStorage.setItem('user', JSON.stringify(user.user));
            this.decodedToken = this.jwtHelper.decodeToken(user.token);
            this.currentUser = user.user;
            // console.log(this.decodedToken);
          }
        })
      );
  }


  loggedIn(){
    let token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

}
