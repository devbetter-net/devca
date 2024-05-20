import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';
import { environment } from '@/environments/environment';
import { SessionStoreageService } from '@/app/shared/services/session-storeage.service';
import { LogiInResponse } from '@/app/auth/types';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient,
    private sessionStoreageService: SessionStoreageService
  ) { }
  login(email: string, password: string) {

    return this.http.post(`${environment.baseApiPath}/authen/login`, { email, password })
      .pipe(tap(response => {
        let signInResponse: LogiInResponse = response as LogiInResponse;
        console.table(signInResponse);
        if (signInResponse.signInSuccessfully) {
          this.sessionStoreageService.setToken(signInResponse.token);
        }
      }));
  }

  logout() {
    this.sessionStoreageService.clearToken();
  }
}
