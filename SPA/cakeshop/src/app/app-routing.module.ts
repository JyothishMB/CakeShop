import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddcakeComponent } from './Admin/addcake/addcake.component';
import { AuthComponent } from './Auth/Auth.component';
import { CakelistComponent } from './cakelist/cakelist.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  { path: "home", component:HomeComponent },
  { path:"cakelist", component:CakelistComponent, canActivate: [AuthGuard], runGuardsAndResolvers: 'always' },
  { path:"addcake", component:AddcakeComponent, canActivate: [AuthGuard], runGuardsAndResolvers: 'always' },
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
