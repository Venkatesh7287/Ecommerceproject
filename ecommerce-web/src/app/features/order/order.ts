import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


export interface OrderItemPayload
{
  productId : number;
  productName : string;
  unitPrice : number;
  quantity : number;
}

export interface OrderPayload{
  customerId : string;
  shippingAddress : string;
  city : string;
  postalCode : string;
  country : string;
  items : OrderItemPayload[];
}
@Injectable({
  providedIn: 'root',
})
export class Order {
  private baseUrl = 'https:localhost:7203/order/api/Order';

  constructor(private http: HttpClient) {}

  placeOrder(order : OrderPayload) : Observable<any>{
    return this.http.post(this.baseUrl, order);
  }
}
