import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from 'src/entities/order';
import { CreateOrderItem } from 'src/models/create-order-item';
import { PlaceOrder } from 'src/models/place-order';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private apiUrl: string = "https://localhost:7175/api/Orders";

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}` 
    })
  };

  constructor(private http:HttpClient) { }

  placeOrder(order:PlaceOrder): Observable<Order>{
    return this.http.post<Order>(this.apiUrl, order, this.httpOptions)
  }

  addToOrder(orderItem:CreateOrderItem): Observable<any>{
    return this.http.put(this.apiUrl, orderItem, this.httpOptions)
  }

  getOrders(): Observable<Order[]>{
    return this.http.get<Order[]>(this.apiUrl, this.httpOptions)
  }

  shipOrder(id:number): Observable<any>{
    return this.http.put(this.apiUrl + `/${id}`, null, this.httpOptions)
  }

  fileOrder(id:number): Observable<any>{
    return this.http.delete(this.apiUrl + `/${id}`, this.httpOptions)
  }
}
