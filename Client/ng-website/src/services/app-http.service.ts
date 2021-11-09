import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppHttpService {
//public endPointApi:string = "https://60448ccec0194f00170bbec1.mockapi.io/api/cart";//url mock with postman
public endPointApi:string = "https://60448ccec0194f00170bbec1.mockapi.io/api/cart";//url mock with postman
  constructor(private http:HttpClient) { }
  async getTodoAllItems(){
    return this.http.get("https://jsonplaceholder.typicode.com/todos").toPromise<any>();
  }
  async getTodoSpecificItem(id:string){
    return this.http.get("https://jsonplaceholder.typicode.com/todos/"+id).toPromise<any>();
  }
}
