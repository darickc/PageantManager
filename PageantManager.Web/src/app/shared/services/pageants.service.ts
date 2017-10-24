import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';

import { ApiService } from './api.service';

@Injectable()
export class PageantsService {

  url = 'pageants';

  constructor(private apiService:  ApiService) { }

  getPageants(): Observable<any> {
    return this.apiService.get(this.url);
  }

}
