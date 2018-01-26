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

import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatSnackBarModule} from '@angular/material/snack-bar';

import {
  CostumesService,
  GarmentTypesService,
  MeasurementTypesService,
  GarmentsService
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
    MatProgressSpinnerModule,
    MatSlideToggleModule,
    MatSnackBarModule
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
    MatSlideToggleModule,
    MatSnackBarModule,
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
    MeasurementTypesService,
    GarmentsService
  ]
})
export class SharedModule { }
