import { createReducer, on } from '@ngrx/store';

import * as actions from '../comanda/comanda.actions';

const initialState = {
  comandas: {
    isLoading: false,
    errorMessage: null,
    data: []
  },
  comandaDetalhada: {
    isLoading: false,
    errorMessage: null,
    comanda: null
  }
};

const reducer = createReducer(
  initialState,
  on(actions.carregarComandas, (state) => {
    return {
      ...state,
      comandas: {
        ...state.comandas,
        isLoading: true
      }
    };
  }),
  on(actions.carregarComandasSuccess, (state, { payload: comandas }) => {
    return {
      ...state,
      comandas: {
        ...state.comandas,
        isLoading: false,
        errorMessage: null,
        data: comandas
      },
    };
  }),
  on(actions.carregarComandasError, (state, { payload: error }) => {
    return {
      ...state,
      comandas: {
        ...state.comandas,
        isLoading: false,
        errorMessage: error.message,
      }
    };
  }),
  on(actions.carregarDetalheComanda, (state) => {
    return {
      ...state,
      comandaDetalhada: {
        ...state.comandaDetalhada,
        isLoading: true
      }
    };
  }),
  on(actions.carregarDetalheComandaSuccess, (state, { payload: comanda }) => {
    return {
      ...state,
      comandaDetalhada: {
        ...state.comandaDetalhada,
        isLoading: false,
        errorMessage: null,
        comanda: comanda
      },
    };
  }),
  on(actions.carregarDetalheComandaError, (state, { payload: error }) => {
    return {
      ...state,
      comandaDetalhada: {
        ...state.comandaDetalhada,
        isLoading: false,
        errorMessage: error.message,
      }
    };
  })
);

export function comandaReducer(state, action) {
  return reducer(state, action);
}
