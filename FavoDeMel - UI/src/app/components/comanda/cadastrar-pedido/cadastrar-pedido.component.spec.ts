import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { ComandaCadastrarPedidoComponent } from './cadastrar-pedido.component';

describe('ComandaCadastrarPedidoComponent', () => {
    let component: ComandaCadastrarPedidoComponent;
    let componentFixture: ComponentFixture<ComandaCadastrarPedidoComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ ComandaCadastrarPedidoComponent ]
      }).compileComponents();
    }));
  
    beforeEach(() => {
      componentFixture = TestBed.createComponent(ComandaCadastrarPedidoComponent);
      component = componentFixture.componentInstance;
      componentFixture.detectChanges();
    });
  
    it('should create the component', () => {
      expect(component).toBeTruthy();
    });
  });