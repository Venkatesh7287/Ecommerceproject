import { Component, signal } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { Cart } from './features/cart/cart';
import { Auth } from './features/auth/auth';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone : true,
  imports: [RouterOutlet, RouterLink, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  constructor(public cartService : Cart, public authService : Auth, private router : Router){}

  logout() : void{
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
