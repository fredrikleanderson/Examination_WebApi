import { Component, OnInit } from '@angular/core';
import { Product } from 'src/entities/product';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-product-deletion',
  templateUrl: './product-deletion.component.html',
  styleUrls: ['./product-deletion.component.scss']
})
export class ProductDeletionComponent implements OnInit {

  selectedProductId?: number;
  products?: Product[];

  DeleteProduct(): void{
    if(this.selectedProductId != null){
      this.productService.deleteProduct(this.selectedProductId).subscribe(response =>{
        console.log(response)
      })
    }
  }

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(response =>{
      this.products = response;
    })
  }

}