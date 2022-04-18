import { Component, OnInit } from '@angular/core';
import { Order } from 'src/entities/order';
import { User } from 'src/entities/user';
import { OrderService } from 'src/services/order.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {

  user?: User
  orders?:Order[]

  constructor(private userService:UserService, private orderService:OrderService) { }

  ngOnInit(): void {
    this.userService.refreshUser()
    this.user = this.userService.loggedInUser
    this.orderService.getOrders().subscribe(response =>{
      this.orders = response.filter(element =>{
        return element.orderStatus != 'Arkiverad'
      })
    })
  }

  Ship(id:number): void{
    if(localStorage.getItem("token")){
      this.orderService.shipOrder(id).subscribe(()=> this.ngOnInit())
    }
  }

  File(id:number): void{
    if(localStorage.getItem("token")){
      this.orderService.fileOrder(id).subscribe(()=> this.ngOnInit())
    }
  }

}
