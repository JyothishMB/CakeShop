import { Component, OnInit } from '@angular/core';
import { Cake } from '../_models/Cake';
import { CakeService } from '../_services/cake.service';

@Component({
  selector: 'app-cakelist',
  templateUrl: './cakelist.component.html',
  styleUrls: ['./cakelist.component.css']
})
export class CakelistComponent implements OnInit {

  cakes: Cake[];

  constructor(private cakeservice: CakeService) { }

  ngOnInit() {
    this.getCakes();
  }

  getCakes(){
    this.cakeservice
      .getCakes()
      .subscribe((data:any) => {
        debugger;
        const response = data;
        this.cakes = data.cakes;
      }, error => {
        console.log(error);
      });
  }

}
