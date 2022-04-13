import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {

  user?: User

  constructor(private userService:UserService) {
    this.user = this.userService.loggedInUser
   }

  ngOnInit(): void {
    if(localStorage.getItem("token")){
      this.userService.currentUser().subscribe(response => {
        this.user = response
      })
    }

  }

}
