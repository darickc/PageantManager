import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-loading',
  template: `<mat-progress-spinner mode="indeterminate" [diameter]='diameter'></mat-progress-spinner>`,
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent implements OnInit {

  @Input() size: string;
  diameter: number;

  constructor() { }

  ngOnInit() {
    switch (this.size) {
      case 'xsm':
        this.diameter = 16;
        break;
      case 'sm':
        this.diameter = 22;
        break;
      default:
      this.diameter = 35;
        break;
    }

  }

}
