import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../auth';

@Component({
  selector: 'app-login',
  standalone : true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  email = '';
  password = '';
  error = '';
  loading = false;

  constructor(private authService : Auth, private router : Router) { }

  onSubmit(): void 
  {
    if(!this.email || !this.password)
    {
      this.error='Please enter email and password';
      return;
    }

    this.loading = true;
    this.error='';

    this.authService.login({email:this.email, password : this.password}).subscribe({
      next : () => {
        this.loading = false;
        this.router.navigate(['/products']);
      },
      error : (err) => {
        this.loading = false;
        this.error = 'Invalid email or password';
        console.error(err);
      }
    })
  }
}
