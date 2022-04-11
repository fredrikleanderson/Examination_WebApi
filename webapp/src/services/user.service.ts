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
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  constructor(private http:HttpClient) { }

  createUser(user:CreateUser): Observable<User>{
    return this.http.post<User>(this.apiUrl + 'SignUp', user, this.httpOptions)
  }

  authenticateUser(user:AuthenticateUser): Observable<string>{
    return this.http.post<string>(this.apiUrl + 'SignIn', user, this.httpOptions)
  }
}
