import { Component, OnInit, OnDestroy, Injector, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';

import * as actions from '../../../store/comanda/comanda.actions';
import * as selectors from '../../../store/comanda/comanda.selectors';
import { Observable } from 'rxjs';
import { FavoDeMelHubService } from 'src/app/services/favoDeMelHub.service';
import { ModalDirective } from 'ngx-bootstrap/modal/public_api';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComandaService } from 'src/app/services/comanda.service';
import { AppToastrService } from 'src/app/services/AppToastr.service';

@Component({
  selector: 'comanda',
  templateUrl: './comanda.component.html',
  styleUrls: ['./comanda.component.scss'],
})
export class ComandaComponent implements OnInit, OnDestroy {

  @ViewChild('modal') modal: ModalDirective;
  @BlockUI() blockUI: NgBlockUI;

  private store: Store<any>;
  private favoDeMelHubService: FavoDeMelHubService;
  private comandaService: ComandaService;
  private appToastrService: AppToastrService;

  data$: Observable<any>;
  comandaModalId: Number;
  comandaModalNumero: Number;

  constructor(
    injector: Injector,
    favoDeMelHubService: FavoDeMelHubService,
    comandaService: ComandaService,
    appToastrService: AppToastrService) {
    this.store = injector.get(Store);
    this.data$ = this.store.select(selectors.selectComanda);
    this.favoDeMelHubService = favoDeMelHubService;
    this.comandaService = comandaService;
    this.appToastrService = appToastrService;
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

  abrirModalItem(comandaId, comandaNumero) {
    this.comandaModalId = comandaId;
    this.comandaModalNumero = comandaNumero;
    this.modal.show();
  }

  fecharModalItem() {
    this.modal.hide();
  }

  submitModalItem() {
    this.blockUI.start('carregando...');


    this.comandaService.abrirComanda(this.comandaModalId).pipe()
      .subscribe(
        data => {
          this.appToastrService.showSuccessMessage('Comanda', "Pedido aberta com sucesso");
          this.blockUI.stop();
          this.fecharModalItem();
          this.loadComandas();
        },
        error => {
          this.appToastrService.showErrorMessage('Comanda', error.error);
          this.blockUI.stop();
        }
      );
  }

}
