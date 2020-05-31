import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { ComandaDetalheComponent } from './comanda-detalhe.component';

describe('ComandaDetalheComponent', () => {
    let component: ComandaDetalheComponent;
    let componentFixture: ComponentFixture<ComandaDetalheComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ ComandaDetalheComponent ]
      }).compileComponents();
    }));
  
    beforeEach(() => {
      componentFixture = TestBed.createComponent(ComandaDetalheComponent);
      component = componentFixture.componentInstance;
      componentFixture.detectChanges();
    });
  
    it('should create the component', () => {
      expect(component).toBeTruthy();
    });
  });