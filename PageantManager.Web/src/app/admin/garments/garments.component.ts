import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/finally';
import { FormGroup, FormBuilder, FormControl, FormArray, Validators } from '@angular/forms';
import * as _ from 'lodash';
import { ActivatedRoute, Router } from '@angular/router';
import {MatSnackBar} from '@angular/material';
import { GarmentTypesService, MeasurementTypesService } from '../../shared/services';
import { GarmentType, PickedFile, MeasurementType, MeasurementOption, GarmentMeasurementType } from '../../shared';

@Component({
  selector: 'app-garments',
  templateUrl: './garments.component.html',
  styleUrls: ['./garments.component.scss']
})
export class GarmentsComponent implements OnInit {

  loading: boolean;
  garmentType: GarmentType;
  form: FormGroup;
  measurementOptions: FormArray;

  constructor(
    private garmentTypesService: GarmentTypesService,
    private router: Router,
    private route: ActivatedRoute,
    private _fb: FormBuilder,
    private snackBar: MatSnackBar) { }

  ngOnInit() {
    const id = this.route.snapshot.params.id;
    this.loading = true;
    this.garmentTypesService.getGarmentType(id, true)
          .finally(() => this.loading = false)
          .subscribe(garmentType => {
            this.garmentType = garmentType;
          });
  }

}
