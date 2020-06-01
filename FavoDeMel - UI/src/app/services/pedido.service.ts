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
    obterPedidoItemProducao = () => this.get('pedido-item-producao');
    iniciarProducaoPedidoItem = (pedidoId:Number, itemPedidoId: Number) => this.put(`${pedidoId}/item/${itemPedidoId}/iniciar-producao`, null);
    finalizarProducaoPedidoItem = (pedidoId:Number, itemPedidoId: Number) => this.put(`${pedidoId}/item/${itemPedidoId}/finalizar-producao`, null);
    cancelarPedidoItem = (pedidoId:Number, itemPedidoId: Number) => this.put(`${pedidoId}/item/${itemPedidoId}/cancelar`, null);
    entregarPedidoItem = (pedidoId:Number, itemPedidoId: Number) => this.put(`${pedidoId}/item/${itemPedidoId}/entregar`, null);
}