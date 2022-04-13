import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductAdministrationComponent } from './product-administration/product-administration.component';
import { ProductListComponent } from './product-list/product-list.component';
import { UserAdministrationComponent } from './user-administration/user-administration.component';
import { UserPageComponent } from './user-page/user-page.component';

const routes: Routes = [
  {path: 'products', component: ProductListComponent },
  {path: 'productadministration', component: ProductAdministrationComponent },
  {path: 'useradministration', component: UserAdministrationComponent},
  {path: 'userpage', component:UserPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }