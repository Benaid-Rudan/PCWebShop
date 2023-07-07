import {HttpHeaders} from "@angular/common/http";
import {AutentifikacijaToken} from "./helpers/login-informacije";
import {AutentifikacijaHelper} from "./helpers/autentifikacija-helper";
export  class mojConfig{

  static adresa_servera="https://localhost:44304";
  static http_opcije=function (){
    let autentifikacijaToken:AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    let mojToken = "";

    if (autentifikacijaToken!=null)
      mojToken = autentifikacijaToken.vrijednost;
    return{
      headers:{
        'autentifikacija-token': mojToken,
      }
    };
  }
}
