
import { Component, OnInit } from '@angular/core';

import { AppHttpService } from 'src/services/app-http.service';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {
  public todo:any;
  constructor(private appHttp:AppHttpService) { }
  public number:string = "";
  public todoitem:any;


  ngOnInit(): void {

  }
  async getAllItems(){
    this.todo = await this.appHttp.getTodoAllItems();
 }
 async getSpecificItems(id:string ){

  this.todoitem = await this.appHttp.getTodoSpecificItem(id);
}
}
