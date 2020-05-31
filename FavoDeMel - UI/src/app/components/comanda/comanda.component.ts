import { Component, OnInit, OnDestroy, Injector } from '@angular/core';
import { Store } from '@ngrx/store';

import * as actions from '../../store/comanda/comanda.actions';
import * as selectors from '../../store/comanda/comanda.selectors';
import { Observable } from 'rxjs';
import { FavoDeMelHubService } from 'src/app/services/favoDeMelHub.service';

@Component({
  selector: 'comanda',
  templateUrl: './comanda.component.html',
  styleUrls: ['./comanda.component.scss'],
})
export class ComandaComponent implements OnInit, OnDestroy {

  private store: Store<any>;
  private favoDeMelHubService: FavoDeMelHubService

  data$: Observable<any>;



  constructor(
    injector: Injector,
    favoDeMelHubService: FavoDeMelHubService) {
    this.store = injector.get(Store);
    this.data$ = this.store.select(selectors.selectComanda);
    this.favoDeMelHubService = favoDeMelHubService;
  }

  ngOnInit(): void {
    this.loadComandas();
    this.favoDeMelHubService.startConnection();
    this.favoDeMelHubService.ComandaAbertaEventListener((data) => this.loadComandas())
  }

  ngOnDestroy(): void {
    this.favoDeMelHubService.disconnect();
  }

  loadComandas(): void {
    var params: any = { Pagina: 1, Linhas: 50 }
    this.store.dispatch(actions.carregarComandas({ params } as any));
  }

}
