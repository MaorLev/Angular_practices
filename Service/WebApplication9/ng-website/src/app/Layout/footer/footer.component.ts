import { Component, Input, OnInit } from '@angular/core';
import { Pfooter } from 'src/app/Data/layout-data';
import { Footer } from 'src/app/Model/footer';



@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

@Input() footerDetails:Footer = Pfooter;
  constructor() { }

  ngOnInit(): void {
  }

}
