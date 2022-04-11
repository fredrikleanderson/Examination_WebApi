import { Component, OnInit } from '@angular/core';
import { AuthenticateUser } from 'src/models/authenticate-user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-authentication',
  templateUrl: './user-authentication.component.html',
  styleUrls: ['./user-authentication.component.scss']
})
export class UserAuthenticationComponent implements OnInit {

  model:AuthenticateUser

  constructor(private userService:UserService) {
    this.model = new AuthenticateUser()
   }

  ngOnInit(): void {
  }

  AuthenticateUser(): void{
    this.userService.authenticateUser(this.model).subscribe(response =>{
      console.log(response)
    })
  }

}
