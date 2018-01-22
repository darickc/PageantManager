import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  MatButtonModule,
  MatCheckboxModule,
  MatInputModule
} from '@angular/material';

import {
  // ApiService,
  // PageantsService
  CostumesService,
  MeasurementTypesService
 } from './services';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule
  ],
  declarations: [],
  providers: [
    // ApiService,
    // PageantsService
    CostumesService,
    MeasurementTypesService
  ]
})
export class SharedModule { }
