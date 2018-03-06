import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import 'rxjs/add/operator/finally';
import { CostumesService } from '../../shared/services';
import { Costume, Measurement } from '../../shared';

@Component({
  selector: 'app-costumes',
  templateUrl: './costumes.component.html',
  styleUrls: ['./costumes.component.scss']
})
export class CostumesComponent implements OnInit {

  costumes: Costume[];
  loadingCostumes: boolean;
  @Input() measurements: Measurement[];
  @Output() onSelectCostume = new EventEmitter<Costume>();

  constructor(private costumesService: CostumesService) { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes.measurements){
      this.loadCostumes(this.measurements);
    }
  }

  loadCostumes(measurements: Measurement[]){
    if(!measurements || !measurements.length){
      return;
    }
    this.loadingCostumes = true;
    this.costumesService.searchCostumes(measurements)
      .finally(() => {
        this.loadingCostumes = false;
      })
      .subscribe(costumes => {
        this.costumes = costumes;
      });
  }

  selectCostume(costume: Costume){
    this.onSelectCostume.emit(costume);
  }

}
