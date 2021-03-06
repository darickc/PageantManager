import { Component, OnInit } from '@angular/core';
import {Location} from '@angular/common';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/finally';
import * as _ from 'lodash';
import { FormGroup, FormBuilder, FormControl, FormArray, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CostumesService, GarmentTypesService, ItemsModel, Costume, PickedFile, GarmentType, CostumeGarment} from '../../shared';

@Component({
  templateUrl: './costume.component.html',
  styleUrls: ['./costume.component.scss']
})
export class CostumeComponent implements OnInit {

  loading: boolean;
  loadingGarmentType: boolean;
  costume: Costume;
  garmentTypes: ItemsModel<GarmentType>;
  costumeGarments: CostumeGarment[];
  form: FormGroup;
  newCostume: boolean;
  pageSize: number;
  pageSizeOptions = [10, 25, 50];
  page = 0;

  constructor(
    private costumesService: CostumesService,
    private garmentTypesService: GarmentTypesService,
    private router: Router,
    private route: ActivatedRoute,
    private _fb: FormBuilder,
    private _location: Location) { }

  ngOnInit() {
    this.pageSize = this.pageSizeOptions[0];
    this.form = this._fb.group({
      costumeId: [],
      description: ['', [Validators.maxLength(150)]],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      photo: [],
      search: []
    });

    this.form.controls.search.valueChanges.debounceTime(500).subscribe(search => {
      if (search) {
        this.page = 0;
        this.getGarmentTypes();
      } else {
        this.garmentTypes = null;
      }
    });

    const id = this.route.snapshot.params.id;

    if (id === 'new') {
      this.newCostume = true;
      this.costumeGarments = [];
      this.form.reset();
    } else {
      this.loading = true;
      this.costumesService.getCostume(id)
        .finally(() => this.loading = false)
        .subscribe(costume => {
          this.setCostume(costume);
        });
    }
  }

  pageChanged(event) {
    this.page = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getGarmentTypes();
  }

  getGarmentTypes() {
    this.loadingGarmentType = true;
    this.garmentTypesService.getGarmentTypes(this.form.controls.search.value, this.page, this.pageSize)
      .finally(() => this.loadingGarmentType = false)
      .subscribe(items => {
        this.garmentTypes = items;
      });
  }

  fileSelected(file: PickedFile) {
    this.form.controls.photo.setValue(file.content);
  }

  submit() {
    if (this.form.invalid || this.loading) {
      return;
    }

    const c = this.form.value as Costume;
    c.costumeGarments = this.costumeGarments;
    this.costumesService.updateCostume(c)
    .finally(() => this.loading = false)
    .subscribe(costume => {
      this.setCostume(costume);
    });
  }

  setCostume(costume: Costume) {
    this.newCostume = false;
    this.costumeGarments = costume.costumeGarments ? costume.costumeGarments : [];
    this.form.reset();
    this.form.patchValue(costume);
  }

  deletePhoto() {
    this.form.controls.photo.setValue('');
  }

  back() {
    this._location.back();
  }

  addGarmentType(garmentType: GarmentType) {
    if (_.findIndex(this.costumeGarments, { garmentTypeId: garmentType.garmentTypeId }) > -1) {
      return;
    }

    this.costumeGarments.push(new CostumeGarment({
      garmentType: garmentType,
      garmentTypeId: garmentType.garmentTypeId
    }));
  }

  removeCostumeGarment(index: number) {
    this.costumeGarments.splice(index, 1);
  }
}
