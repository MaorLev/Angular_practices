
import { Component, OnInit } from '@angular/core';
import { Products } from 'src/app/Model/products';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  public product:Products = {};
  itemsComponnent: Array<Products> = [];

  constructor(private productService: ProductService
    ) {
   }
  onAddToItems() {
    let productLocal:Products = Object.assign({},this.product);
    this.itemsComponnent = this.productService.addToItems(productLocal);
  }

  onClearitems() {
    this.itemsComponnent = this.productService.clearitems();
  }
  onRemoveValueByIndex(index:Products){
    this.itemsComponnent = this.productService.removeValueByIndex(index);
  }
  ngOnInit(): void {

    this.itemsComponnent = this.productService.getItems()
  }



}
