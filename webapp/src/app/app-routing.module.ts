import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductAdministrationComponent } from './product-administration/product-administration.component';
import { ProductListComponent } from './product-list/product-list.component';
import { UserAdministrationComponent } from './user-administration/user-administration.component';

const routes: Routes = [
  {path: 'products', component: ProductListComponent },
  {path: 'productadministration', component: ProductAdministrationComponent },
  {path: 'useradministration', component: UserAdministrationComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }