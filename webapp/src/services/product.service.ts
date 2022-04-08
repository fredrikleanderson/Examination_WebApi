import { Injectable } from '@angular/core';
import { Product } from 'src/entities/product';
import { CreateProduct } from 'src/models/create-product';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiUrl: string = "https://localhost:7175/api/Products";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(this.apiUrl);
  }

  createProduct(product: CreateProduct): Observable<Product>{
    return this.http.post<Product>(this.apiUrl, product, this.httpOptions)
  }
}