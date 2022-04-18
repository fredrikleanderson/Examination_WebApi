import { Component, OnInit } from '@angular/core';
import { CartItem } from 'src/entities/cart-item';
import { User } from 'src/entities/user';
import { CreateOrderItem } from 'src/models/create-order-item';
import { DeleteCartItem } from 'src/models/delete-cart-item';
import { PlaceOrder } from 'src/models/place-order';
import { CartService } from 'src/services/cart.service';
import { OrderService } from 'src/services/order.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  user?:User
  cartItems?: CartItem[]
  order?: PlaceOrder

  constructor(private userService:UserService, private cartService:CartService, private orderService:OrderService) { }

  ngOnInit(): void {
    if(localStorage.getItem("token")){
      this.user = this.userService.loggedInUser
      this.cartService.GetCart(this.user?.id!).subscribe(response =>{
        this.cartItems = response
      })
    }
  }

  RemoveItem(cartItem:CartItem):void{
    this.cartService.RemoveCartItem(this.user!.id!, new DeleteCartItem(cartItem.articleNumber!, cartItem.quantity!)).subscribe(response =>{
      this.cartItems = this.cartItems?.filter(element =>{
        return element.id != cartItem.id
      })
    })
  }

  PlaceOrder():void{
    if(this.user && this.cartItems?.length! > 0){
      this.orderService.placeOrder(new PlaceOrder(this.user.id!, "Mottagen")).subscribe(response =>{
        let orderId = response.id
        this.cartItems?.forEach(element =>{
          let orderItem = new CreateOrderItem(orderId!, element.id!, element.productName!, element.quantity!)
          this.orderService.addToOrder(orderItem).subscribe()
        })
      })
      this.cartService.ClearCart(this.user.id!).subscribe(()=> this.ngOnInit())
    }
  }
}
