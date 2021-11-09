import { Injectable } from "@angular/core";

@Injectable({
  providedIn:'root'
})
export class AppContextService {

  constructor(){}
  public get ShareData(): string | any {

    return  window.sessionStorage.getItem('shareData');
  }

  public set ShareData(val : string | any){
    window.sessionStorage.setItem("shareData",val);
  }
}
