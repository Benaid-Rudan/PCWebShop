import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

@Component({
  selector: 'app-administrator-postovi',
  templateUrl: './administrator-postovi.component.html',
  styleUrls: ['./administrator-postovi.component.css']
})
export class AdministratorPostoviComponent implements OnInit {
  odabraniPost: any;
  podaciPostovi: any;
  podaciAdministrator: any;
  total:number = 1;
  page:number = 1;
  limit:number = 3;
  loading:boolean = false;
  nazivDijaloga: string="Dodaj post";

  constructor(private httpKlijent:HttpClient) { }

  ngOnInit(): void {
    this.preuzmiPostove();
    this.preuzmiAdministratore();
  }
  private preuzmiPostove() {
    let parametri={
      page_number: this.page,
      items_per_page:this.limit
    }
    JSON.stringify(parametri)
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Post/GetAllPaged",
      {params:parametri}).subscribe((x:any)=>{
      this.podaciPostovi = x['dataItems'];
      this.total=x['totalCount'];
      this.loading=false;
      this.podaciPostovi.forEach((a:any) => {
      });

    });
  }
  private preuzmiAdministratore() {
    this.httpKlijent.get(mojConfig.adresa_servera +"/Administrator/GetAll").subscribe((x:any)=>{
      this.podaciAdministrator=x;
    });
  }
  snimiPost() {
    if(this.odabraniPost.postID==0)
    {
      this.httpKlijent.post(mojConfig.adresa_servera +"/Post/Add",this.odabraniPost).subscribe((x:any)=>{
        this.preuzmiPostove();
        this.odabraniPost=null;
      });
    }
    else
    {
      this.httpKlijent.post(mojConfig.adresa_servera +"/Post/Update/"+this.odabraniPost.postID,this.odabraniPost).subscribe((x:any)=>{
        this.preuzmiPostove();
        this.odabraniPost=null;
      });
    }
  }

  obrisiPost(p: any) {
    this.httpKlijent.post(mojConfig.adresa_servera +"/Post/Delete/",p).subscribe((x:any)=>{
      this.preuzmiPostove();
    });
  }
  getPostPodaci() {
    return this.podaciPostovi;
  }

  noviPostDugme() {
    this.odabraniPost={
      postID:0,
      naslov:"",
      sadrzaj:"",
      autorPostaID:0,
      slika_posta_nova_base64:"",
      datumObjave:new Date(),
    }
  }

  urediPost(p: any) {
    this.odabraniPost=p;
    this.nazivDijaloga="Uredi post";
  }

  getSlika(p: any) {
    return `https://localhost:44304/Post/GetSlikaPosta/${p.postID}`;
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
        this2.odabraniPost.slika_posta_nova_base64=reader.result;
      }
      reader.readAsDataURL(file);
    }
  }
  goToPrevious(): void {

    this.page--;
    this.preuzmiPostove();
  }

  goToNext(): void {

    this.page++;
    this.preuzmiPostove();
  }

  goToPage(n: number): void {
    this.page = n;
    this.preuzmiPostove();
  }
}
