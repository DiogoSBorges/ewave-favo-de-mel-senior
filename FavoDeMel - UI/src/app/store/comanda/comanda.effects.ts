import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';

import { of } from 'rxjs';
import { catchError, mergeMap, map, } from 'rxjs/operators';

import * as actions from './comanda.actions';

import {ComandaServices} from '../../services/comanda.service'

@Injectable()
export class ComandaEffect {

    constructor(
        private actions$: Actions,
        private service: ComandaServices
    ) { }

    carregarComandas$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(actions.carregarComandas),
            map((params)=> params),
            mergeMap(({params}) => this.service.obterTodos(params)),
            map((res) => {
                return actions.carregarComandasSuccess(res);
            } ),
            catchError((error) => of(actions.carregarComandasError(error)))
        )
    });

}
