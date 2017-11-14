import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { HttpClient } from '@angular/common/http';

// import { ApiService } from './api.service';
import { Pageant, Costume, Performance } from '../models';

@Injectable()
export class PageantsService {

  url = 'api/pageants';

  constructor(private http: HttpClient) { }

  getPageants(): Observable<Pageant[]> {
    return this.http.get(this.url)
    .map(data => data['items']);
  }

  addPagenat(pageant: Pageant): Observable<Pageant> {
    return this.http.post<Pageant>(this.url, pageant);
  }

  updatePagenat(pageant: Pageant): Observable<Pageant> {
    return this.http.put<Pageant>(this.url, pageant);
  }

  getPerformances(id: number): Observable<Costume[]> {
    return this.http.get(`${this.url}/${id}/performances`)
    .map(data => data['items']);
  }

  getCostumes(id: number): Observable<Performance[]> {
    return this.http.get(`${this.url}/${id}/costumes`)
    .map(data => data['items']);
  }

}
