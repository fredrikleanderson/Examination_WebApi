import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CartItem } from 'src/entities/cart-item';
import { AddCartItem } from 'src/models/add-cart-item';
import { DeleteCartItem } from 'src/models/delete-cart-item';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private apiUrl: string = "https://localhost:7175/api/Carts";

  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}` 
    })
  };

  constructor(private http:HttpClient) { }

  AddToCart(item:AddCartItem): Observable<CartItem>{
    return this.http.post<CartItem>(this.apiUrl, item, this.httpOptions)
  }

  GetCart(id:number): Observable<CartItem[]>{
    return this.http.get<CartItem[]>(this.apiUrl + `/${id}`, this.httpOptions)
  }

  RemoveCartItem(id:number, item:DeleteCartItem):Observable<any>{
    return this.http.put(this.apiUrl + `/${id}`, item, this.httpOptions)
  }
}
