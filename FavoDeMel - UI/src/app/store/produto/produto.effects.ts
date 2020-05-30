import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import { of } from 'rxjs';
import { catchError, mergeMap, map, } from 'rxjs/operators';

import * as actions from './produto.actions';

import { ProdutoService } from '../../services/produto.service'

@Injectable()
export class ProdutoEffect {

    constructor(
        private actions$: Actions,
        private service: ProdutoService
    ) { }

    carregarProdutos$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(actions.carregarProdutos),
            mergeMap(() => this.service.obterTodos()),
            map((res) => {
                return actions.carregarProdutosSuccess(res);
            }),
            catchError((error) => of(actions.carregarProdutosError(error)))
        )
    });

}
