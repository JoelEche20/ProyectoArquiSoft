import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      })
  };

@Injectable({
  providedIn: 'root'
})

export class HttpService {


  constructor(private http: HttpClient) { }

  get(url: string) {
    return this.http.get(url);
  }
}