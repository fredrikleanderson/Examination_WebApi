import { Component, OnInit } from '@angular/core';
import { UpdateProduct } from 'src/models/update-product';
import { Product } from 'src/entities/product';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-product-modification',
  templateUrl: './product-modification.component.html',
  styleUrls: ['./product-modification.component.scss']
})
export class ProductModificationComponent implements OnInit {

  model: UpdateProduct;
  products?: Product[];

  UpdateProduct():void {
    
  }

  constructor(private productService: ProductService) {
    this.model = new UpdateProduct();
   }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(response =>{
      this.products = response;
    })
  }

}
