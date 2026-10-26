import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Product 
{
  id : number;
  name : string;
  description : string;
  price : number;
  stockquantity : number;
  imageUrl : string;
  category : string;

}
@Injectable({ 
  providedIn: 'root',
})
export class Catalog {
  private baseUrl = 'https://localhost:7203/catalog/api/Catalog';

  constructor(private http : HttpClient) { }

  getAllProducts() : Observable<Product[]>
  {
    return this.http.get<Product[]>(this.baseUrl);
  }

  getProductById(id : number) : Observable<Product>
  {
    return this.http.get<Product>(`${this.baseUrl}/${id}`);
  }
}
