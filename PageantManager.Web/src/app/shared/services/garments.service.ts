import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { HttpClient } from '@angular/common/http';

import { Garment } from '../models';

@Injectable()
export class GarmentsService {

  url = 'api/garments';

  constructor(private http: HttpClient) { }

    getGarments(): Observable<Garment[]> {
    return this.http.get<Garment[]>(this.url);
  }

  getGarment(id: number): Observable<Garment> {
    return this.http.get<Garment>(`${this.url}/${id}`);
  }

  createGarment(costume: Garment): Observable<Garment> {
    return this.http.post<Garment>(`${this.url}`, costume);
  }

  updateGarment(costume: Garment): Observable<Garment> {
    return this.http.put<Garment>(`${this.url}`, costume);
  }

}
