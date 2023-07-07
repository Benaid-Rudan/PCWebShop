import { Component, OnInit } from '@angular/core';
import {AutentifikacijaHelper} from "../../../helpers/autentifikacija-helper";
import {LoginInformacije} from "../../../helpers/login-informacije";
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {mojConfig} from "../../../moj-config";
import {NarudzbaService} from "../../../helpers/Narudzba-service";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-korisnik-proizvodi-detaljno',
  templateUrl: './korisnik-proizvodi-detaljno.component.html',
  styleUrls: ['./korisnik-proizvodi-detaljno.component.css']
})
export class KorisnikProizvodiDetaljnoComponent implements OnInit {
  proizvodGet: any;
  sub:any;
  private id:number;
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute,private narudzbaService:NarudzbaService) {}


  ngOnInit(): void {
    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

    });
    this.preuzmiPodatke();
  }


  private preuzmiPodatke() {
    this.httpKlijent.get(mojConfig.adresa_servera+ `/Proizvod/Get/${this.id}`, mojConfig.http_opcije()).subscribe(x=>{
      this.proizvodGet = x
    });
  }
  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }
  dodajUKorpu(p:any) {
    this.narudzbaService.addtoCart(p);
    porukaSuccess("Proizvod uspjesno dodan u korpu!");
  }
  getSlika(p: any) {
    return `https://localhost:44304/Proizvod/GetSlikaProizvoda/${p}`;
  }
}
