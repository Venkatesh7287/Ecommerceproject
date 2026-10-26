import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../auth';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  firstName = '';
  lastName = '';
  email = '';
  password = '';
  phoneNumber = '';
  error = '';
  loading = false;

  constructor(private authService : Auth, private router : Router ){}

  onSubmit() : void {
    if(!this.firstName || !this.email || !this.password)
    {
      this.error = 'Please fill in all required fields';
      return;
    }
    this.loading = true;
    this.error = '';

    this.authService.register({
      firstName : this.firstName,
      lastName: this.lastName,
      email : this.email,
      password : this.password,
      phoneNumber : this.phoneNumber
    }).subscribe({
      next : () => {
        this.loading= false;
        this.router.navigate(['/products']);
      },
      error : (err) => {
        this.loading = false;
        this.error = 'Registration failed. Email may already be in use.';
        console.error(err);
      }
    })
  }
}
