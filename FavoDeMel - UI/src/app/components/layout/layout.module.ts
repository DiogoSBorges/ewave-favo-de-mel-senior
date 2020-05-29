import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { LayoutComponent } from './base/layout.component';
import { SideNavComponent } from './sidenav/sidenav.component';
import { NavBarComponent } from './navbar/navbar.component';


@NgModule({
  declarations: [LayoutComponent, SideNavComponent, NavBarComponent],
  imports: [
    CommonModule, 
    BrowserModule, 
    RouterModule,
  ],  
  exports: [LayoutComponent],
})
export class LayoutModule {}
