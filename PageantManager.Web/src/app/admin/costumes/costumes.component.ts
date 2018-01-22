import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/finally';
import { CostumesService } from '../../shared/services';
import { Costume } from '../../shared';

@Component({
  templateUrl: './costumes.component.html',
  styleUrls: ['./costumes.component.scss']
})
export class CostumesComponent implements OnInit {

  loading: boolean;
  costumes: Costume[];

  constructor(private costumesService: CostumesService) { }

  ngOnInit() {
    this.loading = true;
    this.costumesService.getCostumes()
      .finally(() => this.loading = false)
      .subscribe(costumes => {
        this.costumes = costumes;
      });
  }

}
