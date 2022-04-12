import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { AuthenticateUser } from 'src/models/authenticate-user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-authentication',
  templateUrl: './user-authentication.component.html',
  styleUrls: ['./user-authentication.component.scss']
})
export class UserAuthenticationComponent implements OnInit {

  private apiUrl: string = "https://localhost:7175/api/User/";
  model:AuthenticateUser
  user?: User

  constructor(private userService:UserService) {
    this.model = new AuthenticateUser()
   }

  ngOnInit(): void {
    this.getCurrentUser()
  }

   async LogIn(): Promise<void>{
    this.userService.login(this.model).subscribe(response => {
      localStorage.setItem('token', response)
    })
    this.model = new AuthenticateUser();
    await this.getCurrentUser();
  }

  async LogOut():Promise<void>{
    localStorage.removeItem("token");
    await this.getCurrentUser();
  }

  async getCurrentUser(){
    await fetch(this.apiUrl + "CurrentUser", {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      }
    })
    .then(response => response.json())
    .then(data => {
      this.user = data;
    })
  }
}
