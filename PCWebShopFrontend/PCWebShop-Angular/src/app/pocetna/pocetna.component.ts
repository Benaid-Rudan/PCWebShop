import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {mojConfig} from "../moj-config";
import {LoginInformacije} from "../helpers/login-informacije";
import {AutentifikacijaHelper} from "../helpers/autentifikacija-helper";
import {NarudzbaService} from "../helpers/Narudzba-service";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-pocetna',
  templateUrl: './pocetna.component.html',
  styleUrls: ['./pocetna.component.css']
})
export class PocetnaComponent implements OnInit {
   podaciProizvodi: any;
   podaciPostovi: any;
   page: number=1;
   limitProizvodi: number=4;
   total: number=1;
   loading: boolean=false;
   limitPostovi: number=2;

  constructor(private httpKlijent: HttpClient,private router:Router,private narudzbaService:NarudzbaService) {
  }


  ngOnInit(): void {
    this.testirajWebApi();
  }
   testirajWebApi(): void {
    let parametri={
      page_number: this.page,
      items_per_page:this.limitProizvodi
    }
    JSON.stringify(parametri)
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Proizvod/GetAllPaged",
      {params:parametri}).subscribe((x:any)=>{
      this.podaciProizvodi = x['dataItems'];
      this.total=x['totalCount'];
      this.loading=false;
      this.podaciProizvodi.forEach((a:any) => {
      });

    });
    let parametri2={
      page_number: this.page,
      items_per_page:this.limitPostovi
    }
    JSON.stringify(parametri)
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Post/GetAllPaged",
      {params:parametri2}).subscribe((x:any)=>{
      this.podaciPostovi = x['dataItems'];
      this.total=x['totalCount'];
      this.loading=false;
      console.log(this.page)

    });
  }

  getProizvodiPodaci() {
    if(this.podaciProizvodi==null)
      return [];
    return this.podaciProizvodi;
  }

  getSlikaProizvoda(p: any) {
    return `https://localhost:44304/Proizvod/GetSlikaProizvoda/${p.proizvodID}`;

  }
  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();

  }
  getPostoviPodaci() {
    if(this.podaciPostovi==null)
      return[];
    return this.podaciPostovi;
  }

  getSlika(p: any) {
    return `https://localhost:44304/Post/GetSlikaPosta/${p.postID}`;
  }

  dodajUKorpu(p:any) {
    this.narudzbaService.addtoCart(p);
    porukaSuccess("Proizvod uspjesno dodan u korpu!")
  }
}
