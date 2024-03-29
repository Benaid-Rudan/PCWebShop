import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {AutentifikacijaHelper} from "../helpers/autentifikacija-helper";

@Injectable()
export class AutorizacijaAdminProvjera implements CanActivate {

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    try {
      //nedovrseno privremeno rjesenje
      if (AutentifikacijaHelper.getLoginInfo().isPermisijaAdmin)
        return true;
    }catch (e) {
    }

    // not logged in so redirect to login page with the return url
    this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
    return false;
  }
}
