import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {NarudzbaService} from "../helpers/Narudzba-service";
import {AutentifikacijaHelper} from "../helpers/autentifikacija-helper";
import {mojConfig} from "../moj-config";

declare function porukaSuccess(s:string):any;

@Component({
  selector: 'app-korpa',
  templateUrl: './korpa.component.html',
  styleUrls: ['./korpa.component.css']
})
export class KorpaComponent implements OnInit {

  public products : any = [];
  public grandTotal !: number;
  nesto:any;
  proizvodi:any=[];
  id:number;
  kolicina:number;
  zavrsioKupovinu: any;
  constructor(private httpKlijent: HttpClient,private narudzbaService: NarudzbaService) {  }

  ngOnInit(): void {
    this.narudzbaService.getProducts()
      .subscribe(res=>{
        this.products = res;
        this.grandTotal = this.narudzbaService.getTotalPrice();
      });
  }

  removeItem(item: any){
    this.narudzbaService.removeCartItem(item);
  }
  emptycart(){
    this.narudzbaService.removeAllCart();
  }
  naruci() {

    var proizvodiIDs: number[] = new Array(this.products.length);
    var kolicine: number[] = new Array(this.products.length);

    for (var i = 0; i < proizvodiIDs.length; i++) {
      proizvodiIDs[i] = this.products[i].proizvodID

    }
    for (var i = 0; i < kolicine.length; i++) {
      kolicine[i] = this.products[i].kolicina

    }
    this.id = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalog.id;
    var korpaStavke = {
      id: proizvodiIDs,
      kolicina: kolicine,
      korisnikID: this.id

    }

    this.httpKlijent.post(mojConfig.adresa_servera + "/Narudzba/Post", korpaStavke).subscribe((x: any) => {
      porukaSuccess("Vaša narudžba je uspjesno kreirana!");
      this.nesto = x;
      this.zavrsioKupovinu = null;

    });
   }

  getSlikaProizvoda(p: any) {
    return `https://localhost:44304/Proizvod/GetSlikaProizvoda/${p.proizvodID}`;

  }
}
