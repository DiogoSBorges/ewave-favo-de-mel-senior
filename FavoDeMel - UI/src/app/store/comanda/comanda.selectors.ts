import { createSelector } from '@ngrx/store';

export const selectComandaStore = (state) => state.comanda;

export const selectComanda = createSelector(selectComandaStore, (state) => state.comandas);
export const selectComandaDetalhada = createSelector(selectComandaStore, (state) =>  state.comandaDetalhada);