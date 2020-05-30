import { createReducer, on } from '@ngrx/store';

import * as actions from '../produto/produto.actions';

const initialState = {
  produtos: {
      isLoading: false,
      errorMessage : null,
      data : []  
  }
};

const reducer = createReducer(
  initialState,
  on(actions.carregarProdutos, (state) => {
    return {
      ...state,
      produtos:{
          ...state.produtos,
          isLoading: true
      }
    };
  }),
  on(actions.carregarProdutosSuccess, (state, { payload: comandas }) => {
    return {
      ...state,
      produtos:{
        ...state.produtos,
        isLoading:false,
        errorMessage:null,
        data: comandas
      },
    };
  }),
  on(actions.carregarProdutosError, (state, { payload: error }) => {
    return {
      ...state,
      produtos:{
        ...state.produtos,
        isLoading:false,
        errorMessage:error.message,
      }
    };
  })
);

export function produtoReducer(state, action) {
  return reducer(state, action);
}
