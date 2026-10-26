import { Routes } from '@angular/router';
import { ProductList } from './features/catalog/product-list/product-list';
import { CartPage } from './features/cart/cart-page/cart-page';
import { CheckoutPage } from './features/checkout/checkout-page/checkout-page';
import { Login } from './features/auth/login/login';
import { Register } from './features/auth/register/register';

export const routes: Routes = [
    { path : '', redirectTo : 'products', pathMatch : 'full'},
    { path : 'products', component : ProductList},
    { path : 'cart', component: CartPage},
    { path : 'checkout', component: CheckoutPage},
    { path : 'login', component: Login},
    { path : 'register', component: Register},
];
