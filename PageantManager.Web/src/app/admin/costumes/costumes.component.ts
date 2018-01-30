import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/finally';
import { FormGroup, FormBuilder, FormControl,  } from '@angular/forms';
import { CostumesService } from '../../shared/services';
import { Costume, ItemsModel } from '../../shared';
import * as _ from 'lodash';

@Component({
  templateUrl: './costumes.component.html',
  styleUrls: ['./costumes.component.scss']
})
export class CostumesComponent implements OnInit {

  loading: boolean;
  costumes: ItemsModel<Costume>;
  form: FormGroup;
  pageSize: number;
  pageSizeOptions = [10, 25, 50];
  page = 0;

  constructor(
    private costumesService: CostumesService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.pageSize = this.pageSizeOptions[1];
    this.form = this.fb.group({
      search: []
    });

    this.form.controls.search.valueChanges.debounceTime(500).subscribe(search => {
      this.page = 0;
      this.getCostumes();
    });

    this.route.queryParams.subscribe(p => {
      this.form.controls.search.setValue(p.search);

      this.loading = true;
      this.costumesService.getCostumes(p.search, this.page + 1, this.pageSize)
        .finally(() => this.loading = false)
        .subscribe(costumes => {
          this.costumes = costumes;
        });
    });
  }

  getCostumes() {
    const params = <any>{
      page: this.page,
      pageCount: this.pageSize
    };
    if (this.form.controls.search.value) {
      params.search = this.form.controls.search.value;
    }

    this.router.navigate(['/admin/costumes'], { queryParams: params });
  }

  pageChanged(event) {
    this.page = event.pageIndex;
    this.pageSize = event.pageSize;
    this.getCostumes();
  }


}
