import { Component, OnInit } from '@angular/core';
import { Product } from 'src/entities/product';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  products?: Product[];

  constructor( private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(response =>{
      this.products = response;
      console.log(response)
    })
  }

}
