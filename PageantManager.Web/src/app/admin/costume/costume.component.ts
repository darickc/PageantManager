import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/finally';
import { FormGroup, FormBuilder, FormControl, FormArray, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CostumesService } from '../../shared/services';
import { Costume, PickedFile } from '../../shared';

@Component({
  templateUrl: './costume.component.html',
  styleUrls: ['./costume.component.scss']
})
export class CostumeComponent implements OnInit {

  loading: boolean;
  costume: Costume;
  form: FormGroup;
  newCostume: boolean;

  constructor(
    private costumesService: CostumesService,
    private router: Router,
    private route: ActivatedRoute,
    private _fb: FormBuilder) { }

  ngOnInit() {

    this.form = this._fb.group({
      costumeId: [],
      description: ['', [Validators.maxLength(150)]],
      name: ['', [Validators.required, Validators.maxLength(50)]],
      photo: []
    });

    this.route.params.subscribe(params => {
      if (params.id === 'new') {
        this.newCostume = true;
        this.form.reset();
      } else {
        this.loading = true;
        this.costumesService.getCostume(params.id)
          .finally(() => this.loading = false)
          .subscribe(costume => {
            this.setCostume(costume);
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

    this.costumesService.updateCostume(this.form.value)
    .finally(() => this.loading = false)
    .subscribe(costume => {
      this.setCostume(costume);
    });
  }

  setCostume(costume: Costume) {
    this.newCostume = false;
    this.form.reset();
    this.form.patchValue(costume);
  }
}
