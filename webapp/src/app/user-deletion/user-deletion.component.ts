import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-deletion',
  templateUrl: './user-deletion.component.html',
  styleUrls: ['./user-deletion.component.scss']
})
export class UserDeletionComponent implements OnInit {

  user?: User

  constructor(private userService:UserService) { }

  ngOnInit(): void {
    if(localStorage.getItem("token")){
      this.user = this.userService.loggedInUser
    }
  }

  DeleteUser():void {
    if(this.user?.id){
      this.userService.deleteUser(this.user.id).subscribe(response =>{
        console.log(response)
      })
    }
  }
}
