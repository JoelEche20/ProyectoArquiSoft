import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Order } from '../Models/Order';
import { Observable } from 'rxjs';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      })
  };

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  ordersUrl:string = 'http://localhost:51365/api/orders';
  constructor(private http: HttpClient) { }

  get(url: string) {
    return this.http.get(url);
  }

  addOrder(order:Order):Observable<Order> {
    const url =this.ordersUrl;
    let body = JSON.stringify({ 
      "Price":Number(order.price),
      "Phone":order.phone,
      "Address":order.address,
      "idUser":order.idUser,
      "idBook":order.idBook
    });
    console.log(body);
    return this.http.post<Order>(url, body, httpOptions);
  }
}