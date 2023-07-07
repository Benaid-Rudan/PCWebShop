import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {AutentifikacijaHelper} from "../../helpers/autentifikacija-helper";

declare function porukaSuccess(x:string):any;
declare function porukaError(x:string):any;

@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.css']
})
export class ConfirmEmailComponent implements OnInit {

  emailConfirmed: boolean = false;
  urlParams: any = {};

  constructor(
    private route: ActivatedRoute,
    private authService: AutentifikacijaHelper,
  ) {}

  ngOnInit() {
    this.urlParams.token = this.route.snapshot.queryParamMap.get('token');
    this.urlParams.userid = this.route.snapshot.queryParamMap.get('userid');
    this.confirmEmail();
  }
  confirmEmail() {
    this.authService.confirmEmail(this.urlParams).subscribe(
      () => {
        console.log('success');
        porukaSuccess("Uspješno ste potvrdili račun!");
        this.emailConfirmed = true;
      },
      (error) => {
        console.log(error);
        porukaError("Desila se greška pokušajte ponovno!");
        this.emailConfirmed = false;
      }
    );
  }
}
