import { Component, OnInit, Injector } from '@angular/core';
import {Store} from '@ngrx/store';

import * as actions from '../../store/comanda/comanda.actions';
import * as selectors from '../../store/comanda/comands.selectors';
import { Observable } from 'rxjs';

@Component({
  selector: 'comanda',
  templateUrl: './comanda.component.html',
  styleUrls: ['./comanda.component.scss'],
})
export class ComandaComponent implements OnInit {

    protected store: Store<any>;
    data$: Observable<any>;

    constructor(injector: Injector) {       
        this.store = injector.get(Store);
        this.data$ = this.store.select(selectors.selectComanda);
      }

    ngOnInit(): void {
      var params :any = {Pagina:1, Linhas:50}
        this.store.dispatch(actions.carregarComandas({params} as any));
    }
}
