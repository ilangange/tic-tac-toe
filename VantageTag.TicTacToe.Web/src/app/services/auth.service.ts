import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment'
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedIn: BehaviorSubject<any> = new BehaviorSubject(false);

  constructor(public jwtHelper: JwtHelperService, private http: HttpClient) { }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('access_token');

    if (token == null) {
      return false;
    }
    return !this.jwtHelper.isTokenExpired(token);
  }

  login(username: string, password: string) {
    return this.http.post<User>(environment.base_api + 'api/v1/auth/login', { username, password });
  }

  checkLogin(): Observable<boolean> {
    var token = localStorage.getItem('access_token');
    if (token !== null && token !== '') {
      this.isLoggedIn.next(true);
    }
    else {
      this.isLoggedIn.next(false);
    }
    return this.isLoggedIn;
  }

  saveToken(token: any) {
    if (token !== null) {
      localStorage.setItem('access_token', token);
      this.isLoggedIn.next(true);
    }
    else {
      localStorage.removeItem('access_token');
      this.isLoggedIn.next(false);
    }
  }

  getAccessToken() {
    return localStorage.getItem('access_token');
  }
}
