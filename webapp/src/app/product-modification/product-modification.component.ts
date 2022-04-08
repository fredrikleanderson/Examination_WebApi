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
  selectedProductId?: number;
  products?: Product[];

  SelectProduct():void {
    this.products?.forEach(x => {
      if(x.id == this.selectedProductId){
        this.model.name = x.name
        this.model.description = x.description
        this.model.price = x.price
        this.model.categoryName = x.category
      }
    })
  }

  UpdateProduct(): void{
    if(this.model.name!= "" && this.model.description != "" && this.model.price != 0 && this.model.categoryName != "" && this.selectedProductId != null){
      this.productService.updateProduct(this.selectedProductId, this.model).subscribe(response => {
      })
    }
  }

  constructor(private productService: ProductService) {
    this.model = new UpdateProduct("", "", 0, "");
   }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(response =>{
      this.products = response;
    })
  }

}
