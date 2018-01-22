import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { HttpClient } from '@angular/common/http';

import { MeasurementType } from '../models';

@Injectable()
export class MeasurementTypesService {

  url = 'api/meaurement_types';

  constructor(private http: HttpClient) { }

    getMeasurementTypes(): Observable<MeasurementType[]> {
    return this.http.get<MeasurementType[]>(this.url);
  }

  createMeasurementType(mt: MeasurementType): Observable<MeasurementType> {
    return this.http.post<MeasurementType>(`${this.url}`, mt);
  }

  updateMeasurementType(mt: MeasurementType): Observable<MeasurementType> {
    return this.http.put<MeasurementType>(`${this.url}`, mt);
  }

}
