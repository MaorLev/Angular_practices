import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cart } from 'src/app/Model/cart';

@Injectable({
  providedIn: 'root'
})
export class CartByPostManService {
  public endPointApi:string = "https://60448ccec0194f00170bbec1.mockapi.io/api/cart/";//url mock with postman
  // items: Array<any> = [{}]
  constructor(private http:HttpClient) { }
  async getSpecificObj(id:string){
    return this.http.get( this.endPointApi +id).toPromise<any>();
  }
  async getCollection():Promise<Array<Cart>>{
    return this.http.get(this.endPointApi).toPromise<any>();
  }
  async createObject(cart:Cart):Promise<Cart> {
    return this.http.post(this.endPointApi ,cart).toPromise<any>();
 }
 async deleteObject(id:string){
  return this.http.delete( this.endPointApi  +id).toPromise<any>();
}
async updateObject(cart:any,id:string):Promise<any> {
  return this.http.put(this.endPointApi + "/" + id ,cart).toPromise<any>();
}
}
