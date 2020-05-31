import { createAction, props } from '@ngrx/store';

const payloadResult = (payload) => ({ payload });

export const carregarComandas = createAction('CARREGAR_COMANDAS', props<{ params: any }>());
export const carregarComandasSuccess = createAction("CARREGAR_COMANDAS_SUCCESS", payloadResult);
export const carregarComandasError = createAction('CARREGAR_COMANDAS_ERROR', payloadResult);

export const carregarDetalheComanda = createAction('CARREGAR_COMANDA_DETALHE', props<{ id: Number }>());
export const carregarDetalheComandaSuccess = createAction("CARREGAR_COMANDA_DETALHE_SUCCESS", payloadResult);
export const carregarDetalheComandaError = createAction('CARREGAR_COMANDA_DETALHE_ERROR', payloadResult);