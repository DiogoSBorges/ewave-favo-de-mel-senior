import { FavoDeMelApiBaseHttpService } from './favoDeMelApi.baseHttp.service';
import { Injectable, Injector } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })
  export class ComandaServices extends FavoDeMelApiBaseHttpService {
    constructor(injector: Injector) {
      super(injector, 'comanda');
    }

    obterTodos = (param?:any) => this.get(null,param);
}