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
    /*
    const headers = new HttpHeaders();
    headers
      .set('Content-Type', 'application/json; charset=utf-8')
      .set('Access-Control-Allow-Origin' , '*',)

    return this.http.post(this.baseUrl+'Cake/AddCake', cake, { headers: headers });
    */
    return this.http.post(this.baseUrl+'Cake/AddCake', cake);
  }

  getCakes(){
    return this.http.get(this.baseUrl+'Cake/GetCakes');
  }

}
