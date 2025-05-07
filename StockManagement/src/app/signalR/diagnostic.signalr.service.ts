import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Observable } from 'rxjs';

import { environment } from '@environments/environment';

@Injectable({
  providedIn: 'root',
})
export class DiagnosticSignalRService {
  hubConnection: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/api/DiagnosticHub`) // SignalR hub URL
      .build();
  }

  startConnection(): Observable<void> {
    return new Observable<void>((observer) => {
      this.hubConnection
        .start()
        .then(() => {
          console.log('Connection established with SignalR hub');
          observer.next();
          observer.complete();
        })
        .catch((error) => {
          console.error('Error connecting to SignalR hub:', error);
          observer.error(error);
        });
    });
  }

  closeConnection() {
    this.hubConnection.stop();
  }

  receiveMessage(): Observable<string> {
    return new Observable<string>((observer) => {
      this.hubConnection.on('Diagnostic', (message: string) => {
        observer.next(message);
      });
    });
  }
}
