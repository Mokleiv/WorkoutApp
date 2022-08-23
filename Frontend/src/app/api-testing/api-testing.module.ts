import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApiTestingRoutingModule } from './api-testing-routing.module';
import { ApiTestComponent } from './api-test/api-test.component';


@NgModule({
  declarations: [
    ApiTestComponent
  ],
  imports: [
    CommonModule,
    ApiTestingRoutingModule
  ]
})
export class ApiTestingModule { }
