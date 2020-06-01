import { createAction, props } from '@ngrx/store';

const payloadResult = (payload) => ({ payload });

export const carregarProducao = createAction('CARREGAR_PRODUCAO');
export const carregarProducaoSuccess = createAction("CARREGAR_PRODUCAO_SUCCESS", payloadResult);
export const carregarProducaoError = createAction('CARREGAR_PRODUCAO_ERROR', payloadResult);