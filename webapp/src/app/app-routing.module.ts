import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CartComponent } from './cart/cart.component';
import { OrdersComponent } from './orders/orders.component';
import { ProductAdministrationComponent } from './product-administration/product-administration.component';
import { ProductListComponent } from './product-list/product-list.component';
import { UserAdministrationComponent } from './user-administration/user-administration.component';
import { UserPageComponent } from './user-page/user-page.component';

const routes: Routes = [
  {path: 'products', component: ProductListComponent },
  {path: 'productadministration', component: ProductAdministrationComponent },
  {path: 'useradministration', component: UserAdministrationComponent},
  {path: 'userpage', component:UserPageComponent},
  {path: 'cart', component:CartComponent},
  {path: 'orders', component: OrdersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }