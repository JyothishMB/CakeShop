import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../_models/User';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  userRegistrationForm: FormGroup;
  user : User;
  
  constructor(private fb: FormBuilder
      , private userservice: UserService) { }

  ngOnInit() {
    this.userRegistrationForm = this.fb.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  Register(){
    if(this.userRegistrationForm.valid){
      this.user = Object.assign({}, this.userRegistrationForm.value);

      this.userservice
        .registerUser(this.user)
        .subscribe((data) => {
          alert(data);
        });
    }
  }

}
