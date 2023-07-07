import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

@Component({
  selector: 'app-korisnik-oglasi',
  templateUrl: './korisnik-oglasi.component.html',
  styleUrls: ['./korisnik-oglasi.component.css']
})
export class KorisnikOglasiComponent implements OnInit {
   podaciOglasa: any;

  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.preuzmiOglase();
  }
  private preuzmiOglase() {
    this.httpKlijent.get( mojConfig.adresa_servera+"/Oglas/GetAll").subscribe((x:any)=>{
      this.podaciOglasa=x;
    });
  }
  getOglasiPodaci() {
    if(this.podaciOglasa==null)
      return[];
    return this.podaciOglasa;
  }

}
