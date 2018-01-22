import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  MatButtonModule,
  MatCheckboxModule,
  MatInputModule,
  MatProgressSpinnerModule
} from '@angular/material';

import {
  CostumesService,
  GarmentTypesService,
  MeasurementTypesService
 } from './services';
import { LoadingComponent } from './components/loading/loading.component';
import { FilePickerDirective } from './directives/file-picker.directive';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatProgressSpinnerModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    LoadingComponent,
    FilePickerDirective
  ],
  declarations: [
    LoadingComponent,
    FilePickerDirective
  ],
  providers: [
    CostumesService,
    GarmentTypesService,
    MeasurementTypesService
  ]
})
export class SharedModule { }
