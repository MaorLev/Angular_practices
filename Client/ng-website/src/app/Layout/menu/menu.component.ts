
import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Pmenuitems } from 'src/app/Data/menu-items';
import { Menuitem } from 'src/app/Model/menuitem';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {



  @Input() menuitemDetails:Menuitem[] = Pmenuitems;
  //Array<Menuitem> same with above array
  constructor() { }

  ngOnInit(): void {
  }

}
