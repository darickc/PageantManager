import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { HttpClient, HttpParams } from '@angular/common/http';

import { Costume, ItemsModel, Measurement } from '../models';

@Injectable()
export class CostumesService {

  url = 'api/costumes';

  constructor(private http: HttpClient) { }

    getCostumes(search: string, page: number, pageCount: number): Observable<ItemsModel<Costume>> {
      const params = <any>{
        page: page,
        pageCount: pageCount
      };
      if (search) {
        params.search = search;
      }
    return this.http.get<ItemsModel<Costume>>(this.url, {params});
  }

  getCostume(id: number): Observable<Costume> {
    return this.http.get<Costume>(`${this.url}/${id}`);
  }

  searchCostumes(measurements: Measurement[]): Observable<Costume[]> {
    return this.http.post<Costume[]>(`${this.url}/search`, measurements);
  }

  searchCostumeGarments(id: number, measurements: Measurement[]): Observable<Costume> {
    return this.http.post<Costume>(`${this.url}/search/${id}`, measurements);
  }

  createCostume(costume: Costume): Observable<Costume> {
    return this.http.post<Costume>(`${this.url}`, costume);
  }

  updateCostume(costume: Costume): Observable<Costume> {
    return this.http.put<Costume>(`${this.url}`, costume);
  }
}
