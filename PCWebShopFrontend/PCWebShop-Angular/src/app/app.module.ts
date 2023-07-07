import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import {RouterModule} from "@angular/router";
import { PocetnaComponent } from './pocetna/pocetna.component';
import { HttpClientModule,} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { AdministratorComponent } from './administrator/administrator.component';
import { AdministratorProizvodiComponent } from './administrator/administrator-proizvodi/administrator-proizvodi.component';
import { AdministratorKategorijaComponent } from './administrator/administrator-kategorija/administrator-kategorija.component';
import { AdministratorProizvodjacComponent } from './administrator/administrator-proizvodjac/administrator-proizvodjac.component';
import { AdministratorOglasiComponent } from './administrator/administrator-oglasi/administrator-oglasi.component';
import { AdministratorPostoviComponent } from './administrator/administrator-postovi/administrator-postovi.component';
import { KorisnikProizvodiComponent } from './korisnik/korisnik-proizvodi/korisnik-proizvodi.component';
import { KorisnikOglasiComponent } from './korisnik/korisnik-oglasi/korisnik-oglasi.component';
import { KorisnikPostoviComponent } from './korisnik/korisnik-postovi/korisnik-postovi.component';
import { LoginComponent } from './login/login.component';
import {DatePipe} from "@angular/common";
import {AutorizacijaLoginProvjera} from "./guards/autorizacija-login-provjera.service";
import { KorisnikProizvodiDetaljnoComponent } from './korisnik/korisnik-proizvodi/korisnik-proizvodi-detaljno/korisnik-proizvodi-detaljno.component';
import { KorisnikProizvodiSviComponent } from './korisnik/korisnik-proizvodi-svi/korisnik-proizvodi-svi.component';
import { FooterComponent } from './footer/footer.component';
import { PaginationComponent } from './pagination/pagination.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import { KorisnikKorisnickiProfilComponent } from './korisnik/korisnik-korisnicki-profil/korisnik-korisnicki-profil.component';
import { AdministratorKorisnickiProfiliComponent } from './administrator/administrator-korisnicki-profili/administrator-korisnicki-profili.component';
import { KorpaComponent } from './korpa/korpa.component';
import { AdministratorNarudzbeComponent } from './administrator/administrator-narudzbe/administrator-narudzbe.component';
import { AdministratorNarudzbeEditComponent } from './administrator/administrator-narudzbe/administrator-narudzbe-edit/administrator-narudzbe-edit.component';
import { NgChartsModule} from "ng2-charts";
import { AdministratorKorisnikChartComponent } from './administrator/administrator-korisnik-chart/administrator-korisnik-chart.component';
import { AdministratorProizvodiChartComponent } from './administrator/administrator-proizvodi-chart/administrator-proizvodi-chart.component';
import { ConfirmEmailComponent } from './registracija/confirm-email/confirm-email.component';
import {AutorizacijaAdminProvjera} from "./guards/autorizacija-admin-provjera.service";
import {AutorizacijaKorisnikProvjera} from "./guards/autorizacija-korisnik-provjera.service";

@NgModule({
  declarations: [
    AppComponent,
    PocetnaComponent,
    AdministratorComponent,
    AdministratorProizvodiComponent,
    AdministratorKategorijaComponent,
    AdministratorProizvodjacComponent,
    AdministratorOglasiComponent,
    AdministratorPostoviComponent,
    KorisnikProizvodiComponent,
    KorisnikOglasiComponent,
    KorisnikPostoviComponent,
    LoginComponent,
    KorisnikProizvodiDetaljnoComponent,
    KorisnikProizvodiSviComponent,
    FooterComponent,
    PaginationComponent,
    RegistracijaComponent,
    KorisnikKorisnickiProfilComponent,
    AdministratorKorisnickiProfiliComponent,
    KorpaComponent,
    AdministratorNarudzbeComponent,
    AdministratorNarudzbeEditComponent,
    AdministratorKorisnikChartComponent,
    AdministratorProizvodiChartComponent,
    ConfirmEmailComponent,
  ],
    imports: [
        BrowserModule,
        RouterModule.forRoot([
            {path: "", redirectTo: "/pocetna", pathMatch: "full"},
            {path: 'pocetna', component: PocetnaComponent},
            {path: 'administrator', component: AdministratorComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'administrator-kategorija', component: AdministratorKategorijaComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'administrator-proizvodjac', component: AdministratorProizvodjacComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'administrator-proizvodi', component: AdministratorProizvodiComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'administrator-oglasi', component: AdministratorOglasiComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'administrator-postovi', component: AdministratorPostoviComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'korisnik-proizvodi/:id', component: KorisnikProizvodiComponent},
            {path: 'korisnik-oglasi', component: KorisnikOglasiComponent},
            {path: 'korisnik-postovi', component: KorisnikPostoviComponent},
            {path: 'korisnik-proizvodi-svi', component: KorisnikProizvodiSviComponent},
            {path: 'login', component: LoginComponent},
            {path: 'proizvod-detaljno/:id', component: KorisnikProizvodiDetaljnoComponent},
            {path: 'registracija', component: RegistracijaComponent},
            {path: 'administrator-korisnicki-profili',component:AdministratorKorisnickiProfiliComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'korisnik-korisnicki-profil',component:KorisnikKorisnickiProfilComponent,canActivate:[AutorizacijaKorisnikProvjera]},
            {path: 'korpa',component:KorpaComponent,canActivate:[AutorizacijaKorisnikProvjera]},
            {path: 'administrator-narudzbe',component:AdministratorNarudzbeComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'administrator-narudzbe-edit',component:AdministratorNarudzbeEditComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'administrator-korisnik-chart',component:AdministratorKorisnikChartComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'administrator-proizvodi-chart',component:AdministratorProizvodiChartComponent,canActivate:[AutorizacijaAdminProvjera]},
            {path: 'confirm-email',component:ConfirmEmailComponent}




        ]),
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        NgChartsModule
    ],
  providers: [
    AutorizacijaLoginProvjera,
    AutorizacijaAdminProvjera,
    AutorizacijaKorisnikProvjera,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
