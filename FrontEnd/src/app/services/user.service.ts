import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../models/login';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  getAllUsers():Observable<User[]>{
  return this.httpclient.get<User[]>('https://localhost:7197/api/User/GetAllUsers')
  }
  editUser(user: User):Observable<boolean> {
   return  this.httpclient.put<boolean>('https://localhost:7197/api/User/EditUser/'+user.id,user)
  }
  getUserById(id: any):Observable<User> {
   return this.httpclient.get<User>('https://localhost:7197/api/User/GetUserById/'+id)
  }
  
  constructor(private httpclient:HttpClient){ }
  RegisterrUser(user: User):Observable<boolean> {
    return this.httpclient.post<boolean>('https://localhost:7197/api/User/RegisterUser',user)
    
  }
  login(login: Login):Observable<string>{
    return this.httpclient.post<string>('https://localhost:7197/api/User/Login',login)
   
  }
  gotoDeleteComponent(id:any){
    return this.httpclient.delete<boolean>('https://localhost:7197/api/User/delete'+id)
    
  }
  }
 

