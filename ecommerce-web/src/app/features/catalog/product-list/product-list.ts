import { CommonModule } from '@angular/common';
import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Catalog, Product } from '../catalog';
import { Cart } from '../../cart/cart';

@Component({
  selector: 'app-product-list',
  standalone : true,
  imports: [CommonModule],
  templateUrl: './product-list.html',
  styleUrl: './product-list.css',
})
export class ProductList implements OnInit{
  products : Product[] = [];
  loading = true;
  error = '';

  constructor(private catalogService : Catalog, private cdr: ChangeDetectorRef, private cartService : Cart){}
 
  ngOnInit(): void {
    console.log('ngOnInit called');
    this.catalogService.getAllProducts().subscribe({
      next : (data) => {
        console.log('Data received:', data);
        this.products = data;
        this.loading = false;
        this.cdr.detectChanges();
      },
      error : (err) => {
        console.log('Error occured:',err);
        this.error = 'Failed to load products';
        this.loading = false;
        this.cdr.detectChanges();
        console.error(err);
      }
    })
  }
  addToCart(product : Product) : void {
    this.cartService.addToCart(product);
  }
}
