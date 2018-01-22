import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { HttpClient } from '@angular/common/http';

import { Costume, Measurement } from '../models';

@Injectable()
export class CostumesService {

  url = 'api/costumes';

  constructor(private http: HttpClient) { }

    getCostumes(): Observable<Costume[]> {
    return this.http.get<Costume[]>(this.url);
  }

  searchCostumes(measurements: Measurement[]): Observable<Costume[]> {
    return this.http.post<Costume[]>(`${this.url}/search`, measurements);
  }

  createCostume(costume: Costume): Observable<Costume> {
    return this.http.post<Costume>(`${this.url}`, costume);
  }

  updateCostume(costume: Costume): Observable<Costume> {
    return this.http.put<Costume>(`${this.url}`, costume);
  }
}
