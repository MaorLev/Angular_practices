import { UserService } from './../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Model/user';
import {FormControl} from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  myControl = new FormControl();
  options: string[]= [];
  filteredOptions: Observable<string[]> | undefined;

public users:Array<User> = [{}];
public user:User = {};
public num: string = '';
public chack: any;
public active: any = true;
obj: User = {}
userUpdate: User = {}
favoriteSeason: string | undefined;
seasons: string[] = ['Winter', 'Spring', 'Summer', 'Autumn'];
  constructor(private userService:UserService) { }

  async ngOnInit(): Promise < any > {
    this.users = await this.userService.getUsers();

    this.users.forEach(user => {

      this.options.push(user.Email || '')

    });

    this.filteredOptions = this.myControl.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }

 async onGetSingleUser(email:any): Promise < any > {
  let id:number | undefined  ;

  this.users.forEach(user => {
    if(user.Email == email)
      id = user.Id
  });
    this.user = await this.userService.getSingleUser(id || 0)
  }



  async onUpdateUser(id: any, object: any , dto : User): Promise < any > {
    object.FirstName = dto.FirstName;
    object.LastName = dto.LastName;
    object.Email = dto.Email;
    await this.userService.updateUser(object, id)
    this.users = await this.userService.getUsers();
  }






  async onDeleteUser(id: any): Promise < any > {
    await this.userService.deleteUser(id);
    this.users = await this.userService.getUsers();
  }




  async onCreateUser(param: any): Promise < any > {
    await this.userService.createUser(param);
    this.users = await this.userService.getUsers();
  }
// async onGetUsers(){
//   this.users = await this.userService.getUsers();
// }

}
