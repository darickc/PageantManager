import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, FormArray, Validators } from '@angular/forms';
import { Garment, GarmentType, GarmentsService, GarmentMeasurement, PickedFile } from '../../shared';

@Component({
  selector: 'app-garment',
  templateUrl: './garment.component.html',
  styleUrls: ['./garment.component.scss']
})
export class GarmentComponent implements OnInit {

  @Input() garment: Garment;
  @Input() garmentType: GarmentType;
  form: FormGroup;
  editing: boolean;

  constructor(private garmentsService: GarmentsService, private fb: FormBuilder) { }

  ngOnInit() {
    this.form = this.fb.group({
      garmentId: [],
      garmentTypeId: [],
      addedDate: [],
      retiredDate: [],
      checkedOut: [],
      photo: [],
      garmentMeasurements: this.fb.array([])
    });
  }

  getGarmentMeasurementForm() {
    return this.fb.group({
      garmentMeasurementId: [],
      garmentId: [],
      measurementTypeId: [],
      measurementType: this.fb.group({
        name: []
      }),
      min: ['', [Validators.required]],
      max: ['', [Validators.required]]
    });
  }

  resetForm() {
    const formArray = this.form.controls.garmentMeasurements as FormArray;
    while (formArray.controls.length) {
      formArray.removeAt(0);
    }

    this.form.reset();

    if (this.garmentType) {
      this.form.controls.garmentTypeId.setValue(this.garmentType.garmentTypeId);
       for (const gmt of this.garmentType.garmentMeasurementTypes) {
        const gmForm = this.getGarmentMeasurementForm();
        const gm = {
          measurementTypeId: gmt.measurementTypeId,
          measurementType: gmt.measurementType
        };
        gmForm.patchValue(gm);
        formArray.push(gmForm);
       }
    } else {
      for (const gm of this.garment.garmentMeasurements) {
        const gmForm = this.getGarmentMeasurementForm();
        gmForm.patchValue(gm);
        formArray.push(gmForm);
      }
    }
  }

  fileSelected(file: PickedFile) {
    this.form.controls.photo.setValue(file.content);
  }

  deletePhoto() {
    this.form.controls.photo.reset();
  }

  save() {

  }

  edit() {
    this.resetForm();
    this.editing = true;
  }

  cancel() {
    this.editing = false;
  }

}
