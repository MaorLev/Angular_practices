import { AfterViewInit, Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';
import { interval } from 'rxjs';
import { About } from 'src/app/Data/pagesData';
import { Page } from 'src/app/Model/page';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit,OnChanges,AfterViewInit,OnDestroy {
  PageDetails:Page = About;
  public handle: any;
  constructor() { }

  ngOnDestroy(): void {
    clearInterval(this.handle);
  }
  ngAfterViewInit(): void {
    console.log("ngAfterViewInit")
  }
  ngOnChanges(changes: SimpleChanges): void {
    console.log("ngOnChanges");
  }

  ngOnInit(): void {
    console.log("ngOnInit")
    this.handle = setInterval(()=> {alert("cdscs");}
    ,5000)
  }

}
