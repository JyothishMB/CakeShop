import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Cake } from '../_models/Cake';

@Injectable({
  providedIn: 'root'
})
export class CakeService {

  baseUrl = environment.apiUrl; 

  

  constructor(private http: HttpClient) { }

  addCake(cake : Cake){
    return this.http.post(this.baseUrl+'Cake/AddCake', cake);
  }

  getCakes(){
    return this.http.get(this.baseUrl+'Cake/GetCakes');
  }

}
