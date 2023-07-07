import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {LoginInformacije} from "../../helpers/login-informacije";
import {AutentifikacijaHelper} from "../../helpers/autentifikacija-helper";
import {mojConfig} from "../../moj-config";
import {NarudzbaService} from "../../helpers/Narudzba-service";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-korisnik-proizvodi-svi',
  templateUrl: './korisnik-proizvodi-svi.component.html',
  styleUrls: ['./korisnik-proizvodi-svi.component.css']
})
export class KorisnikProizvodiSviComponent implements OnInit {
   proizvodPodaci: any;
   filter: any;

  constructor(private httpKlijent: HttpClient,private narudzbaService:NarudzbaService) {}

  ngOnInit(): void {
    this.preuzmiPodakte();

  }
  getProizvod() {
    if (this.proizvodPodaci==null)
      return [];
    if(this.filter==null)
      return this.proizvodPodaci;
    return this.proizvodPodaci.filter((x: any)=> x.nazivProizvoda.length==0 || (x.nazivProizvoda).toLowerCase().startsWith(this.filter.toLowerCase()));
  }
  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  preuzmiPodakte() {
    this.httpKlijent.get(mojConfig.adresa_servera+ `/Proizvod/GetAll`, mojConfig.http_opcije()).subscribe(x=>{
      this.proizvodPodaci = x
    });
  }

  getSlikaProizvoda(p: any) {
    return `https://localhost:44304/Proizvod/GetSlikaProizvoda/${p.proizvodID}`;
  }

  dodajUKorpu(p:any) {
    this.narudzbaService.addtoCart(p);
    porukaSuccess("Proizvod uspjesno dodan u korpu!")
  }
}
