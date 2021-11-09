import { AppContextService } from './../../../services/app-context-service';
import { Component, Input, OnChanges, OnInit, Output, SimpleChanges , EventEmitter } from '@angular/core';


@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit , OnChanges {
  @Input() parentData:string | undefined;
  @Input() secData:string |undefined;

  // @Output() newItemEvent = new EventEmitter<string>();

@Output () eventChild:any = new EventEmitter<string>();

  public getData:string | undefined;
  constructor(public AppCtx:AppContextService) { }
  ngOnChanges(changes: SimpleChanges): void {
    // if(changes.parentData){
    //   // this.launchAlert();
    // }

    // if(changes.parentData.isFirstChange()){
    //   alert("first changes");
    //   console.log(changes.parentData.currentValue);
    // }

    // else{
    //   alert("some changes")
    //   console.log(changes.parentData.previousValue);
    // }
  }

  ngOnInit(): void {
    this.getData = this.AppCtx.ShareData;
  }
  launchAlert(){
    alert("i am a child");
  }
  public loadEvent(){
    this.eventChild.emit(this.parentData);
  }

  // addNewItem(value: string) {
  //   this.newItemEvent.emit(value);
  // }
}
