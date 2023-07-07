import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LoginInformacije} from "../helpers/login-informacije";
import {mojConfig} from "../moj-config";
import {AutentifikacijaHelper} from "../helpers/autentifikacija-helper";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  txtKorisnickoIme: any;
  txtLozinka: any;

  constructor(private httpKlijent: HttpClient ,private router:Router) {
  }

  ngOnInit(): void {
  }

  LoginDugme() {
    let saljemo = {
      korisnickoIme:this.txtKorisnickoIme,
      lozinka: this.txtLozinka
    };
    this.httpKlijent.post<LoginInformacije>(mojConfig.adresa_servera+ "/Autentifikacija/Login/", saljemo)
      .subscribe((x:LoginInformacije) =>{
        if (x.isLogiran) {
          AutentifikacijaHelper.setLoginInfo(x);
          this.Otvori()
        }
        else
        {
          AutentifikacijaHelper.setLoginInfo(null)
          porukaError("Došlo je do greške, pokušajte ponovno");
        }
      });
  }

  Otvori() {
    this.router.navigateByUrl("/pocetna")
      .then(() => {
        window.location.reload();
      });
  }
}
