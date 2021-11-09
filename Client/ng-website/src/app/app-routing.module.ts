import { ContactComponent } from './Screens/contact/contact.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AboutComponent } from './Screens/about/about.component';
import { CartComponent } from './Screens/cart/cart.component';
import { ChildComponent } from './Screens/child/child.component';
import { HomeComponent } from './Screens/home/home.component';
import { NgMaterialComponent } from './Screens/ng-material/ng-material.component';
import { ParentComponent } from './Screens/parent/parent.component';
import { ProductsComponent } from './Screens/products/products.component';
import { PurchaseComponent } from './Screens/purchase/purchase.component';
import { UserComponent } from './Screens/user/user.component';

const routes: Routes = [
  { path: 'home', component:  HomeComponent },
  { path: 'cart-component', component:  CartComponent },
  { path: 'products-component', component:  ProductsComponent },
  { path: 'purchase-component', component:  PurchaseComponent },
  { path: 'about-component', component:  AboutComponent },
  { path: 'parent-component', component:  ParentComponent },
  { path: 'child-component', component:  ChildComponent },
  { path: 'user-component', component:  UserComponent },
  { path: 'ng-material-component', component:  NgMaterialComponent },
  { path: 'contact-component', component:  ContactComponent },
  { path: '**', component:  HomeComponent }
  // contact-component
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
