import { comandaReducer } from './comanda/comanda.reducer';
import { produtoReducer } from './produto/produto.reducer';
import { producaoReducer } from './producao/producao.reducer';

export default {
    comanda: comandaReducer,
    produto: produtoReducer,
    producao: producaoReducer
}