import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/finally';
import { GarmentTypesService } from '../../shared/services';
import { GarmentType } from '../../shared';

@Component({
  templateUrl: './garment-types.component.html',
  styleUrls: ['./garment-types.component.scss']
})
export class GarmentTypesComponent implements OnInit {

  loading: boolean;
  garmentTypes: GarmentType[];

  constructor(private garmentTypesService: GarmentTypesService) { }

  ngOnInit() {
    this.loading = true;
    this.garmentTypesService.getGarmentTypes()
      .finally(() => this.loading = false)
      .subscribe(gt => {
        this.garmentTypes = gt;
      });
  }

}
