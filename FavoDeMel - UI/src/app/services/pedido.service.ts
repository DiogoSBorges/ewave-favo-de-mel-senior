import { FavoDeMelApiBaseHttpService } from './favoDeMelApi.baseHttp.service';
import { Injectable, Injector } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })
  export class PedidoService extends FavoDeMelApiBaseHttpService {
    constructor(injector: Injector) {
      super(injector, 'pedido');
    }
    criarPedido = (pedido) => this.post('criar', pedido);
}