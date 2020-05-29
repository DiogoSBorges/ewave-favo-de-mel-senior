import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { NavBarComponent } from './navbar.component';

describe('NavBarComponent', () => {
    let component: NavBarComponent;
    let componentFixture: ComponentFixture<NavBarComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ NavBarComponent ]
      })
      .compileComponents();
    }));
  
    beforeEach(() => {
      componentFixture = TestBed.createComponent(NavBarComponent);
      component = componentFixture.componentInstance;
      componentFixture.detectChanges();
    });
  
    it('should create the component', () => {
      expect(component).toBeTruthy();
    });
  });
  