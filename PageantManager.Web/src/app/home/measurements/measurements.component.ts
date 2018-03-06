import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, FormArray, Validators } from '@angular/forms';
import 'rxjs/add/operator/finally';
import { MeasurementTypesService } from '../../shared/services';
import { MeasurementType, Measurement } from '../../shared';

@Component({
  selector: 'app-measurements',
  templateUrl: './measurements.component.html',
  styleUrls: ['./measurements.component.scss']
})
export class MeasurementsComponent implements OnInit {

  measurementTypes: MeasurementType[];
  loading: boolean;
  loadingCostumes: boolean;
  @Input() measurementsForm: FormGroup;
  @Output() onSearch = new EventEmitter<Measurement[]>();
  formArray: FormArray;

  constructor(
    private measurementTypesService: MeasurementTypesService,
    private _fb: FormBuilder) { }

  ngOnInit() {
    this.loading = true;
    this.measurementTypesService.getMeasurementTypes().finally(() => {
      this.loading = false;
    }).subscribe(p => {
      this.formArray = this._fb.array([]);
      this.measurementsForm.addControl("measurements", this.formArray);
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
    if (this.measurementsForm.invalid) {
      return;
    }
    this.onSearch.emit(this.formArray.value);
    // if (this.measurementsForm.invalid) {
    //   return;
    // }
    // this.loadingCostumes = true;
    // this.costumesService.searchCostumes(this.formArray.value)
    //   .finally(() => {
    //     this.loading = false;
    //   })
    //   .subscribe(costumes => {
    //     this.costumes = costumes;
    //   });
  }

}
