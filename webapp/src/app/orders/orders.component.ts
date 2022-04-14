import { Component, OnInit } from '@angular/core';
import { User } from 'src/entities/user';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  user?: User

  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.userService.refreshUser()
    this.user = this.userService.loggedInUser
  }

}
