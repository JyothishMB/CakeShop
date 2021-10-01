import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Loginmodel } from '../_models/loginmodel';
import { UserService } from '../_services/user.service';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../_models/User';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userLoginForm: FormGroup;
  user : Loginmodel;

  constructor(private fb: FormBuilder
    , private userservice: UserService
    , private router: Router) { }

  ngOnInit() {
    this.userLoginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  login() {
    if(this.userLoginForm.valid){
      this.user = Object.assign({}, this.userLoginForm.value);

      this.userservice
        .login(this.user)
        .subscribe((data : any) => {
          debugger;
          localStorage.setItem("caketoken", data["token"]);
          this.router.navigate(['/cakelist']);
        });
    }
  }

}
