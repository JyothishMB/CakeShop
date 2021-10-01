import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Loginmodel } from '../_models/loginmodel';
import { User } from '../_models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {

baseUrl = environment.apiUrl; 

constructor(private http: HttpClient) { }

registerUser(user : User){
  return this.http.post(this.baseUrl+'Auth/Register', user);
}

login(loginmodel: Loginmodel){
  return this.http.post(this.baseUrl+'Auth/Login',loginmodel);
}

}
