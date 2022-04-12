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
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImxlYW5kZXJzb24uZnJlZHJpa0BnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJsZWFuZGVyc29uLmZyZWRyaWtAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZ2l2ZW5uYW1lIjoiRnJlZHJpayIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJMZWFuZGVyc29uIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2NDk4NDM1MDMsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjcxNzUvIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzE3NS8ifQ.NuloGuhiOujGjIcz9Idfo2kNe-vsqJJCw9TFE7uQsZg' })
  };

  constructor(private http:HttpClient) { }

  createUser(user:CreateUser): Observable<User>{
    return this.http.post<User>(this.apiUrl + 'SignUp', user, this.httpOptions)
  }

  login(user:AuthenticateUser): Observable<any>{
    return this.http.post(this.apiUrl + 'SignIn', user, {responseType: 'text'})
  }

}