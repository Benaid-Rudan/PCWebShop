import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ActivatedRoute} from "@angular/router";
import {mojConfig} from "../../moj-config";
import {LoginInformacije} from "../../helpers/login-informacije";
import {AutentifikacijaHelper} from "../../helpers/autentifikacija-helper";
import {NarudzbaService} from "../../helpers/Narudzba-service";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-korisnik-proizvodi',
  templateUrl: './korisnik-proizvodi.component.html',
  styleUrls: ['./korisnik-proizvodi.component.css']
})
export class KorisnikProizvodiComponent implements OnInit {
  private KategorijaID: number;
   ProizvodPodaci: any;
   KategorijaPodaci: any;


  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute,private narudzbaService:NarudzbaService) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.KategorijaID = +params['id']; // (+) converts string 'id' to a number
      console.log(this.ProizvodPodaci);
    });
    this.preuzmiProizvode();
    this.preuzmiKategoriju();
  }
  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  GetAllKategorije() {
    if (this.KategorijaPodaci == null)
      return [];
    return this.KategorijaPodaci;
  }

  GetAllProizvodi() {
      if(this.ProizvodPodaci==null)
        return [];
      return  this.ProizvodPodaci.filter((a:any)=>a.kategorijaID==this.KategorijaID);
  }

  private preuzmiProizvode() {
    this.httpKlijent.get(mojConfig.adresa_servera+ `/Proizvod/GetAll`, mojConfig.http_opcije()).subscribe(x=>{
      this.ProizvodPodaci = x
    });
  }

  private preuzmiKategoriju() {
    this.httpKlijent.get(mojConfig.adresa_servera+ `/Kategorija/Get/${this.KategorijaID}`, mojConfig.http_opcije()).subscribe(x=>{
      this.KategorijaPodaci = x
    });
  }

  getSlikaProizvoda(p: any) {
    return `https://localhost:44304/Proizvod/GetSlikaProizvoda/${p.proizvodID}`;
  }
  dodajUKorpu(p:any) {
    this.narudzbaService.addtoCart(p);
    porukaSuccess("Proizvod uspjesno dodan u korpu!");
  }
}
