import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";

@Component({
  selector: 'app-administrator',
  templateUrl: './administrator.component.html',
  styleUrls: ['./administrator.component.css']
})
export class AdministratorComponent implements OnInit {

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
  }


}
