import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {ProducaoRoutingModule} from './producao-routing.module'
import { BsModalRef, ModalModule } from 'ngx-bootstrap/modal';
import { ProducaoListaComponent } from './producao-lista/producao-lista.component';


@NgModule({
    imports: [
        CommonModule,
        ProducaoRoutingModule,
        ModalModule.forRoot(),
        FormsModule,
        ReactiveFormsModule,
    ],   
    declarations: [ProducaoListaComponent], 
    providers:[BsModalRef]
})
export class ProducaoModule { }