import { createAction, props } from '@ngrx/store';

const payloadResult = (payload) => ({ payload });

export const carregarProdutos = createAction('CARREGAR_PRODUTOS');
export const carregarProdutosSuccess = createAction("CARREGAR_PRODUTOS_SUCCESS", payloadResult);
export const carregarProdutosError = createAction('CARREGAR_PRODUTOS_ERROR', payloadResult);