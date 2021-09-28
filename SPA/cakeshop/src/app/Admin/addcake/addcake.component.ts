import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Cake } from 'src/app/_models/Cake';
import { CakeService } from 'src/app/_services/cake.service';

@Component({
  selector: 'app-addcake',
  templateUrl: './addcake.component.html',
  styleUrls: ['./addcake.component.css']
})
export class AddcakeComponent implements OnInit {

  cakeAddForm: FormGroup;
  cake: Cake;
  

  constructor(private fb: FormBuilder
    , private cakeservice: CakeService) { }

  ngOnInit() {
    this.cakeAddForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required]
    });
  }

  addCake(){

    if(this.cakeAddForm.valid){
      this.cake = Object.assign({}, this.cakeAddForm.value);
      this.cakeservice
        .addCake(this.cake)
        .subscribe(() => {
          alert('Cake Added!');
        }, (error) => {
          alert(error)
        });
    }
  }
  
  cancel(){

  }

}
