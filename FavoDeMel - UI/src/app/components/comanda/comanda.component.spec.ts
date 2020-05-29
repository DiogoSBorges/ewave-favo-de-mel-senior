import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { ComandaComponent } from './comanda.component';

describe('ComandaComponent', () => {
    let component: ComandaComponent;
    let componentFixture: ComponentFixture<ComandaComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ ComandaComponent ]
      }).compileComponents();
    }));
  
    beforeEach(() => {
      componentFixture = TestBed.createComponent(ComandaComponent);
      component = componentFixture.componentInstance;
      componentFixture.detectChanges();
    });
  
    it('should create the component', () => {
      expect(component).toBeTruthy();
    });
  });