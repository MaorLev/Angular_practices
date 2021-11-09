import { Router } from '@angular/router';
import { AppContextService } from './../../../services/app-context-service';
import { ChildComponent } from './../child/child.component';
import { AfterViewInit, Component, OnInit, ViewChild, OnChanges, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements OnInit,AfterViewInit,OnChanges {

public sendChildData:string = "i am a father of child"
@ViewChild("sun") child : ChildComponent | undefined;//in the decorator brackets this is name for reference#

public sendData:string = "";

items = ['item1', 'item2', 'item3', 'item4'];

constructor(public appCtx:AppContextService,public router:Router ) { }
  ngOnChanges(changes: SimpleChanges): void {

    // if(changes)
    // window.alert("on changes");

  }
  ngAfterViewInit(): void {//נותן לי להשתמש בקומפוננטת אחרת בקומפוננטה שלי ומוצג רק בעת אתחול הקומפוננט
    // try {
    //   this.child?.launchAlert()
    // } catch (error) {
    //   alert("errorrr!!")
    // }

  }

  ngOnInit(): void {
    // try {
    //   this.child?.launchAlert()
    // } catch (error) {
    //   alert("errorrr!! in onInit")
    // }
  }
  public SharedData(){
    this.appCtx.ShareData = this.sendData;
    this.router.navigate(['/child-component'])
  }
  public onShareOutput($event:string){

    window.alert('this is the event from parent-------' + $event);
  }

  // addItem(newItem: string) {
  //   this.items.push(newItem);
  // }
}
