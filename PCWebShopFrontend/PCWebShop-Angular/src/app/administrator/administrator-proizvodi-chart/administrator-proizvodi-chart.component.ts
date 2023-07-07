import { Component, OnInit } from '@angular/core';
import {ChartConfiguration, ChartType} from "chart.js";
import {SignalrService2} from "../../services/signalr.service2";

@Component({
  selector: 'app-administrator-proizvodi-chart',
  templateUrl: './administrator-proizvodi-chart.component.html',
  styleUrls: ['./administrator-proizvodi-chart.component.css']
})
export class AdministratorProizvodiChartComponent implements OnInit {

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
  constructor(public signalRService2: SignalrService2) { }

  ngOnInit(): void {
  }
}
