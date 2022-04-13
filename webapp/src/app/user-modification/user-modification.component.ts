import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-user-modification',
  templateUrl: './user-modification.component.html',
  styleUrls: ['./user-modification.component.scss']
})
export class UserModificationComponent implements OnInit {

  user?: User

  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.user = this.userService.loggedInUser
  }

}
