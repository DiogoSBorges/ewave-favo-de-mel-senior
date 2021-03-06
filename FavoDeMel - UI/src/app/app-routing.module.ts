import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'main',
    pathMatch: 'full',
  },
  {
    path: 'main',
    loadChildren: () => import('./components/main/main.module').then((m) => m.MainModule),
  },
  { 
    path: 'comandas',
    loadChildren: () => import('./components/comanda/comanda.module').then((m) => m.ComandaModule),
  },
  { 
    path: 'producao',
    loadChildren: () => import('./components/producao/producao.module').then((m) => m.ProducaoModule),
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
