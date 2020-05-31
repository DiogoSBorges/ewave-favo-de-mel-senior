import { FavoDeMelApiBaseHttpService } from './favoDeMelApi.baseHttp.service';
import { Injectable, Injector } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })
  export class ComandaService extends FavoDeMelApiBaseHttpService {
    constructor(injector: Injector) {
      super(injector, 'comanda');
    }

    obterTodos = (param?:any) => this.get(null,param);
    obterComandaDetalhada = (id:Number) => this.get(`${id}/detalhada`);
    abrirComanda = (id:Number) => this.put(`${id}/abrir`, null);
}