import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddcakeComponent } from './Admin/addcake/addcake.component';
import { AuthComponent } from './Auth/Auth.component';
import { CakelistComponent } from './cakelist/cakelist.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [
  { path:"cakelist", component:CakelistComponent },
  { path:"addcake", component:AddcakeComponent },
  {
    path: 'auth', 
    component: AuthComponent,
    children: [
      { path: "login", component: LoginComponent },
      { path: "signup", component: SignupComponent },
      { path: "", component: LoginComponent },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
