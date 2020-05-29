import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ComandaComponent } from './comanda.component';

import {ComandaRoutingModule} from './comanda.routing.module'


@NgModule({
    imports: [
        CommonModule,
        ComandaRoutingModule
    ],   
    declarations: [ComandaComponent], 
})
export class ComandaModule { }