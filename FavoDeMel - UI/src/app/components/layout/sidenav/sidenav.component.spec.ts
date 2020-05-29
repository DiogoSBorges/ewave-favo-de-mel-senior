import { TestBed, async, ComponentFixture } from '@angular/core/testing';

import { SideNavComponent } from './sidenav.component';

describe('LayoutComponent', () => {
    let component: SideNavComponent;
    let componentFixture: ComponentFixture<SideNavComponent>;
  
    beforeEach(async(() => {
      TestBed.configureTestingModule({
        declarations: [ SideNavComponent ]
      })
      .compileComponents();
    }));
  
    beforeEach(() => {
      componentFixture = TestBed.createComponent(SideNavComponent);
      component = componentFixture.componentInstance;
      componentFixture.detectChanges();
    });
  
    it('should create the component', () => {
      expect(component).toBeTruthy();
    });
  });
  