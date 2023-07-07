import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

declare function porukaSuccess(x:string):any;

@Component({
  selector: 'app-administrator-korisnicki-profili',
  templateUrl: './administrator-korisnicki-profili.component.html',
  styleUrls: ['./administrator-korisnicki-profili.component.css']
})
export class AdministratorKorisnickiProfiliComponent implements OnInit {

  korisnikPodaci:any;
  odabraniKorisnik:any=null;
  ime:string='';
  noviAdmin:any=null;


  constructor(private httpKlijent:HttpClient) { }

  testirajWebApi() {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Korisnik/GetAll").subscribe(x=>{
      this.korisnikPodaci = x;
    });
  }

  getProizvodiPodaci() {
    if (this.korisnikPodaci==null)
      return[];
    return this.korisnikPodaci.filter((x: any)=> this.ime=="" || (x.ime + " " + x.prezime).toLowerCase().startsWith(this.ime.toLowerCase()) || (x.prezime + " " + x.ime).toLowerCase().startsWith(this.ime.toLowerCase()));
  }
  ngOnInit(): void {
    this.testirajWebApi();
  }
  detalji(p:any) {
    this.odabraniKorisnik=p;
    this.odabraniKorisnik.prikazi=true;
  }

  obrisi(p:any) {
    this.httpKlijent.post(mojConfig.adresa_servera+"/Korisnik/Delete/"+p.id,null)
      .subscribe((x:any)=>{
        const index=this.korisnikPodaci.indexOf(p);
        if(index>-1){
          this.korisnikPodaci.splice(index,1);
        }
        porukaSuccess("Korisnik uspjesno obrisan");
      })
  }


}
