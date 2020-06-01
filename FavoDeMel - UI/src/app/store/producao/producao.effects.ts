import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import { of } from 'rxjs';
import { catchError, mergeMap, map, } from 'rxjs/operators';

import * as actions from './producao.actions';

import { PedidoService } from '../../services/pedido.service'

@Injectable()
export class ProducaoEffect {

    constructor(
        private actions$: Actions,
        private service: PedidoService
    ) { }

    carregarProducao$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(actions.carregarProducao),
            mergeMap(() => this.service.obterPedidoItemProducao()),
            map((res) => {
                return actions.carregarProducaoSuccess(res);
            }),
            catchError((error) => of(actions.carregarProducaoError(error)))
        )
    });
}
