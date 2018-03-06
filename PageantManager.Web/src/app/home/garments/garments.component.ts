import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
import { Costume } from '../../shared';

@Component({
  selector: 'app-garments',
  templateUrl: './garments.component.html',
  styleUrls: ['./garments.component.scss']
})
export class GarmentsComponent implements OnInit {

  @Input() costume: Costume;

  constructor() { }

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if(changes.costume){

    }
  }

  loadCostume(){

  }

}
