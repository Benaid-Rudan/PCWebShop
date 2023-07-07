import { Component, OnInit } from '@angular/core';
import {ChartConfiguration, ChartType} from "chart.js";
import {SignalrService} from "../../services/signalr.service";

@Component({
  selector: 'app-administrator-korisnik-chart',
  templateUrl: './administrator-korisnik-chart.component.html',
  styleUrls: ['./administrator-korisnik-chart.component.css']
})
export class AdministratorKorisnikChartComponent implements OnInit {
  chartOptions: ChartConfiguration['options'] = {
    responsive: true,
    scales: {
      y: {
        min: 0
      }
    }
  };
  chartLabels: string[] = ['Real time chartovi - SignalR'];
  chartType: ChartType = 'bar';
  chartLegend: boolean = true;
  constructor(public signalRService: SignalrService) { }

  ngOnInit(): void {
  }
}
