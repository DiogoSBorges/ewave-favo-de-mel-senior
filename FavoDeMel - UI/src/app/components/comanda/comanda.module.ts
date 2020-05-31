import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComandaComponent } from './comanda-lista/comanda.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {ComandaRoutingModule} from './comanda.routing.module'
import { ComandaCadastrarPedidoComponent } from './cadastrar-pedido/cadastrar-pedido.component';
import { BsModalRef, ModalModule } from 'ngx-bootstrap/modal';
import { ComandaDetalheComponent } from './comanda-detalhe/comanda-detalhe.component';


@NgModule({
    imports: [
        CommonModule,
        ComandaRoutingModule,
        ModalModule.forRoot(),
        FormsModule,
        ReactiveFormsModule,
    ],   
    declarations: [ComandaComponent, ComandaDetalheComponent, ComandaCadastrarPedidoComponent], 
    providers:[BsModalRef]
})
export class ComandaModule { }