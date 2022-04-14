import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/entities/product';
import { User } from 'src/entities/user';
import { AddCartItem } from 'src/models/add-cart-item';
import { CartService } from 'src/services/cart.service';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.scss']
})
export class ProductListItemComponent implements OnInit {

  @Input()
  product!: Product;
  user?: User
  quantity: number = 0
  cartItem:AddCartItem

  defaultImgUrl: string = "https://www.plantagen.se/dw/image/v2/BCMR_PRD/on/demandware.static/-/Sites-inriver-catalog/default/dwfc8bd462/images/large/534181-534181.jpg?sw=256&sfrm=jpg";

  constructor(private userService:UserService, private cartService:CartService) {
    this.cartItem = new AddCartItem()
   }

  ngOnInit(): void {
    this.cartItem.productId = this.product!.id
    if(localStorage.getItem("token")){
      this.user = this.userService.loggedInUser
      this.cartItem.userId = this.userService.loggedInUser?.id
    }
  }

  AddToCart():void {
    if(localStorage.getItem("token") && this.product.quantity > 0){
      this.cartService.AddToCart(this.cartItem).subscribe(response =>{
        console.log(response)
        if(response.quantity){
          this.product.quantity -= response.quantity
        }
      })
    }
  }
}
