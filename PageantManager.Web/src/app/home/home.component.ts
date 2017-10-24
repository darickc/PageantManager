import { Component, OnInit } from '@angular/core';
import { PageantsService } from '../shared';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  pageants: any[];
  constructor(private pageantsService: PageantsService) { }

  ngOnInit() {
    this.pageantsService.getPageants().subscribe(p => {
      this.pageants = p;
    });
  }

}
