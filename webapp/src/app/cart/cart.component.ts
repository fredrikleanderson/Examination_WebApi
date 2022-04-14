import { Component, OnInit } from '@angular/core';
import { CartItem } from 'src/entities/cart-item';
import { User } from 'src/entities/user';
import { CartService } from 'src/services/cart.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  user?:User
  cartItems?: CartItem[]

  constructor(private userService:UserService, private cartService:CartService) { }

  ngOnInit(): void {
    if(localStorage.getItem("token")){
      this.user = this.userService.loggedInUser
      this.cartService.GetCart(this.user?.id!).subscribe(response =>{
        this.cartItems = response
      })
    }
  }

}
