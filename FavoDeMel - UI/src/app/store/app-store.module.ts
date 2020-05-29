import { NgModule } from '@angular/core';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import reducers from './reducers';
import effects from './effects';

@NgModule({
    imports: [
        StoreModule.forRoot(reducers),
        EffectsModule.forRoot(effects)
    ],
    providers: [],
    exports: [StoreModule],
})
export class AppStoreModule { }
