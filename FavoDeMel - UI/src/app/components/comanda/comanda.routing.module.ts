import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ComandaComponent } from './comanda.component';
import { ComandaCadastrarPedidoComponent } from './cadastrar-pedido/cadastrar-pedido.component';

const routes: Routes = [
  {
    path: '',
    component: ComandaComponent,
  },
  {
    path: ':id/cadastrar-pedido',
    component: ComandaCadastrarPedidoComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ComandaRoutingModule {}