import { Component, OnInit, OnDestroy, Injector, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';

import * as actions from '../../../store/comanda/comanda.actions';
import * as selectors from '../../../store/comanda/comanda.selectors';
import { Observable } from 'rxjs';

import { FavoDeMelHubService } from 'src/app/services/favoDeMelHub.service';

import { ActivatedRoute } from '@angular/router';
import { comandaReducer } from 'src/app/store/comanda/comanda.reducer';
import { ModalDirective } from 'ngx-bootstrap/modal/public_api';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { PedidoService } from 'src/app/services/pedido.service';
import { AppToastrService } from 'src/app/services/AppToastr.service';

@Component({
  selector: 'comanda-detalhe',
  templateUrl: './comanda-detalhe.component.html',
  styleUrls: ['./comanda-detalhe.component.scss'],
})
export class ComandaDetalheComponent implements OnInit, OnDestroy {

  @ViewChild('modal') modal: ModalDirective;
  @BlockUI() blockUI: NgBlockUI;

  private store: Store<any>;
  private favoDeMelHubService: FavoDeMelHubService;
  private activatedRoute: ActivatedRoute;
  private pedidoService : PedidoService;
  private appToastrService: AppToastrService;

  data$: Observable<any>;

  total: number = 0;
  desconto: number = 0;

  pedidoId: number;
  pedidoitemId: number;
  produto: string;

  constructor(
    injector: Injector,
    activatedRoute: ActivatedRoute,
    favoDeMelHubService: FavoDeMelHubService,
    pedidoService : PedidoService,
    appToastrService: AppToastrService) {
    this.activatedRoute = activatedRoute;
    this.store = injector.get(Store);
    this.data$ = this.store.select(selectors.selectComandaDetalhada);
    this.favoDeMelHubService = favoDeMelHubService;
    this.pedidoService = pedidoService;
    this.appToastrService = appToastrService;
  }

  ngOnInit(): void {
    this.loadComanda();
    this.favoDeMelHubService.startConnection();
    this.favoDeMelHubService.PedidoCriadoEventListener((data) => this.loadComanda());
    this.favoDeMelHubService.PedidoItemProducaoIniciadaEventListener((data) => this.loadComanda());
    this.favoDeMelHubService.PedidoItemProducaoFinalizadaEventListener((data) => this.loadComanda());
    this.favoDeMelHubService.PedidoItemCanceladoEventListener((data) => this.loadComanda());
    this.loadValores();
  }

  ngOnDestroy(): void {
    this.favoDeMelHubService.disconnect();
  }

  loadComanda(): void {
    this.activatedRoute.params.subscribe(({ id }) => {
      this.store.dispatch(actions.carregarDetalheComanda({ id }));
    });
  }

  loadValores() {
    this.data$.subscribe(comandaDetalhada => {
      this.total = 0;
      this.desconto = 0;
      if (comandaDetalhada.comanda) {
        comandaDetalhada.comanda.pedidos.forEach(pedido => {
          this.total += pedido.itens.reduce((a, b) => a + (b['situacaoId'] != 5 ? b['valor'] : 0), 0);
          this.desconto += pedido.itens.reduce((a, b) => a + (b['situacaoId'] == 5 ? b['valor'] : 0), 0);
        });
      }
    })
  }

  showBtnCancelar(pedidoItem) {
    if (!pedidoItem.producaoPrioridade && pedidoItem.situacaoId == 3) {
      return true
    }else if(pedidoItem.producaoPrioridade && pedidoItem.situacaoId == 1){
      return true
    }

    return false;
  }

  abrirModal(pedidoId, pedidoItemId, produto) {
    this.pedidoId = pedidoId;
    this.pedidoitemId = pedidoItemId;
    this.produto = produto;
    this.modal.show();
  }

  fecharModal() {
    this.modal.hide();
  }

  submitModal() {
    this.blockUI.start('carregando...');


    this.pedidoService.cancelarPedidoItem(this.pedidoId, this.pedidoitemId).pipe()
      .subscribe(
        data => {
          this.appToastrService.showSuccessMessage('Pedido Item', "Pedido item cancelado com sucesso.");
          this.blockUI.stop();
          this.fecharModal();
          this.loadComanda();
        },
        error => {
          this.appToastrService.showErrorMessage('Pedido Item', error.error);
          this.blockUI.stop();
        }
      );
  }
}
