import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { HttpClient } from '@angular/common/http';

import { GarmentType, ItemsModel } from '../models';

@Injectable()
export class GarmentTypesService {

  url = 'api/garment-types';

  constructor(private http: HttpClient) { }

  //   getGarmentTypes(): Observable<GarmentType[]> {
  //   return this.http.get<GarmentType[]>(this.url);
  // }

  getGarmentTypes(search: string, page: number, pageCount: number): Observable<ItemsModel<GarmentType>> {
    const params = <any>{
      page: page,
      pageCount: pageCount
    };
    if (search) {
      params.search = search;
    }
  return this.http.get<ItemsModel<GarmentType>>(this.url, {params});
}

  getGarmentType(id: number, loadGarments: boolean = false): Observable<GarmentType> {
    return this.http.get<GarmentType>(`${this.url}/${id}?includeGarments=${loadGarments}`);
  }

  createGarmentType(costume: GarmentType): Observable<GarmentType> {
    return this.http.post<GarmentType>(`${this.url}`, costume);
  }

  updateGarmentType(costume: GarmentType): Observable<GarmentType> {
    return this.http.put<GarmentType>(`${this.url}`, costume);
  }

}
