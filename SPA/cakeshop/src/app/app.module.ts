import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CakelistComponent } from './cakelist/cakelist.component';
import { AddcakeComponent } from './Admin/addcake/addcake.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AuthComponent } from './Auth/Auth.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { HomeComponent } from './home/home.component';
import { UserService } from './_services/user.service';
import { CakeService } from './_services/cake.service';
import { AuthInterceptor } from './Helpers/interceptors/auth-interceptor';

@NgModule({
  declarations: [						
    AppComponent,
      NavbarComponent,
      CakelistComponent,
      AddcakeComponent,
      AuthComponent,
      LoginComponent,
      SignupComponent,
      HomeComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BsDropdownModule.forRoot()
  ],
  providers: [
    UserService,
    CakeService,
    {
      provide: HTTP_INTERCEPTORS, 
      useClass: AuthInterceptor, 
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
