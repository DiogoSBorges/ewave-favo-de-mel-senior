import { Injectable } from '@angular/core';
import * as signalR from "@aspnet/signalr";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FavoDeMelHubService {

  private hubConnection: signalR.HubConnection
  private readonly apiUrl = environment.favo_de_mel_api_url;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${this.apiUrl}/favodemelhub`)
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public disconnect() {
    this.hubConnection.stop();
  }

  public ComandaAbertaEventListener = (callback) => {
    this.hubConnection.on('ComandaAberta', (data) => {
      callback(data);
    });
  }

  public ComandaFechadaEventListener = (callback) => {
    this.hubConnection.on('ComandaFechada', (data) => {
      callback(data);
    });
  }

  public PedidoCriadoEventListener = (callback) => {
    this.hubConnection.on('PedidoCriado', (data) => {
      callback(data);
    });
  }

  public PedidoItemProducaoIniciadaEventListener = (callback) => {
    this.hubConnection.on('PedidoItemProducaoIniciada', (data) => {
      callback(data);
    });
  }

  public PedidoItemProducaoFinalizadaEventListener = (callback) => {
    this.hubConnection.on('PedidoItemProducaoFinalizada', (data) => {
      callback(data);
    });
  }

  public PedidoItemCanceladoEventListener = (callback) => {
    this.hubConnection.on('PedidoItemCancelado', (data) => {
      callback(data);
    });
  }

  public PedidoItemEntregueEventListener = (callback) => {
    this.hubConnection.on('PedidoItemEntregue', (data) => {
      callback(data);
    });
  }

  public PedidoItemPriorizadoEventListener = (callback) => {
    this.hubConnection.on('PedidoItemPriorizado', (data) => {
      callback(data);
    });
  }
}