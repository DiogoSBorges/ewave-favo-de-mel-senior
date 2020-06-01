import { createReducer, on } from '@ngrx/store';

import * as actions from './producao.actions';

const initialState = {
  producao: {
    isLoading: false,
    errorMessage: null,
    data: null
  }
};

const reducer = createReducer(
  initialState,
  on(actions.carregarProducao, (state) => {
    return {
      ...state,
      producao: {
        ...state.producao,
        isLoading: true
      }
    };
  }),
  on(actions.carregarProducaoSuccess, (state, { payload: producao }) => {
    return {
      ...state,
      producao: {
        ...state.producao,
        isLoading: false,
        errorMessage: null,
        data: producao
      },
    };
  }),
  on(actions.carregarProducaoError, (state, { payload: error }) => {
    return {
      ...state,
      producao: {
        ...state.producao,
        isLoading: false,
        errorMessage: error.message,
      }
    };
  })
);

export function producaoReducer(state, action) {
  return reducer(state, action);
}
