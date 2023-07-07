import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

@Component({
  selector: 'app-administrator-kategorija',
  templateUrl: './administrator-kategorija.component.html',
  styleUrls: ['./administrator-kategorija.component.css']
})
export class AdministratorKategorijaComponent implements OnInit {
  odabranaKategorija: any;
  podaciKategorije: any;

  constructor(private httpKlijent:HttpClient) { }


  ngOnInit(): void {
    this.preuzmiKategorije();
  }
  private preuzmiKategorije() {
    this.httpKlijent.get(mojConfig.adresa_servera+"/Kategorija/GetAll/").subscribe((x:any)=>{
      this.podaciKategorije=x;
    });
  }
  snimiKategoriju() {
    this.httpKlijent.post(mojConfig.adresa_servera+"/Kategorija/Add/",this.odabranaKategorija).subscribe((x:any)=>{
      this.preuzmiKategorije();
      this.odabranaKategorija=null;
    });
  }

  getPodaciKategorje() {
    return this.podaciKategorije;
  }

  obrisiKategoriju(p: any) {
    this.httpKlijent.post(mojConfig.adresa_servera+"/Kategorija/Delete/",p).subscribe((x:any)=>{
      this.preuzmiKategorije();
    });
  }

  novaKategorijaDugme() {
    this.odabranaKategorija={
      id:0,
      nazivKategorije:""
    }
  }
}
