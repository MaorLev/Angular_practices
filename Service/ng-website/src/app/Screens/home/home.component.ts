import { Component, Input, OnInit } from '@angular/core';
import { Home } from 'src/app/Data/pagesData';
import { Page } from 'src/app/Model/page';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

PageDetails:Page = Home;
  constructor() { }

  ngOnInit(): void {
  }

}
