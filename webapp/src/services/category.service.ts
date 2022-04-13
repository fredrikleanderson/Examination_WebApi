import { Injectable } from '@angular/core';
import { Category } from 'src/entities/category';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UpdateCategory } from 'src/models/update-category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = "https://localhost:7175/api/Categories"
  
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}` 
    })
  };

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  updateCategory(id: number, model:UpdateCategory): Observable<UpdateCategory>{
    return this.http.put<UpdateCategory>(this.apiUrl + `/${id}`, model, this.httpOptions)
  }
}