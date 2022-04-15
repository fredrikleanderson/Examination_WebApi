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
    this.user = this.userService.loggedInUser
   }

  ngOnInit(): void {
    if(localStorage.getItem("token")){
      this.getCurrentUser()
    }
  }

   async LogIn(): Promise<void>{
    this.userService.login(this.model).subscribe(response => {
      localStorage.setItem('token', response)
    })
    await new Promise(x => setTimeout(x, 1000))
    if(localStorage.getItem("token")){
      await this.userService.refreshUser();
      this.user = this.userService.loggedInUser
    }
    this.model = new AuthenticateUser();
  }

   LogOut():void{
    localStorage.removeItem("token");
    this.user = null!
    this.userService.loggedInUser = null!
  }

  getCurrentUser(){
    if(localStorage.getItem("token")){
      this.userService.currentUser().subscribe(response =>{
        this.user = response
      })
    }
  }
}

