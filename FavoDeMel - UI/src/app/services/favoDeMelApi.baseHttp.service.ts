import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Injector } from '@angular/core';

const options = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
};

export class FavoDeMelApiBaseHttpService {
  private http: HttpClient;
  private readonly apiUrl = environment.favo_de_mel_api_url;

  constructor(injector: Injector, endpointBase: string, ) {
    this.http = injector.get(HttpClient);
    this.apiUrl = `${this.apiUrl}/api/${endpointBase}`
  }

  get(uri?: string, params?: any) {
    console.log(params);
    return this.http.get(`${this.apiUrl}/${uri ?? ''}`, { params });
  }

  post(uri: string, body: any) {
    return this.http.post(`${this.apiUrl}/${uri ?? ''}`, body, options);
  }

  put(uri: string, body: any) {
    return this.http.put(`${this.apiUrl}/${uri ?? ''}`, body);
  }

  delete(uri: string) {
    return this.http.delete(`${this.apiUrl}/${uri ?? ''}`);
  }
}