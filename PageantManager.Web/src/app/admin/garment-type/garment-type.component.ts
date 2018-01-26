import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/finally';
import { FormGroup, FormBuilder, FormControl, FormArray, Validators } from '@angular/forms';
import * as _ from 'lodash';
import { ActivatedRoute, Router } from '@angular/router';
import {MatSnackBar} from '@angular/material';
import { GarmentTypesService, MeasurementTypesService } from '../../shared/services';
import { GarmentType, PickedFile, MeasurementType, MeasurementOption, GarmentMeasurementType } from '../../shared';

@Component({
  templateUrl: './garment-type.component.html',
  styleUrls: ['./garment-type.component.scss']
})
export class GarmentTypeComponent implements OnInit {

  loading: boolean;
  garmentType: GarmentType;
  form: FormGroup;
  measurementOptions: FormArray;
  newGarmentType: boolean;
  measurementTypes: MeasurementType[];

  constructor(
    private garmentTypesService: GarmentTypesService,
    private measurementTypesService: MeasurementTypesService,
    private router: Router,
    private route: ActivatedRoute,
    private _fb: FormBuilder,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.measurementOptions = this._fb.array([]);
    this.form = this._fb.group({
      garmentTypeId: [],
      description: ['', [Validators.maxLength(200)]],
      name: ['', [Validators.required, Validators.maxLength(75)]],
      photo: [],
      garmentMeasurementTypes: this._fb.array([]),
      measurementOptions: this.measurementOptions
    });

    this.loading = true;
    this.measurementTypesService.getMeasurementTypes()
      .finally(() => this.loading = false)
      .subscribe(mt => {
        this.measurementTypes = mt;

        this.subscribeToParams();
      });
  }

  subscribeToParams() {
    this.route.params.subscribe(params => {
      if (params.id === 'new') {
        this.newGarmentType = true;
        this.garmentType = new GarmentType({
          garmentMeasurementTypes: []
        });
        this.form.reset();
        this.updateMeasurementOptions();
      } else {
        this.loading = true;
        this.garmentTypesService.getGarmentType(params.id)
          .finally(() => this.loading = false)
          .subscribe(garmentType => {
            this.setGarmentType(garmentType);
          });
      }
    });
  }

  fileSelected(file: PickedFile) {
    this.form.controls.photo.setValue(file.content);
  }

  submit() {
    if (this.form.invalid || this.loading) {
      return;
    }

    const gt = this.form.value as GarmentType;
    gt.garmentMeasurementTypes = _.slice(this.garmentType.garmentMeasurementTypes, 0, this.garmentType.garmentMeasurementTypes.length);
    for (const mo of gt.measurementOptions) {
      const index = _.findIndex(gt.garmentMeasurementTypes, {measurementTypeId: mo.measurementType.measurementTypeId});
      if (mo.selected) {
        if (index === -1) {
          gt.garmentMeasurementTypes.push(new GarmentMeasurementType({
            measurementTypeId: mo.measurementType.measurementTypeId,
            garmentTypeId: gt.garmentTypeId
          }));
        }
      } else {
        if (index !== -1) {
          gt.garmentMeasurementTypes.splice(index, 1);
        }
      }
    }

    gt.measurementOptions = null;
    // console.log(gt);

    this.garmentTypesService.updateGarmentType(this.form.value)
    .finally(() => this.loading = false)
    .subscribe(garmentType => {
      this.setGarmentType(garmentType);
      this.snackBar.open(`${garmentType.name} saved!`, 'Ok', { duration: 1000 });
    });
  }

  setGarmentType(garmentType: GarmentType) {
    this.garmentType = garmentType;
    this.newGarmentType = false;
    this.form.reset();
    this.form.patchValue(garmentType);
    this.updateMeasurementOptions();
  }

  updateMeasurementOptions() {
    while (this.measurementOptions.controls.length > 0) {
      this.measurementOptions.removeAt(0);
    }

    for (const t of this.measurementTypes) {
      const selected = _.findIndex(this.garmentType.garmentMeasurementTypes, {measurementTypeId: t.measurementTypeId}) > -1;
      const c = this._fb.group({
        selected: [selected],
        measurementType: this._fb.group({
          measurementTypeId: [t.measurementTypeId],
          name: [t.name]
        })
      });
      this.measurementOptions.push(c);
    }
  }

  deletePhoto() {
    this.form.controls.photo.reset();
  }

}
