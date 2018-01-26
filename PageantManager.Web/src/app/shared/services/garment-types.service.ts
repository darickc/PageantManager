import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { HttpClient } from '@angular/common/http';

import { GarmentType } from '../models';

@Injectable()
export class GarmentTypesService {

  url = 'api/garment-types';

  constructor(private http: HttpClient) { }

    getGarmentTypes(): Observable<GarmentType[]> {
    return this.http.get<GarmentType[]>(this.url);
  }

  getGarmentType(id: number, loadGarments: boolean = false): Observable<GarmentType> {
    return this.http.get<GarmentType>(`${this.url}/${id}?loadGarments=${loadGarments}`);
  }

  createGarmentType(costume: GarmentType): Observable<GarmentType> {
    return this.http.post<GarmentType>(`${this.url}`, costume);
  }

  updateGarmentType(costume: GarmentType): Observable<GarmentType> {
    return this.http.put<GarmentType>(`${this.url}`, costume);
  }

}
