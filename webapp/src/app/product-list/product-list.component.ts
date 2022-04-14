import { Component, OnInit } from '@angular/core';
import { Product } from 'src/entities/product';
import { Category } from 'src/entities/category';
import { ProductService } from 'src/services/product.service';
import { CategoryService } from 'src/services/category.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  selectedCategory?: string;
  products?: Product[];
  categories?: Category[];


  filterCategories(): void{
    this.productService.getProducts().subscribe(response =>{
      if(this.selectedCategory == ""){
        this.products = response;
      } else{
        this.products = response.filter(x => x.category == this.selectedCategory)
      }
    })
  }

  constructor( 
    private productService: ProductService,
    private categoryService: CategoryService
    ) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(response =>{
      this.products = response;
    })
    this.categoryService.getCategories().subscribe(response =>{
      this.categories = response
    })
  }
}
