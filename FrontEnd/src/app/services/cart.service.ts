import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cart } from '../models/cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  addToCart(Carts: Cart):Observable<boolean> {
    return this.httpclient.post<boolean>('https://localhost:7197/api/User/RegisterUser',Carts)
   
  }

  constructor(private httpclient:HttpClient) { }
  AddToCart(data:Cart){
    let cartData=[];
    let localCart=localStorage.getItem('localCart');
    if(!localCart){
      localStorage.setItem('localCart',JSON.stringify([data]));
    }else{
      cartData=JSON.parse(localCart)
     cartData.push(data);
     localStorage.setItem('localCart',JSON.stringify(cartData));
    }
  }
}
