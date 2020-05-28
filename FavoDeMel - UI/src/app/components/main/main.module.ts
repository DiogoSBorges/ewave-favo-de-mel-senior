import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainRoutingModule} from './main.routing.module'
import { MainComponent } from './main.component';


@NgModule({
    imports: [
        MainRoutingModule,
        CommonModule,
    ],   
    declarations: [MainComponent], 
})
export class MainModule { }