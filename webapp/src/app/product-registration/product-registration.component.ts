import { Component, OnInit } from '@angular/core';
import { CreateProduct } from 'src/models/create-product';
import { Product } from 'src/entities/product';
import { ProductService } from 'src/services/product.service';
import { Category } from 'src/entities/category';
import { CategoryService } from 'src/services/category.service';

@Component({
  selector: 'app-product-registration',
  templateUrl: './product-registration.component.html',
  styleUrls: ['./product-registration.component.scss']
})
export class ProductRegistrationComponent implements OnInit {

  categories?: Category[];
  model: CreateProduct;
  product?: Product;

  CreateProduct(): void {
    if(localStorage.getItem("token")){
      this.productService.createProduct(this.model).subscribe(response =>{
        this.product = response;
      })
    }
  }

  constructor(private productService:ProductService, private categoryService:CategoryService) {
    this.model = new CreateProduct();
   }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(response => {
      this.categories = response;
    })
  }

}
