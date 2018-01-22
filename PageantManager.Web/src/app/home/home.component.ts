import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, FormArray, Validators } from '@angular/forms';
import 'rxjs/add/operator/finally';
import { MeasurementTypesService, CostumesService } from '../shared/services';
import { MeasurementType, Measurement, Costume } from '../shared';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  measurementTypes: MeasurementType[];
  loading: boolean;
  loadingCostumes: boolean;
  form: FormGroup;
  formArray: FormArray;
  costumes: Costume[];

  constructor(
    private measurementTypesService: MeasurementTypesService,
    private costumesService: CostumesService,
    private _fb: FormBuilder) { }

  ngOnInit() {
    this.loading = true;
    this.measurementTypesService.getMeasurementTypes().finally(() => {
      this.loading = false;
    }).subscribe(p => {
      this.formArray = this._fb.array([]);
      this.form = this._fb.group({
        measurements: this.formArray
      });
      this.measurementTypes = p;
      for (const mt of p) {
        const group = this._fb.group({
          value: ['', [<any>Validators.required]],
          measurementType: this._fb.group({
            measurementTypeId: [mt.measurementTypeId],
            name: [mt.name]
          })
        });
        this.formArray.push(group);
      }
    });
  }

  submit() {
    if (this.form.invalid) {
      return;
    }
    this.loadingCostumes = true;
    this.costumesService.searchCostumes(this.formArray.value)
      .finally(() => {
        this.loading = false;
      })
      .subscribe(costumes => {
        this.costumes = costumes;
      });
  }
}
