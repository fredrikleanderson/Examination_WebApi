import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductListItemComponent } from './product-list-item/product-list-item.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductAdministrationComponent } from './product-administration/product-administration.component';
import { ProductRegistrationComponent } from './product-registration/product-registration.component';
import { ProductModificationComponent } from './product-modification/product-modification.component';
import { ProductDeletionComponent } from './product-deletion/product-deletion.component';
import { UserAdministrationComponent } from './user-administration/user-administration.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { UserAuthenticationComponent } from './user-authentication/user-authentication.component';
import { CategoryModificationComponent } from './category-modification/category-modification.component';
import { UserPageComponent } from './user-page/user-page.component';
import { UserModificationComponent } from './user-modification/user-modification.component';
import { UserDeletionComponent } from './user-deletion/user-deletion.component';
import { CartComponent } from './cart/cart.component';
import { OrdersComponent } from './orders/orders.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    ProductListComponent,
    ProductListItemComponent,
    ProductAdministrationComponent,
    ProductRegistrationComponent,
    ProductModificationComponent,
    ProductDeletionComponent,
    UserAdministrationComponent,
    UserRegistrationComponent,
    UserAuthenticationComponent,
    CategoryModificationComponent,
    UserPageComponent,
    UserModificationComponent,
    UserDeletionComponent,
    CartComponent,
    OrdersComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
