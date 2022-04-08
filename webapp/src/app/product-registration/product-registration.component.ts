import { Component, OnInit } from '@angular/core';
import { CreateProduct } from 'src/models/create-product';
import { Product } from 'src/entities/product';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-product-registration',
  templateUrl: './product-registration.component.html',
  styleUrls: ['./product-registration.component.scss']
})
export class ProductRegistrationComponent implements OnInit {

  model: CreateProduct;
  product?: Product;

  CreateProduct(): void {
    this.productService.createProduct(this.model).subscribe(response =>{
      this.product = response;
    })
  }

  constructor(private productService:ProductService) {
    this.model = new CreateProduct();
   }

  ngOnInit(): void {
  }

}
