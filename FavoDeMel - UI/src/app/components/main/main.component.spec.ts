import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { MainComponent } from './main.component';

describe('MainComponent', () => {
    let component: MainComponent;
    let componentFixture: ComponentFixture<MainComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ MainComponent ]
      }).compileComponents();
    }));
  
    beforeEach(() => {
      componentFixture = TestBed.createComponent(MainComponent);
      component = componentFixture.componentInstance;
      componentFixture.detectChanges();
    });
  
    it('should create component', () => {
      expect(component).toBeTruthy();
    });
  });