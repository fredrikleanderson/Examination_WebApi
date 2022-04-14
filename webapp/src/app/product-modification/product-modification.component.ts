import { Component, OnInit } from '@angular/core';
import { UpdateProduct } from 'src/models/update-product';
import { Product } from 'src/entities/product';
import { ProductService } from 'src/services/product.service';
import { Category } from 'src/entities/category';
import { CategoryService } from 'src/services/category.service';

@Component({
  selector: 'app-product-modification',
  templateUrl: './product-modification.component.html',
  styleUrls: ['./product-modification.component.scss']
})
export class ProductModificationComponent implements OnInit {

  model: UpdateProduct;
  selectedProductId?: number;
  products?: Product[];
  categories?: Category[];

  SelectProduct():void {
    this.products?.forEach(x => {
      if(x.id == this.selectedProductId){
        this.model.name = x.name
        this.model.description = x.description
        this.model.price = x.price
        this.model.categoryName = x.category
        this.model.quantity = x.quantity
      }
    })
  }

  UpdateProduct(): void{
    if(this.selectedProductId != null && localStorage.getItem("token")){
      this.productService.updateProduct(this.selectedProductId, this.model).subscribe(response => {
      })
    }
  }

  constructor(private productService: ProductService, private categoryService: CategoryService) {
    this.model = new UpdateProduct("", "", 0, "", 0);
   }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(response =>{
      this.products = response;
    })

    this.categoryService.getCategories().subscribe(response =>{
      this.categories = response;
    })
  }

}
