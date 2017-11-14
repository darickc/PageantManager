import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';

import { ApiService } from './api.service';
import { Pageant, Costume, Performance } from '../models';

@Injectable()
export class PageantsService {

  url = 'pageants';

  constructor(private apiService:  ApiService) { }

  getPageants(): Observable<Pageant[]> {
    return this.apiService.get(this.url)
    .map(data => data.items);
  }

  addPagenat(pageant: Pageant): Observable<Pageant> {
    return this.apiService.post(this.url, pageant);
  }

  updatePagenat(pageant: Pageant): Observable<Pageant> {
    return this.apiService.put(this.url, pageant);
  }

  getPerformances(id: number): Observable<Costume[]> {
    return this.apiService.get(`${this.url}/${id}/performances`)
    .map(data => data.items);
  }

  getCostumes(id: number): Observable<Performance[]> {
    return this.apiService.get(`${this.url}/${id}/costumes`)
    .map(data => data.items);
  }

}
