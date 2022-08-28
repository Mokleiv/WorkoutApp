import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApiTestingRoutingModule } from './api-testing-routing.module';
import { ApiTestComponent } from './api-test/api-test.component';
import { MatSliderModule } from '@angular/material/slider';
import { TempCompComponent } from './api-test/temp-comp/temp-comp.component';

@NgModule({
  declarations: [ApiTestComponent, TempCompComponent],
  imports: [CommonModule, MatSliderModule, ApiTestingRoutingModule],
})
export class ApiTestingModule {}
