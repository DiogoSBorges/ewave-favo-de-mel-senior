import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { ProducaoListaComponent } from './producao-lista.component';

describe('ProducaoListaComponent', () => {
  let component: ProducaoListaComponent;
  let componentFixture: ComponentFixture<ProducaoListaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ProducaoListaComponent]
    }).compileComponents();
  }));

  beforeEach(() => {
    componentFixture = TestBed.createComponent(ProducaoListaComponent);
    component = componentFixture.componentInstance;
    componentFixture.detectChanges();
  });

  it('should create the component', () => {
    expect(component).toBeTruthy();
  });
});