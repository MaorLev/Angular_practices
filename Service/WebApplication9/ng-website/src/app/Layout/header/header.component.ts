import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Pheader } from 'src/app/Data/layout-data';
import { Header } from 'src/app/Model/header';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Input() headerDetails:Header = Pheader;
  constructor() { }

  ngOnInit(): void {
  }

}
