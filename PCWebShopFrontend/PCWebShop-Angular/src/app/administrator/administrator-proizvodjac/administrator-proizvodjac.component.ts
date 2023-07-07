import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

@Component({
  selector: 'app-administrator-proizvodjac',
  templateUrl: './administrator-proizvodjac.component.html',
  styleUrls: ['./administrator-proizvodjac.component.css']
})
export class AdministratorProizvodjacComponent implements OnInit {
  podaciProizvodjac: any;
  odabraniProizvodjac: any;
  podaciDrzava: any;

  constructor(private httpKlijent:HttpClient) { }


  ngOnInit(): void {
    this.preuzmiPodatke();
    this.preuzmiDrzave();
  }
  private preuzmiPodatke() {
    this.httpKlijent.get(mojConfig.adresa_servera +"/Proizvodjac/GetAll/").subscribe((x:any)=>{
      this.podaciProizvodjac=x;
    });
  }
  private preuzmiDrzave() {
    this.httpKlijent.get(mojConfig.adresa_servera +"/Drzava/GetAll/").subscribe((x:any)=>{
      this.podaciDrzava=x;
    });
  }
  snimiProizvodjaca() {
    this.httpKlijent.post(mojConfig.adresa_servera +"/Proizvodjac/Add/",this.odabraniProizvodjac).subscribe((x:any)=>{
      this.preuzmiPodatke();
      this.odabraniProizvodjac=null;
    });
  }

  getPodaciProizvodjac() {
    return this.podaciProizvodjac;
  }

  obrisiProizvodjaca(p: any) {
    this.httpKlijent.post(mojConfig.adresa_servera +"/Proizvodjac/Delete/",p).subscribe((x:any)=>{
      this.preuzmiPodatke();
    });
  }

  noviProizvodjacDugme() {
    this.odabraniProizvodjac={
      nazivProizvodjaca:""
    };
  }
}
