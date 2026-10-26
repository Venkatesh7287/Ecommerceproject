import { Injectable } from '@angular/core';
import { Product } from '../catalog/catalog';

export interface CartItem
{
  productId : number;
  productName : string;
  price : number;
  quantity : number;
  imageUrl : string;
}

@Injectable({
  providedIn: 'root',
})
export class Cart {
  private storageKey = 'ecommerce_cart';
  items : CartItem[] = [];

  constructor(){ this.loadCart();}

  private loadCart() : void {
    const saved = localStorage.getItem(this.storageKey);
    this.items = saved ? JSON.parse(saved) : [];
  }
 
  private saveCart() : void{
    localStorage.setItem(this.storageKey, JSON.stringify(this.items));    
  }

  addToCart(product : Product) : void
  {
    const existing = this.items.find(i => i.productId === product.id);
    if(existing)
    {
      existing.quantity += 1;
    }
    else{
      this.items.push({
        productId : product.id,
        productName : product.name,
        price : product.price,
        quantity : 1,
        imageUrl : product.imageUrl
      });
    }
    this.saveCart();
  }

  removeFromCart(productId : number) : void
  {
    this.items = this.items.filter( i => i.productId !== productId);
    this.saveCart();
    console.log("removeFromCart", productId);
  }

  updateQuantity(productId: number, quantity : number) : void
  {
    const item = this.items.find( i => i.productId === productId);
    if(item)
    {
      item.quantity = quantity < 1 ? 1 : quantity;
      this.saveCart();
    }
  }
  getItems() : CartItem[]{
    return this.items;
  }

  getTotal() : number {
    return this.items.reduce((sum, item) => sum + item.price * item.quantity, 0);

  }

  getItemsCount() : number {
    return this.items.reduce((sum, item) => sum + item.quantity, 0);
  }

  clearCart() : void {
    this.items = [];
    this.saveCart();
  }
}
