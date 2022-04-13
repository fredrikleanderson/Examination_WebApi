import { Component, OnInit } from '@angular/core';
import { Category } from 'src/entities/category';
import { UpdateCategory } from 'src/models/update-category';
import { CategoryService } from 'src/services/category.service';

@Component({
  selector: 'app-category-modification',
  templateUrl: './category-modification.component.html',
  styleUrls: ['./category-modification.component.scss']
})
export class CategoryModificationComponent implements OnInit {

  model: UpdateCategory
  categories?: Category[]
  selectedCategoryId: number = 0

  constructor(private categoryService:CategoryService) {
    this.model = new UpdateCategory()
   }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(response =>{
      this.categories = response
    })
  }

  UpdateCategory(): void{
    this.categoryService.updateCategory(this.selectedCategoryId, this.model).subscribe(response =>{
      console.log(response)
    })
  }

  SelectCategory(): void{
    this.model.name = this.categories?.find(x => {
      return x.id == this.selectedCategoryId
    })?.name
    this.categoryService.getCategories().subscribe(response =>{
      this.categories = response
    })
  }

}
