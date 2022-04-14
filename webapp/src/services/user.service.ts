import { Injectable } from '@angular/core';
import { CreateUser } from 'src/models/create-user';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/entities/user';
import { AuthenticateUser } from 'src/models/authenticate-user';
import { UpdateUser } from 'src/models/update-user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl: string = "https://localhost:7175/api/Users/";
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`
    })
  };

  loggedInUser?: User

  constructor(private http:HttpClient) {
    if(localStorage.getItem("token")){
      this.refreshUser();
    }
   }

  createUser(user:CreateUser): Observable<User>{
    return this.http.post<User>(this.apiUrl + 'SignUp', user, this.httpOptions)
  }

  login(user:AuthenticateUser): Observable<any>{
    return this.http.post(this.apiUrl + 'SignIn', user, {responseType: 'text'})
  }

  currentUser(): Observable<User>{
    return this.http.get(this.apiUrl, this.httpOptions)
  }

  deleteUser(id:number): Observable<any>{
    return this.http.delete(this.apiUrl + `${id}`, this.httpOptions)
  }

  updateUser(id:number, user:UpdateUser): Observable<any>{
    return this.http.put<UpdateUser>(this.apiUrl + `${id}`, user, this.httpOptions)
  }

  refreshUser(): void{
    this.currentUser().subscribe(response =>{
      this.loggedInUser = response
    })
  }
}