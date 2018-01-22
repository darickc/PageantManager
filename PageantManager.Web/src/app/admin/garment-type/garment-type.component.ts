import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/finally';
import { FormGroup, FormBuilder, FormControl, FormArray, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GarmentTypesService } from '../../shared/services';
import { GarmentType, PickedFile } from '../../shared';

@Component({
  templateUrl: './garment-type.component.html',
  styleUrls: ['./garment-type.component.scss']
})
export class GarmentTypeComponent implements OnInit {

  loading: boolean;
  garmentType: GarmentType;
  form: FormGroup;
  newGarmentType: boolean;

  constructor(
    private garmentTypesService: GarmentTypesService,
    private router: Router,
    private route: ActivatedRoute,
    private _fb: FormBuilder) { }

  ngOnInit() {

    this.form = this._fb.group({
      garmentTypeId: [],
      description: ['', [Validators.maxLength(200)]],
      name: ['', [Validators.required, Validators.maxLength(75)]],
      photo: []
    });

    this.route.params.subscribe(params => {
      if (params.id === 'new') {
        this.newGarmentType = true;
        this.form.reset();
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

    this.garmentTypesService.updateGarmentType(this.form.value)
    .finally(() => this.loading = false)
    .subscribe(garmentType => {
      this.setGarmentType(garmentType);
    });
  }

  setGarmentType(garmentType: GarmentType) {
    this.newGarmentType = false;
    this.form.reset();
    this.form.patchValue(garmentType);
  }

}
