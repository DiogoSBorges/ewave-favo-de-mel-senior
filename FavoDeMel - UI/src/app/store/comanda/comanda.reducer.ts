import { createReducer, on } from '@ngrx/store';

import * as actions from '../comanda/comanda.actions';

const initialState = {
  comandas: {
      isLoading: false,
      errorMessage : null,
      data : []  
  }
};

const reducer = createReducer(
  initialState,
  on(actions.carregarComandas, (state) => {
    return {
      ...state,
      comandas:{
          ...state.comandas,
          isLoading: true
      }
    };
  }),
  on(actions.carregarComandasSuccess, (state, { payload: comandas }) => {
    return {
      ...state,
      comandas:{
        ...state.comandas,
        isLoading:false,
        errorMessage:null,
        data: comandas
      },
    };
  }),
  on(actions.carregarComandasError, (state, { payload: error }) => {
    return {
      ...state,
      comandas:{
        ...state.comandas,
        isLoading:false,
        errorMessage:error.message,
      }
    };
  })
);

export function comandaReducer(state, action) {
  return reducer(state, action);
}
