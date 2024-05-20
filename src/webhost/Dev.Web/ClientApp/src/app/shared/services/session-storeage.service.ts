import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SessionStoreageService {
  setToken(token: string): void {
    sessionStorage.setItem('token', token);
  }

  clearToken(): void {
    sessionStorage.removeItem('token');
  }

  getToken(): string {
    return sessionStorage.getItem('token')!;
  }
  
  isAuthenticate(): boolean {
    return !!this.getToken();
  }
  constructor() { }
}
