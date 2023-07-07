import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {LoginInformacije} from "./helpers/login-informacije";
import {AutentifikacijaHelper} from "./helpers/autentifikacija-helper";
import {mojConfig} from "./moj-config";
import {SignalrService} from "./services/signalr.service";
import {SignalrService2} from "./services/signalr.service2";
import {ChartConfiguration, ChartType} from "chart.js";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
   title = 'PCWebShop-Angular';
   podaciKategorije: any;
   lista: any;

  constructor(private httpKlijent: HttpClient, private router: Router, public signalRService: SignalrService, public signalRService2: SignalrService2) {
  }


  ngOnInit(): void {
    this.signalRService.startConnection();
    this.signalRService.addTransferChartDataListener();
    this.startHttpRequest();

    this.signalRService2.startConnection();
    this.signalRService2.addTransferChartDataListener2();
    this.startHttpRequest2();
    this.UcitajKategorije();
  }
   UcitajKategorije() {
    this.httpKlijent.get(mojConfig.adresa_servera+ "/Kategorija/GetAll").subscribe((x:any)=>{
      this.podaciKategorije=x;
    });
  }
  getKategorijePodaci() {
      if(this.podaciKategorije==null)
        return[];
      return this.podaciKategorije;
  }

  OtvoriKategorije(k: any) {

    this.router.navigate(['/korisnik-proizvodi',k.kategorijaID])
      .then(()=>{
        window.location.reload();
      });
  }


  loginInfo(): LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();

  }

  logoutButton() {
    AutentifikacijaHelper.setLoginInfo(null);

    this.httpKlijent.post(mojConfig.adresa_servera + "/Autentifikacija/Logout", null, mojConfig.http_opcije())
      .subscribe((x: any) => {
        this.router.navigateByUrl("/pocetna").
        then(() => {
          window.location.reload();
        });
      });
  }

  otvoriListu() {
      this.lista=1;
  }

  private startHttpRequest = () => {
    this.httpKlijent.get('https://localhost:44304/api/Chart')
      .subscribe(res => {
        console.log(res);
      })
  }
  private startHttpRequest2 = () => {
    this.httpKlijent.get('https://localhost:44304/api/Chart2')
      .subscribe(res => {
        console.log(res);
      })
  }
}
