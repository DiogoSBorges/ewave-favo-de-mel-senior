import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { LayoutComponent } from './layout.component';

describe('LayoutComponent', () => {
    let component: LayoutComponent;
    let componentFixture: ComponentFixture<LayoutComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ LayoutComponent ]
      })
      .compileComponents();
    }));
  
    beforeEach(() => {
      componentFixture = TestBed.createComponent(LayoutComponent);
      component = componentFixture.componentInstance;
      componentFixture.detectChanges();
    });
  
    it('should create component', () => {
      expect(component).toBeTruthy();
    });
  });
  