import { Component, OnInit, OnDestroy, Injector } from '@angular/core';
import { Store } from '@ngrx/store';

import * as actions from '../../../store/comanda/comanda.actions';
import * as selectors from '../../../store/comanda/comanda.selectors';
import { Observable } from 'rxjs';

import { FavoDeMelHubService } from 'src/app/services/favoDeMelHub.service';

import { ActivatedRoute } from '@angular/router';
import { comandaReducer } from 'src/app/store/comanda/comanda.reducer';

@Component({
  selector: 'comanda-detalhe',
  templateUrl: './comanda-detalhe.component.html',
  styleUrls: ['./comanda-detalhe.component.scss'],
})
export class ComandaDetalheComponent implements OnInit, OnDestroy {

  private store: Store<any>;
  private favoDeMelHubService: FavoDeMelHubService
  private activatedRoute: ActivatedRoute

  data$: Observable<any>;

  constructor(
    injector: Injector,
    activatedRoute: ActivatedRoute,
    favoDeMelHubService: FavoDeMelHubService) {
    this.activatedRoute = activatedRoute;
    this.store = injector.get(Store);
    this.data$ = this.store.select(selectors.selectComandaDetalhada);
    this.favoDeMelHubService = favoDeMelHubService;
  }

  ngOnInit(): void {
    this.loadComanda();
    //this.favoDeMelHubService.startConnection();
    // this.favoDeMelHubService.ComandaAbertaEventListener((data) => this.loadComandas())
  }

  ngOnDestroy(): void {
    // this.favoDeMelHubService.disconnect();
  }

  loadComanda(): void {
    this.activatedRoute.params.subscribe(({ id }) => {
      this.store.dispatch(actions.carregarDetalheComanda({ id }));
    });
  }

  getTotal() {
    let total = 0;
    this.data$.subscribe(comandaDetalhada => {
      comandaDetalhada.comanda.pedidos.forEach(pedido => {
        total += pedido.itens.reduce((a, b) => a + (b['valor']), 0);
      });
    })
    return total;
  }  
}
