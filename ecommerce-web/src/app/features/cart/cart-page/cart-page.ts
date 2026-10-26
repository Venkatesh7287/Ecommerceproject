import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Cart, CartItem } from '../cart';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart-page',
  standalone : true,
  imports: [CommonModule],
  templateUrl: './cart-page.html',
  styleUrl: './cart-page.css',
})
export class CartPage {

 constructor(public cartService : Cart, private router : Router, private cdr : ChangeDetectorRef){}

  updateQuantity(item: CartItem, event: Event) : void {
    const value = +(event.target as HTMLInputElement).value;
    this.cartService.updateQuantity(item.productId, value);
    this.cdr.detectChanges();
  }

  removeItem(productId : number) : void
  {
    console.log("removecart", productId);
    this.cartService.removeFromCart(productId);
    this.cdr.detectChanges();
  }
  goToCheckout() : void {
    this.router.navigate(['/checkout']);
  }
}
