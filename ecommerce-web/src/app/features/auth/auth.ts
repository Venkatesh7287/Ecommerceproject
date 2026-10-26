import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

export interface RegisterPayload
{
  firstName : string;
  lastName : string;
  email : string;
  password : string;
  phoneNumber : string;
}

export interface LoginPayload
{
  email : string;
  password : string;
}

export interface AuthResponse
{
  token : string;
  userId : number;
  firstName : string;
  email : string;
}
@Injectable({
  providedIn: 'root',
})
export class Auth {

  private baseUrl = 'https://localhost:7203/user/api/User';
  private tokenKey = 'ecommerce_token';
  private userKey = 'ecommerce_user';

  constructor(private http: HttpClient) {}

  register(data: RegisterPayload): Observable<AuthResponse>
  {
    return this.http.post<AuthResponse>(`${this.baseUrl}/register`, data).pipe(
      tap(res => this.saveSession(res))
    );
  }

  login(data: LoginPayload): Observable<AuthResponse>
  {
    return this.http.post<AuthResponse>(`${this.baseUrl}/login`, data).pipe(
      tap(res => this.saveSession(res))
    );
  }

  private saveSession(res : AuthResponse) : void
  {
    localStorage.setItem(this.tokenKey, res.token);
    localStorage.setItem(this.userKey, JSON.stringify({userId : res.userId, 
      firstName : res.firstName, email : res.email}));
  }

  logout() : void {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem(this.userKey);
  }
  getToken() : string | null {
    return localStorage.getItem(this.tokenKey);
    
  }

  getUserId() : number | null{
    const user = localStorage.getItem(this.userKey);
    return user ? JSON.parse(user).userId : null;
  }

  isLoggedIn() : boolean {
    return !!this.getToken();
  }
 }

