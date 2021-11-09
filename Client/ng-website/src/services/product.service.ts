import { Injectable } from '@angular/core';
import { Products } from 'src/app/Model/products';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  items: Array<Products> = [{product:'product',image:'url of image',price:'price product',descripation:'product discount'},
  {product:'headphone',image:'url of image',price:'price product',descripation:'product discount'}];
  constructor(
    ) {
   }
   addToItems(product: Products) {
     debugger;
    this.items.push(product);
    return this.items;
  }

  getItems() {
    return this.items;
  }

  clearitems() {
    this.items = [];
    return this.items;
  }
  removeValueByIndex(product:Products){
    var index = this.items.indexOf(product);
    this.items.splice(index,1);
    return this.items;
  }
}

