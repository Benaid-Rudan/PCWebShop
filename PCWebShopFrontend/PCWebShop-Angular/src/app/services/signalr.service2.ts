import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr'
import { ChartModel2 } from "../../_interfaces/chartmodel.model2";

@Injectable({
  providedIn: 'root'
})
export class SignalrService2 {
  public data2: ChartModel2[];
  private hubConnection2: signalR.HubConnection;
  public startConnection = () => {
    this.hubConnection2 = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:44304/Chart2')
      .build();
    this.hubConnection2
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public addTransferChartDataListener2 = () => {
    this.hubConnection2.on('transferchartdata', (data2) => {
      this.data2 = data2;
      console.log(data2);
    });
  }
  constructor() { }
}
