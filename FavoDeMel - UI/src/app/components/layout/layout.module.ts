import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { LayoutComponent } from './base/layout.component';

@NgModule({
  declarations: [LayoutComponent],
  imports: [CommonModule, BrowserModule, RouterModule],  
  exports: [LayoutComponent],
})
export class LayoutModule {}
