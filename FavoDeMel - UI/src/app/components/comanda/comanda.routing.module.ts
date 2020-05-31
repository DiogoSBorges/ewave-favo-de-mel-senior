import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComandaComponent } from './comanda-lista/comanda.component';
import { ComandaCadastrarPedidoComponent } from './cadastrar-pedido/cadastrar-pedido.component';
import { ComandaDetalheComponent } from './comanda-detalhe/comanda-detalhe.component';

const routes: Routes = [
  {
    path: '',
    component: ComandaComponent,
  },
  {
    path: ':id/cadastrar-pedido',
    component: ComandaCadastrarPedidoComponent,
  },
  {
    path: ':id/detalhe',
    component: ComandaDetalheComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ComandaRoutingModule {}