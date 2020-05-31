import { Component, OnInit, OnDestroy, Injector, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { ActivatedRoute, Router } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';

import * as produtoSelectors from '../../../store/produto/produto.selectors';
import * as produtoActions from '../../../store/produto/produto.actions';

import * as comandaSelectors from '../../../store/comanda/comanda.selectors';

import { PedidoService } from '../../../services/pedido.service'
import { AppToastrService } from 'src/app/services/AppToastr.service';

import { BlockUI, NgBlockUI } from 'ng-block-ui';
import { ThrowStmt } from '@angular/compiler';

@Component({
    selector: 'comanda-cadastrar-pedido',
    templateUrl: './cadastrar-pedido.component.html',
})
export class ComandaCadastrarPedidoComponent {

    @ViewChild('modal') modal: ModalDirective;
    @BlockUI() blockUI: NgBlockUI;

    private activatedRoute: ActivatedRoute
    private formBuilder: FormBuilder;
    private store: Store<any>;
    private router: Router;

    private pedidoService: PedidoService;
    private appTastrService: AppToastrService;

    produtos$: Observable<any>;

    itensDePedido: Array<any> = [];
    comandaId: Number
    comandaNumero: Number
    observacao_pedido: string;

    form: FormGroup;
    isSubmitted: boolean = false;

    constructor(
        injector: Injector,
        activatedRoute: ActivatedRoute,
        router: Router,
        pedidoService: PedidoService,
        appTastrService: AppToastrService) {
        this.activatedRoute = activatedRoute;
        this.router = router;
        this.pedidoService = pedidoService;
        this.formBuilder = injector.get(FormBuilder);
        this.store = injector.get(Store);
        this.produtos$ = this.store.select(produtoSelectors.selectProduto);
        this.appTastrService = appTastrService;

        this.criarFormulario();
    }

    ngOnInit(): void {
        this.activatedRoute.params.subscribe(({ id }) => {
            this.comandaId = id;
            this.comandaNumero = this.getComandaFromStore(id)?.numero ?? '';
        });

        this.buscaProdutos();
    }

    buscaProdutos() {
        this.produtos$.subscribe(produtos => {
            if (!produtos.isLoading && !produtos.errorMessage && produtos.data.length <= 0) {
                this.store.dispatch(produtoActions.carregarProdutos());
            }
        })
    }

    criarFormulario() {
        this.form = this.formBuilder.group({
            produtoId: [null, Validators.required],
            observacao: [null]
        })
    }

    getProdutoFromStore(id: Number) {
        let produto;
        this.produtos$.pipe().subscribe(produtos => produto = produtos.data.find(x => x.id == id))
        return produto
    }

    getComandaFromStore(id: Number) {
        let comanda;
        this.store.select(comandaSelectors.selectComanda).pipe().subscribe(comandas => comanda = comandas.data.find(x => x.id == id))
        return comanda
    }

    abrirModalItem() {
        this.modal.show();
        this.isSubmitted = false;
    }

    fecharModalItem() {
        this.modal.hide();
        this.form.reset();
    }

    submitModalItem() {
        if (this.form.valid) {
            this.isSubmitted = false;
            let formData = this.form.getRawValue();

            const produto = this.getProdutoFromStore(formData.produtoId);
            formData.nome = produto.nome;
            formData.valor = produto.valor;

            this.itensDePedido.push(formData);
            this.fecharModalItem();
        }
        this.isSubmitted = true;
    }

    getTotal() {
        return this.itensDePedido.reduce((a, b) => a + (b['valor'] || 0), 0);
    }

    salvarPedido() {
        this.blockUI.start('carregando...');

        var pedido = {
            comandaId: this.comandaId,
            itens: this.itensDePedido,
            observacao: this.observacao_pedido
        }

        this.pedidoService.criarPedido(pedido).pipe()
            .subscribe(
                data => {
                    this.appTastrService.showSuccessMessage('Pedido', "Pedido criado com sucesso");
                    this.blockUI.stop();
                    this.router.navigate(['/comandas']);
                },
                error => {
                    this.appTastrService.showErrorMessage('Pedido', error.error);
                    this.blockUI.stop();
                }
            );
    }
}
