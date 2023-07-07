import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-administrator-proizvodi',
  templateUrl: './administrator-proizvodi.component.html',
  styleUrls: ['./administrator-proizvodi.component.css']
})
export class AdministratorProizvodiComponent implements OnInit {
  odabraniProizvod: any;
  podaciProizvodi: any;
  podaciProizvodjaca: any;
  podaciKategorije: any;
  nazivDijaloga: string="Dodaj proizvod";
  naziv: string="";
  total:number = 1;
  page:number = 1;
  limit:number = 6;
  loading:boolean = false;
  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.preuzmiPodatke();
    this.preuzmiProizvodjace();
    this.preuzmiKategorije();
  }

  private preuzmiPodatke() {
    let parametri={
      page_number: this.page,
      items_per_page:this.limit
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
  }
  private preuzmiProizvodjace() {
    this.httpKlijent.get(mojConfig.adresa_servera +"/Proizvodjac/GetAll/").subscribe((x:any)=>{
      this.podaciProizvodjaca=x;
    });
  }

  private preuzmiKategorije() {
    this.httpKlijent.get(mojConfig.adresa_servera +"/Kategorija/GetAll/").subscribe((x:any)=>{
      this.podaciKategorije=x;
    });
  }
  getPodaciProizvoda() {
    if(this.podaciProizvodi==null)
      return[];
    return this.podaciProizvodi.filter((x:any)=>x.nazivProizvoda.length==0 || (x.nazivProizvoda).toLowerCase().startsWith(this.naziv.toLowerCase()));
  }

  obrisiProizvod(p: any) {
    this.httpKlijent.post(mojConfig.adresa_servera +"/Proizvod/Delete/",p).subscribe((x:any)=>{
      this.preuzmiPodatke();
    });
  }

  noviProizvodDugme() {
    this.nazivDijaloga="Dodaj proizvod";
    this.odabraniProizvod={
      proizvodID:0,
      nazivProizvoda:"",
      opis:"",
      naStanju:0,
      kolicina:1,
      cijena:0,
      snizen:0,
      kategorijaID:0,
      proizvodjacID:0,
      slika_proizvoda_nova_base64:""
    }
  }

  snimiProizvod() {
    if(this.odabraniProizvod.proizvodID==0)
    {
      this.odabraniProizvod.snizen=false;
      this.httpKlijent.post(mojConfig.adresa_servera +"/Proizvod/Add/",this.odabraniProizvod).subscribe((x:any)=>{
        this.preuzmiPodatke();
        this.odabraniProizvod=null;
        porukaSuccess("Uspjesno ste dodali proizvod!");
      });
    }
    else
    {
      this.httpKlijent.post(mojConfig.adresa_servera +"/Proizvod/Update/"+this.odabraniProizvod.proizvodID,this.odabraniProizvod).subscribe((x:any)=>{
        this.preuzmiPodatke();
        this.odabraniProizvod=null;
        porukaSuccess("Uspjesno ste editovali proizvod!");
      });
    }
  }

  urediProizvod(p: any) {
    this.nazivDijaloga="Uredi proizvod";
    this.odabraniProizvod=p;
  }

  getSlika(p: any) {
    return `https://localhost:44304/Proizvod/GetSlikaProizvoda/${p.proizvodID}`;
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
        this2.odabraniProizvod.slika_proizvoda_nova_base64=reader.result;
      }
      reader.readAsDataURL(file);
    }
  }
  goToPrevious(): void {

    this.page--;
    this.preuzmiPodatke();
  }

  goToNext(): void {

    this.page++;
    this.preuzmiPodatke();
  }

  goToPage(n: number): void {
    this.page = n;
    this.preuzmiPodatke();
  }
}
