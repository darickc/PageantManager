import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import 'rxjs/add/operator/finally';
import { Measurement, Costume } from '../shared';
import {CostumesComponent} from './costumes/costumes.component';
import { MatHorizontalStepper } from '@angular/material/stepper';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  @ViewChild(MatHorizontalStepper)
  private stepper: MatHorizontalStepper;
  measurementsForm: FormGroup;
  measurements: Measurement[]

  constructor(
    private _fb: FormBuilder) { }

  ngOnInit() {

      this.measurementsForm = this._fb.group({
      });

  }

  onSearch(measurements: Measurement[]){
    this.measurements = measurements;
  }

  onSelectCostume(costume: Costume){
    this.stepper.next();
  }

}
