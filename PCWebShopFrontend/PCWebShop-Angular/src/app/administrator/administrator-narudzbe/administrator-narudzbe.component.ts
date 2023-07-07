import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../moj-config";

declare function porukaSuccess(a: string):any;

@Component({
  selector: 'app-administrator-narudzbe',
  templateUrl: './administrator-narudzbe.component.html',
  styleUrls: ['./administrator-narudzbe.component.css']
})
export class AdministratorNarudzbeComponent implements OnInit {

  title:string='angular';
  narudzbePodaci :any;
  ime:any='';
  odabranaNarudzba: any=null;

  constructor(private httpKlijent: HttpClient) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Narudzba/GetAll",mojConfig.http_opcije()).subscribe(x=>{
      this.narudzbePodaci = x;
    });
  }
  getNarudzbaPodaci() {
    if (this.narudzbePodaci == null)
      return [];
    return this.narudzbePodaci;
  }

  ngOnInit(): void {
    this.testirajWebApi();
  }

  detalji(n:any) {
    this.odabranaNarudzba=n;
    this.odabranaNarudzba.prikazi=true;
  }

  obrisi(n:any) {
    this.httpKlijent.post(mojConfig.adresa_servera+"/Narudzba/Delete/"+n.narudzbaID,null)
      .subscribe((x:any)=>{
        const index=this.narudzbePodaci.indexOf(n);
        if(index>-1){
          this.narudzbePodaci.splice(index,1);
        }
        porukaSuccess("Narudba uspjesno obrisana!");
      })
  }

}
