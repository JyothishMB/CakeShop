import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddcakeComponent } from './Admin/addcake/addcake.component';
import { CakelistComponent } from './cakelist/cakelist.component';

const routes: Routes = [
  { path:"cakelist", component:CakelistComponent },
  { path:"addcake", component:AddcakeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
