import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Order, OrderPayload } from '../../order/order';
import { Cart } from '../../cart/cart';
import { FormsModule } from '@angular/forms';
import { Auth } from '../../auth/auth';

@Component({
  selector: 'app-checkout-page',
  standalone : true,
  imports: [CommonModule, FormsModule],
  templateUrl: './checkout-page.html',
  styleUrl: './checkout-page.css',
})
export class CheckoutPage {
  shippingAddress = '';
  city = '';
  postalCode = '';
  country = '';
  placing = false;
  error = '';

  constructor(public cartService : Cart, 
    private orderService : Order,
    private router : Router,
    private authService : Auth
  ){}

  placeOrder() : void{

    const userId = this.authService.getUserId();
    if(!this.authService.isLoggedIn() || !userId)
    {
      this.error = 'Please log in to place an order';
      this.router.navigate(['/login']);
      return;
    }

    if(!this.shippingAddress || !this.city || !this.postalCode || !this.country)
    {
      this.error = 'Please fill in all shipping details';
      return;
    }
  
  const payload : OrderPayload = {
    customerId : userId.toString(),
    shippingAddress : this.shippingAddress,
    city : this.city,
    postalCode : this.postalCode,
    country : this.country,
    items : this.cartService.getItems().map(item => ({
      productId : item.productId,
      productName : item.productName,
      unitPrice : item.price,
      quantity : item.quantity
    }))
  };
  this.placing = true;
  this.orderService.placeOrder(payload).subscribe({
    next : (res) => {
      this.placing = false;
      this.cartService.clearCart();
      this.router.navigate(['/products']);
      alert('Order placed successfully!');
    },
    error:(err) => {
      this.placing = false;
      this.error = 'Failed to place order. Please try again.';
      console.error(err);
    }
  });
  }
}
