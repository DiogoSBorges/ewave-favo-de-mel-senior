import { Component, OnInit, OnDestroy, Injector, ViewChild } from '@angular/core';
import { Store } from '@ngrx/store';
import { ActivatedRoute } from '@angular/router';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Observable } from 'rxjs';

import * as produtoSelectors from '../../../store/produto/produto.selectors';
import * as produtoActions from '../../../store/produto/produto.actions';

@Component({
    selector: 'comanda-cadastrar-pedido',
    templateUrl: './cadastrar-pedido.component.html',
})
export class ComandaCadastrarPedidoComponent {

    @ViewChild('modal') modal: ModalDirective;

    private activatedRoute: ActivatedRoute
    private formBuilder: FormBuilder;
    private store: Store<any>;

    produtos$: Observable<any>;

    form: FormGroup;
    isSubmitted: boolean = false;

    constructor(
        injector: Injector,
        activatedRoute: ActivatedRoute) {
        this.activatedRoute = activatedRoute;
        this.formBuilder = injector.get(FormBuilder);
        this.store = injector.get(Store);
        this.produtos$ = this.store.select(produtoSelectors.selectProduto);

        this.criarFormulario();
    }

    ngOnInit(): void {
        this.activatedRoute.params.subscribe(({ id }) => {
            console.log(id);
        });

        this.buscaProdutos();
    }

    buscaProdutos() {
        this.produtos$.subscribe(produtos => {            
            if(!produtos.isLoading && !produtos.errorMessage && produtos.data.length <= 0){
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

    abrirModal() {
        this.modal.show();
    }

    fecharModal() {
        this.modal.hide();
    }

    cancelar() {
        this.modal.hide();
        this.form.reset();
    }

    submit() {
        if (this.form.valid) {
            this.isSubmitted = false;
            const formData = this.form.getRawValue();
            console.log(formData)
        }
        this.isSubmitted = true;
    }
}
