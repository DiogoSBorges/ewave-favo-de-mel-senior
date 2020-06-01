import { createSelector } from '@ngrx/store';

export const selectProducaoStore = (state) => state.producao;

export const selectProducao = createSelector(selectProducaoStore, (state) => state.producao);