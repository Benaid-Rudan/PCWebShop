import { Component, OnInit } from '@angular/core';
import {mojConfig} from "../../moj-config";
import {AutentifikacijaHelper} from "../../helpers/autentifikacija-helper";
import {HttpClient} from "@angular/common/http";


declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-korisnik-korisnicki-profil',
  templateUrl: './korisnik-korisnicki-profil.component.html',
  styleUrls: ['./korisnik-korisnicki-profil.component.css']
})
export class KorisnikKorisnickiProfilComponent implements OnInit {
  lokacija:string;
  korisnikPodaci={
    slika_korisnika_nova_base64:"",
    ime:"",
    prezime:"",
    spol:"",
    drzavaID:1,
    korisnickoIme:"",
    adresa1: "",
    adresa2: "",
    email:"",
    datumRodjenja:new Date()
  }
  drzavePodaci:any;
  id:any;
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.getKorisnika();
    this.ucitajDrzave();
  }

  getKorisnika(){
    if(AutentifikacijaHelper.getLoginInfo().isPermisijaKorisnik) {
      this.id = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id;
      this.httpKlijent.get(mojConfig.adresa_servera+"/Korisnik/Get/"+this.id,mojConfig.http_opcije())
        .subscribe((x:any)=>{
          this.korisnikPodaci=x;

        });
    }
  }
  onfileSelected(event:any) {
    let slika=event.target.files[0].name;
    this.lokacija="assets/img/Korisnici/"+slika;
    this.korisnikPodaci.slika_korisnika_nova_base64=this.lokacija;
  }
  ucitajDrzave() :void
  {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Drzava/GetAll_ForCmb",mojConfig.http_opcije()).subscribe(x=>{
      this.drzavePodaci = x;
    });
  }
  getDrzave(){
    if(this.drzavePodaci==null)
      return[];
    return this.drzavePodaci;
  }
  spasiPromjene(){
    this.httpKlijent.post(mojConfig.adresa_servera+ "/Korisnik/Update/" + this.id, this.korisnikPodaci).subscribe((x:any) => {
      porukaSuccess(x.korisnickoIme + " vaše promjene su uspješno pohranjene");
    });
  }
  generisi_preview() {
    // @ts-ignore
    var file=document.getElementById("slika-input").files[0];

    if(file)
    {
      var reader=new FileReader();
      let this2=this;
      reader.onload=function ()
      {
        this2.korisnikPodaci.slika_korisnika_nova_base64=reader.result.toString();
      }
      reader.readAsDataURL(file);
    }
  }
  getSlika(p: any) {
    return `https://localhost:44304/Korisnik/GetSlikaKorisnik/${p.korisnikID}`;
  }
}
