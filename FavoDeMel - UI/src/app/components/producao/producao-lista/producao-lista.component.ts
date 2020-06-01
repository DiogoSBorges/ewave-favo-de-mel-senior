import { Component, OnInit, OnDestroy, Injector, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';

import * as actions from '../../../store/producao/producao.actions';
import * as selectors from '../../../store/producao/producao.selectors';
import { Observable } from 'rxjs';
import { FavoDeMelHubService } from 'src/app/services/favoDeMelHub.service';
import { ModalDirective } from 'ngx-bootstrap/modal/public_api';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ComandaService } from 'src/app/services/comanda.service';
import { AppToastrService } from 'src/app/services/AppToastr.service';
import { PedidoService } from 'src/app/services/pedido.service';

@Component({
  selector: 'producao-lista',
  templateUrl: './producao-lista.component.html',
  styleUrls: ['./producao-lista.component.scss'],
})
export class ProducaoListaComponent implements OnInit, OnDestroy {

  @ViewChild('modal') modal: ModalDirective;
  @BlockUI() blockUI: NgBlockUI;

  private store: Store<any>;
  private pedidoService: PedidoService;
  private favoDeMelHubService: FavoDeMelHubService;
  private appToastrService: AppToastrService;



  data$: Observable<any>;
  modalAcao: Number;
  modalNomeProduto: string;
  pedidoId: Number;
  pedidoItemId: Number;


  constructor(
    injector: Injector,
    favoDeMelHubService: FavoDeMelHubService,
    appToastrService: AppToastrService,
    pedidoService: PedidoService) {

    this.store = injector.get(Store);
    this.data$ = this.store.select(selectors.selectProducao);
    this.favoDeMelHubService = favoDeMelHubService;
    this.appToastrService = appToastrService;
    this.pedidoService = pedidoService;
  }
  
  ngOnInit(): void {
    this.loadProducao();
    this.favoDeMelHubService.startConnection();
    this.favoDeMelHubService.PedidoCriadoEventListener((data) => this.loadProducao());
    this.favoDeMelHubService.PedidoItemProducaoIniciadaEventListener((data) => this.loadProducao());
    this.favoDeMelHubService.PedidoItemProducaoFinalizadaEventListener((data) => this.loadProducao());
    this.favoDeMelHubService.PedidoItemCanceladoEventListener((data) => this.loadProducao());
    this.favoDeMelHubService.PedidoItemPriorizadoEventListener((data) => this.loadProducao());
  }

  ngOnDestroy(): void {
    this.favoDeMelHubService.disconnect();
  }

  loadProducao(): void {
    this.store.dispatch(actions.carregarProducao());
  }

  obterClasseDePrioridade(prioridadeId) {
    switch (prioridadeId) {
      case 1:
        return 'produto-prioridade-normal';

      case 2:
        return 'produto-prioridade-alta';

      case 3:
        return 'produto-prioridade-urgente';

      default:
        return 'produto-prioridade-normal';
    }
  }

  getModalAcaoDescricao() {
    if (this.modalAcao == 1) {
      return "Iniciar";
    } else if (this.modalAcao == 2) {
      return "Finalizar";
    } else {
      return "";
    }
  }


  abrirModal(acao, pedidoId, pedidoItemId, nomeProduto) {
    this.modalAcao = acao;
    this.pedidoId = pedidoId;
    this.pedidoItemId = pedidoItemId;
    this.modalNomeProduto = nomeProduto;
    this.modal.show();
  }

  fecharModal() {
    this.modal.hide();
  }

  submitModal() {
    this.blockUI.start('carregando...');

    if (this.modalAcao == 1) {
      this.pedidoService.iniciarProducaoPedidoItem(this.pedidoId, this.pedidoItemId).pipe()
        .subscribe(
          data => {
            this.appToastrService.showSuccessMessage('Produção', "Produção iniciado com sucesso.");
            this.blockUI.stop();
            this.fecharModal();
            this.loadProducao();
          },
          error => {
            this.appToastrService.showErrorMessage('Produção', error.error);
            this.blockUI.stop();
          }
        );
    } else if (this.modalAcao == 2) {
      this.pedidoService.finalizarProducaoPedidoItem(this.pedidoId, this.pedidoItemId).pipe()
        .subscribe(
          data => {
            this.appToastrService.showSuccessMessage('Produção', "Produção finalizada com sucesso.");
            this.blockUI.stop();
            this.fecharModal();
            this.loadProducao();
          },
          error => {
            this.appToastrService.showErrorMessage('Produção', error.error);
            this.blockUI.stop();
          }
        );
    } else {
      this.blockUI.stop();
    }
  }
}
