import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

@Component({
  selector: 'app-administrator-oglasi',
  templateUrl: './administrator-oglasi.component.html',
  styleUrls: ['./administrator-oglasi.component.css']
})
export class AdministratorOglasiComponent implements OnInit {

  odabraniOglas:any;
  podaciOglasa:any;
  podaciAdministrator: any;
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.preuzmiPodatke();
    this.preuzmiAdministratore();
  }

  private preuzmiPodatke() {
    this.httpKlijent.get(mojConfig.adresa_servera +"/Oglas/GetAll").subscribe((x:any)=>{
      this.podaciOglasa=x;
    });
  }

  private preuzmiAdministratore() {
    this.httpKlijent.get(mojConfig.adresa_servera +"/Administrator/GetAll").subscribe((x:any)=>{
      this.podaciAdministrator=x;
    });
  }
  snimiOglas(){
    if(this.odabraniOglas.oglasID==0)
    {
      this.httpKlijent.post(mojConfig.adresa_servera +"/Oglas/Add",this.odabraniOglas).subscribe((x:any)=>{
        this.preuzmiPodatke();
        this.odabraniOglas=null;
      });
    }
    else
    {
      this.httpKlijent.post(mojConfig.adresa_servera +"/Oglas/Update/"+this.odabraniOglas.oglasID,this.odabraniOglas).subscribe((x:any)=>{
        this.preuzmiPodatke();
        this.odabraniOglas=null;
      });
    }
  }
  getPodaciOglasa(){
    return this.podaciOglasa;
  }
  obrisiOglas(o:any){
    this.httpKlijent.post(mojConfig.adresa_servera + "/Oglas/Delete",o).subscribe((x:any)=>{
      this.preuzmiPodatke();
    });
  }
  noviOglasDugme(){
    this.odabraniOglas={
      oglasID:0,
      naslov:"",
      sadrzaj:"",
      administratorID:0,
      aktivan:false,
      trajanjeOglasa:0,
      lokacija:"",
      brojPozicija:0,
      cvEmail:"",
      datumObjave:new Date().getDate(),
      datumIsteka:new Date().getDate()
    }
  }

  urediOglas(p: any) {
    this.odabraniOglas=p;
  }

}
