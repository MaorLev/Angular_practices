import { Component } from '@angular/core';
import { Pfooter, Pheader } from './Data/layout-data';
import { Pmenuitems } from './Data/menu-items';
import { Footer } from './Model/footer';
import { Header } from './Model/header';
import { Menuitem } from './Model/menuitem';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Mystore';
  FooterData : Footer = Pfooter;
  headerData : Header = Pheader;
  menuitemData : Array<Menuitem> = Pmenuitems ;

}
