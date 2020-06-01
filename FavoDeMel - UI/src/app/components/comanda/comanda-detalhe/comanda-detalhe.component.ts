import { Component, OnInit, OnDestroy, Injector, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';

import * as actions from '../../../store/comanda/comanda.actions';
import * as selectors from '../../../store/comanda/comanda.selectors';
import { Observable } from 'rxjs';

import { FavoDeMelHubService } from 'src/app/services/favoDeMelHub.service';

import { ActivatedRoute } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal/public_api';
import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { PedidoService } from 'src/app/services/pedido.service';
import { AppToastrService } from 'src/app/services/AppToastr.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'comanda-detalhe',
  templateUrl: './comanda-detalhe.component.html',
  styleUrls: ['./comanda-detalhe.component.scss'],
})
export class ComandaDetalheComponent implements OnInit, OnDestroy {

  @ViewChild('modal') modal: ModalDirective;
  @ViewChild('modal_prioridade') modal_prioridade: ModalDirective;
  @BlockUI() blockUI: NgBlockUI;

  private formBuilder: FormBuilder;

  private store: Store<any>;
  private favoDeMelHubService: FavoDeMelHubService;
  private activatedRoute: ActivatedRoute;
  private pedidoService: PedidoService;
  private appToastrService: AppToastrService;

  readonly ACAO_CANCELAR: number = 1;
  readonly ACAO_ENTREGAR: number = 2;

  readonly PRIORIDADE_NORMAL: number = 1;
  readonly PRIORIDADE_ALTA: number = 2;
  readonly PRIORIDADE_URGENTE: number = 3;

  modalAcao: number;

  data$: Observable<any>;

  total: number = 0;
  desconto: number = 0;

  pedidoId: number;
  pedidoitemId: number;
  pedidoitemPrioridadeId: number;
  produto: string;

  form_prioridade: FormGroup;
  isSubmitted: boolean = false;

  constructor(
    injector: Injector,
    activatedRoute: ActivatedRoute,
    favoDeMelHubService: FavoDeMelHubService,
    pedidoService: PedidoService,
    appToastrService: AppToastrService) {
    this.activatedRoute = activatedRoute;
    this.formBuilder = injector.get(FormBuilder);
    this.store = injector.get(Store);
    this.data$ = this.store.select(selectors.selectComandaDetalhada);
    this.favoDeMelHubService = favoDeMelHubService;
    this.pedidoService = pedidoService;
    this.appToastrService = appToastrService;

    this.criarFormularioPriorizacao()
  }

  ngOnInit(): void {
    this.loadComanda();
    this.favoDeMelHubService.startConnection();
    this.favoDeMelHubService.PedidoCriadoEventListener((data) => this.loadComanda());
    this.favoDeMelHubService.PedidoItemProducaoIniciadaEventListener((data) => this.loadComanda());
    this.favoDeMelHubService.PedidoItemProducaoFinalizadaEventListener((data) => this.loadComanda());
    this.favoDeMelHubService.PedidoItemCanceladoEventListener((data) => this.loadComanda());
    this.favoDeMelHubService.PedidoItemEntregueEventListener((data) => this.loadComanda());
    this.favoDeMelHubService.PedidoItemPriorizadoEventListener((data) => this.loadComanda());
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
    } else if (pedidoItem.producaoPrioridade && pedidoItem.situacaoId == 1) {
      return true
    }

    return false;
  }

  getPriodadeDescricao(prioridadeId) {
    switch (prioridadeId) {
      case this.PRIORIDADE_NORMAL:
        return "Normal"
      case this.PRIORIDADE_ALTA:
        return "Alta"
      case this.PRIORIDADE_URGENTE:
        return "Urgente"
      default:
        return '';
    }
  }

  getModalAcaoDescricao() {
    if (this.modalAcao == this.ACAO_CANCELAR) {
      return "Cancelar";
    } else if (this.modalAcao == this.ACAO_ENTREGAR) {
      return "Entregar";
    } else {
      return "";
    }
  }

  abrirModal(acao, pedidoId, pedidoItemId, produto) {
    this.modalAcao = acao;
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
    if (this.modalAcao == this.ACAO_CANCELAR) {
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
    } else if (this.modalAcao == this.ACAO_ENTREGAR) {
      this.pedidoService.entregarPedidoItem(this.pedidoId, this.pedidoitemId).pipe()
        .subscribe(
          data => {
            this.appToastrService.showSuccessMessage('Pedido Item', "Pedido item entregue com sucesso.");
            this.blockUI.stop();
            this.fecharModal();
            this.loadComanda();
          },
          error => {
            this.appToastrService.showErrorMessage('Pedido Item', error.error);
            this.blockUI.stop();
          }
        );
    } else {
      this.blockUI.stop();
    }
  }

  criarFormularioPriorizacao() {
    this.form_prioridade = this.formBuilder.group({
      prioridadeId: [null, Validators.required],
    })
  }

  abrirModalPrioridade(pedidoId, pedidoItemId, prioridadeId, produto) {
    this.pedidoId = pedidoId;
    this.pedidoitemId = pedidoItemId;
    this.pedidoitemPrioridadeId = prioridadeId;
    this.produto = produto;
    this.modal_prioridade.show();
  }

  fecharModalPrioridade() {
    this.modal_prioridade.hide();
  }

  submitModalPrioridade() {
    if (this.form_prioridade.valid) {
      this.blockUI.start('carregando...');
      this.isSubmitted = false;

      let formData = this.form_prioridade.getRawValue();

      this.pedidoService.priorizarProducaoPedidoItem(this.pedidoId, this.pedidoitemId, formData.prioridadeId).pipe()
      .subscribe(
        data => {
          this.appToastrService.showSuccessMessage('Pedido Item', "Pedido item prioridade alterada com sucesso.");
          this.blockUI.stop();
          this.fecharModal();
          this.loadComanda();
        },
        error => {
          this.appToastrService.showErrorMessage('Pedido Item', error.error);
          this.blockUI.stop();
        }
      );

      console.log(formData)
      this.fecharModalPrioridade();
    } else {
      this.isSubmitted = true;
    }
  }
}
