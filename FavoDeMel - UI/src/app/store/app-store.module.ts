import { NgModule } from '@angular/core';

import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';

import reducers from './reducers';
import effects from './effects';

import { environment } from 'src/environments/environment';

@NgModule({
    imports: [
        StoreModule.forRoot(reducers,),
        EffectsModule.forRoot(effects),
        StoreDevtoolsModule.instrument({
            maxAge: 30,
            logOnly: environment.production,
          }),
    ],
    providers: [],
    exports: [StoreModule],
})
export class AppStoreModule { }
