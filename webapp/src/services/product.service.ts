import { Injectable } from '@angular/core';
import { Product } from 'src/entities/product';
import { CreateProduct } from 'src/models/create-product';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UpdateProduct } from 'src/models/update-product';

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

  updateProduct(id: Number, product: UpdateProduct): Observable<any>{
    return this.http.put(this.apiUrl + `/${id}`, product, this.httpOptions)
  }

  deleteProduct(id: Number): Observable<any>{
    return this.http.delete(this.apiUrl + `/${id}`, this.httpOptions)
  }
}