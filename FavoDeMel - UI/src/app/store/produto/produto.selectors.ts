import { createSelector } from '@ngrx/store';

export const selectProdutoStore = (state) => state.produto;

export const selectProduto = createSelector(selectProdutoStore, (state) => state.produtos);