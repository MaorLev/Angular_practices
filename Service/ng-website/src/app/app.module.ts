import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './Layout/header/header.component';
import { FooterComponent } from './Layout/footer/footer.component';
import { MenuComponent } from './Layout/menu/menu.component';
import { ContentComponent } from './Layout/content/content.component';
import { HomeComponent } from './Screens/home/home.component';
import { ProductsComponent } from './Screens/products/products.component';
import { CartComponent } from './Screens/cart/cart.component';
import { AboutComponent } from './Screens/about/about.component';
import { PurchaseComponent } from './Screens/purchase/purchase.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ParentComponent } from './Screens/parent/parent.component';
import { ChildComponent } from './Screens/child/child.component';
import { UserComponent } from './Screens/user/user.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';//angular material
import {MatRadioModule} from '@angular/material/radio';//angular material
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { NgMaterialComponent } from './Screens/ng-material/ng-material.component';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatDividerModule} from '@angular/material/divider';
import { ContactComponent } from './Screens/contact/contact.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MenuComponent,
    ContentComponent,
    HomeComponent,
    ProductsComponent,
    CartComponent,
    AboutComponent,
    PurchaseComponent,
    ParentComponent,
    ChildComponent,
    UserComponent,
    NgMaterialComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSliderModule,//angular material
    MatRadioModule,//angular material
    MatAutocompleteModule,
    MatButtonModule,
    MatInputModule,//for mats elements working done like element in ng-material component to example <mat-form-field></mat-form-field> element
    ReactiveFormsModule//for material input FormControl
    ,
    MatDividerModule
  ],

  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
