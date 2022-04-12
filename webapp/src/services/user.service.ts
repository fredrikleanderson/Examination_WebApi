import { Injectable } from '@angular/core';
import { CreateUser } from 'src/models/create-user';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/entities/user';
import { AuthenticateUser } from 'src/models/authenticate-user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl: string = "https://localhost:7175/api/User/";
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`
    })
  };

  constructor(private http:HttpClient) { }

  createUser(user:CreateUser): Observable<User>{
    return this.http.post<User>(this.apiUrl + 'SignUp', user, this.httpOptions)
  }

  login(user:AuthenticateUser): Observable<any>{
    return this.http.post(this.apiUrl + 'SignIn', user, {responseType: 'text'})
  }

  currentUser(): Observable<any>{
    return this.http.get(this.apiUrl + 'CurrentUser', this.httpOptions)
  }
}