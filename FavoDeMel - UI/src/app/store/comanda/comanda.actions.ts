import { createAction, props } from '@ngrx/store';

const payloadResult = (payload) => ({ payload });

export const carregarComandas = createAction('CARREGAR_COMANDAS', props<{ params: any }>());
export const carregarComandasSuccess = createAction("CARREGAR_COMANDAS_SUCCESS", payloadResult);
export const carregarComandasError = createAction('CARREGAR_COMANDAS_ERROR', payloadResult);