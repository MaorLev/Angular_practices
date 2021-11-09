import { User } from './../app/Model/user';
import { environment } from './../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  public endPointApi:string = environment.endPointApi + "/api/Users";//url with really backend

  constructor(private http:HttpClient) { }

  async getSingleUser(id:number){

    return this.http.get(this.endPointApi+"/" +id).toPromise<any>();
  }

  async getUsers():Promise<Array<User>>{
    return this.http.get(this.endPointApi).toPromise<any>();
  }




  async createUser(user:User):Promise<User> {
    return this.http.post(this.endPointApi ,user).toPromise<any>();
 }
 async deleteUser(id:number){
  return this.http.delete( this.endPointApi + "/" +id).toPromise<any>();
}
async updateUser(cart:any,id:number):Promise<any> {
  return this.http.put(this.endPointApi + "/" + id ,cart).toPromise<any>();
}
}
