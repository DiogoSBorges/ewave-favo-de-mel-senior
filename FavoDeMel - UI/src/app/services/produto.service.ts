import { FavoDeMelApiBaseHttpService } from './favoDeMelApi.baseHttp.service';
import { Injectable, Injector } from '@angular/core';

@Injectable({
    providedIn: 'root',
  })
  export class ProdutoService extends FavoDeMelApiBaseHttpService {
    constructor(injector: Injector) {
      super(injector, 'produto');
    }

    obterTodos = () => this.get();
}