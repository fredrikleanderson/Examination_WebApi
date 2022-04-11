import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { CreateUser } from 'src/models/create-user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent implements OnInit {

  model:CreateUser
  user?:User

  constructor(private userService:UserService) { 
    this.model = new CreateUser();
  }

  ngOnInit(): void {
  }

  CreateUser(): void{
    this.userService.createUser(this.model).subscribe(response =>{
      this.user = response
    })
    this.model = new CreateUser();
  }

}
