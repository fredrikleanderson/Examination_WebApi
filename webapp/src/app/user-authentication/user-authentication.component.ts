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

  model:AuthenticateUser
  user?: User

  constructor(private userService:UserService) {
    this.model = new AuthenticateUser()
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
      await new Promise(x => setTimeout(x, 1000))
      this.getCurrentUser()
    }
    this.model = new AuthenticateUser();
  }

   LogOut():void{
    localStorage.removeItem("token");
    this.user = null!
  }

  getCurrentUser(){
    this.userService.currentUser().subscribe(response =>{
      this.user = response
    })
  }


  //   fetch(this.apiUrl + "CurrentUser", {
  //     headers: {
  //       'Content-Type': 'application/json',
  //       'Authorization': `Bearer ${localStorage.getItem('token')}`
  //     }
  //   })
  //   .then(response => response.json())
  //   .then(data => {
  //     this.user = data;
  //     console.log(this.user)
  //   })
  // }
}
