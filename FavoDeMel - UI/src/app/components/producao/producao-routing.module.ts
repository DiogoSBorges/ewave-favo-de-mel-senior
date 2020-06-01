import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProducaoListaComponent } from './producao-lista/producao-lista.component';

const routes: Routes = [
  {
    path: '',
    component: ProducaoListaComponent,
  }, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProducaoRoutingModule {}