import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

@Component({
  selector: 'app-korisnik-postovi',
  templateUrl: './korisnik-postovi.component.html',
  styleUrls: ['./korisnik-postovi.component.css']
})
export class KorisnikPostoviComponent implements OnInit {
  podaciPostovi: any;
  page: number=1;
  total: number=1;
  loading: boolean=false;
  limitPostovi: number=4;
  constructor(private httpKlijent:HttpClient) { }


  ngOnInit(): void {
    this.preuzmiPostove();
  }

  private preuzmiPostove() {
    let parametri={
      page_number: this.page,
      items_per_page:this.limitPostovi
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
  getPostoviPodaci() {
    if(this.podaciPostovi==null)
      return[];
    return this.podaciPostovi;
  }

  getSlika(p: any) {
    return `https://localhost:44304/Post/GetSlikaPosta/${p.postID}`;
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
