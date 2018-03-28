import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { CostumesService } from '../../shared/services';
import { Costume, Measurement } from '../../shared';

@Component({
  selector: 'app-garments',
  templateUrl: './garments.component.html',
  styleUrls: ['./garments.component.scss']
})
export class GarmentsComponent implements OnInit {

  loading: boolean;
  @Input() measurements: Measurement[];
  @Input() costumeId: number;
  costume: Costume;

  constructor(private costumesService: CostumesService) { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes.costumeId){
      this.loadCostume(changes.costumeId.currentValue);
    }
  }

  loadCostume(id: number){
    if(!id)
      return;
    this.loading = true;
    this.costumesService.searchCostumeGarments(id, this.measurements)
      .finally(()=>{
        this.loading = false;
      })
      .subscribe((costume)=>{
        this.costume = costume;
      });
  }

}
