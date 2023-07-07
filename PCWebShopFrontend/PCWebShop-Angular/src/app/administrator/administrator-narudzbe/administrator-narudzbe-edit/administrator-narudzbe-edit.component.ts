import {Component, Input, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {mojConfig} from "../../../moj-config";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-administrator-narudzbe-edit',
  templateUrl: './administrator-narudzbe-edit.component.html',
  styleUrls: ['./administrator-narudzbe-edit.component.css']
})
export class AdministratorNarudzbeEditComponent implements OnInit {

  @Input() urediNarudzbu:any;
  narudzbePodaci:any=null;
  dostavljac: any;
  narucioc: any;
  constructor(private httpKlijent:HttpClient) {
    this.httpKlijent.get(mojConfig.adresa_servera+"/Dostavljac/GetAll").subscribe((x:any)=>{
      this.dostavljac=x;
    });
    this.httpKlijent.get(mojConfig.adresa_servera+"/Korisnik/GetAll").subscribe((x:any)=>{
      this.narucioc=x;
    });
  }

  ngOnInit(): void {
    this.testirajWebApi();

  }
  snimi() {
      this.httpKlijent.post(mojConfig.adresa_servera+ "/Narudzba/Update/" + this.urediNarudzbu.narudzbaID, this.urediNarudzbu).subscribe((x:any) => {
        porukaSuccess("Narudzba uspjesno editovana!");
        this.urediNarudzbu.prikazi = false;

      });

    this.testirajWebApi();
  }
  testirajWebApi() :void
  {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Narudzba/GetAll",mojConfig.http_opcije()).subscribe(x=>{
      this.narudzbePodaci = x;
    });
  }

}
