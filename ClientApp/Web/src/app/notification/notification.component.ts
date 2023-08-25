import { Component, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr'

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {
  private hubConnection: signalR.HubConnection | undefined;
  message: string | undefined;
  constructor() { }

  ngOnInit(): void {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('https://localhost:7037/notificationHub', {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    this.hubConnection.on('ReceiveNotification', (message: string) => {
      debugger;
      this.message = message;
      // Handle received notifications
    });

    this.hubConnection.start().catch(err => console.error(err));
  }

}
