import {
  CartByPostManService
} from './../../../services/cart-by-post-man.service';
import {
  Component,
  OnInit
} from '@angular/core';
import {
  Page
} from 'src/app/Model/page';
import {
  Cart
} from 'src/app/Model/cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  obj: any = {}
  objUpdate: any = {}
  public items: any = {};
  public specific: Cart = {};
  public num: string = '';
  public chack: any;
  public active: any = true;
  constructor(private appHttp: CartByPostManService) {}

  async ngOnInit(): Promise < any > {
    this.items = await this.appHttp.getCollection();
  }
  async getSpecificObj(id: string): Promise < any > {
    this.specific = await this.appHttp.getSpecificObj(id);
  }
  async updateObj(id: string, object: any): Promise < any > {
    await this.appHttp.updateObject(object, id)
    this.items = await this.appHttp.getCollection();
  }
  async deleteObj(id: string): Promise < any > {
    await this.appHttp.deleteObject(id);
    this.items = await this.appHttp.getCollection();
  }
  async createObj(param: any): Promise < any > {
    await this.appHttp.createObject(param);
    this.items = await this.appHttp.getCollection();
  }


}
