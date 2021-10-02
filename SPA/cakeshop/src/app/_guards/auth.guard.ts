import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from '../_services/user.service'

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
    private userservice: UserService,
    private router: Router,
  ) { }

  canActivate(): boolean {
    if(this.userservice.loggedIn()){
      return true;
    }
    this.router.navigate(['/home']);
    return false;
  }
  
}
