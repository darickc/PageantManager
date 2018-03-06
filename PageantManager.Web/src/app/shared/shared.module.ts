import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import {
  MatButtonModule,
  MatCheckboxModule,
  MatInputModule,
  MatProgressSpinnerModule,
  MatMenuModule,
  MatProgressBarModule,
  MatCardModule,
  MatSnackBarModule,
  MatSlideToggleModule,
  MatSidenavModule,
  MatToolbarModule,
  MatListModule,
  MatIconModule,
  MatPaginatorModule,
  MatDividerModule,
  MatStepperModule
} from '@angular/material';

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
    MatSnackBarModule,
    MatCardModule,
    MatProgressBarModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatIconModule,
    MatPaginatorModule,
    MatDividerModule,
    MatStepperModule
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
    MatCardModule,
    MatProgressBarModule,
    LoadingComponent,
    FilePickerDirective,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatIconModule,
    MatPaginatorModule,
    MatDividerModule,
    MatStepperModule
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
