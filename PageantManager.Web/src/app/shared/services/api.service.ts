import { Injectable } from '@angular/core';
import { Headers, Http, Response, URLSearchParams, RequestOptionsArgs, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/mergeMap';


@Injectable()
export class ApiService {
  constructor(
    private http: Http
  ) {

  }

  private getHeaders(): Headers {
    const headersConfig = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    };

    return new Headers(headersConfig);
  }

  private request(path: string, method: RequestMethod, body: any | null, params: URLSearchParams | null): Observable<any> {
    const options = {
      headers: this.getHeaders(),
      method: method,
      params: params,
      body: body
    };
    return this.http.request(`api/${path}`, options)
      // .catch(error => {
      //   if (error && error.status === 401 && this.configService.hasToken()) {
      //     return this.refreshAuthToken()
      //       .catch(authError => {
      //         this.login();
      //         return Observable.throw(error);
      //       })
      //       .mergeMap(refresh => {
      //       if (refresh.refreshToken) {
      //         config.authToken = refresh.token;
      //         config.refreshToken = refresh.refreshToken;
      //         this.configService.setConfig(config);
      //         options.headers = this.getHeaders();
      //         return this.http.request(`${config.apiUrl}${path}`, options)
      //           .catch(newError => {
      //             this.login();
      //             return Observable.throw(error);
      //           });
      //       }
      //       this.login();
      //       return Observable.throw(error);
      //     });
      //   }
      //   return Observable.throw(error);
      // })
      .map((res: Response) => res.text() ? res.json() : {});
  }

  get(path: string, params: URLSearchParams = new URLSearchParams()): Observable<any> {
    return this.request(path, RequestMethod.Get, null, params);
  }

  put(path: string, body: Object = {}): Observable<any> {
    return this.request(path, RequestMethod.Put, body, null);
  }

  post(path: string, body: Object = {}): Observable<any> {
    return this.request(path, RequestMethod.Post, body, null);
  }

  delete(path): Observable<any> {
    return this.request(path, RequestMethod.Delete, null, null);
  }

}
