import { Component, Input, OnInit } from '@angular/core';
import { Product } from 'src/entities/product';

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.scss']
})
export class ProductListItemComponent implements OnInit {

  @Input()
  product?: Product;

  defaultImgUrl: string = "https://www.plantagen.se/dw/image/v2/BCMR_PRD/on/demandware.static/-/Sites-inriver-catalog/default/dwfc8bd462/images/large/534181-534181.jpg?sw=256&sfrm=jpg";

  constructor() { }

  ngOnInit(): void {}

  AddToBasket = ():void =>{
    alert("Product added to basket");
  }
}
