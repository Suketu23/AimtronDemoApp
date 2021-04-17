import { Injectable } from '@angular/core';

import { CommonService } from './common.service';
import { Roles } from '../common.constant';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  jwtToken = 'auth-token';
  userRole = 'user-role';
  user = 'user';
  userDetails = 'user-details';
  sidebar = 'sidebar';

  constructor(private commonService: CommonService) {}

  getAuthUser(): string | null {
    var value = localStorage.getItem(this.user);
    return value && JSON.parse(value);
  }

  setAuthUser(user: string): any {
    localStorage.setItem(this.user, JSON.stringify(user));
  }

  destroyUser(): any {
    window.localStorage.removeItem(this.user);
  }

  getAuthUserDetails(): any | null {
    var value = localStorage.getItem(this.userDetails);
    return value && JSON.parse(value);
  }

  setAuthUserDetails(user: any): any {
    localStorage.setItem(this.userDetails, JSON.stringify(user));
  }

  destroyUserDetails(): any {
    window.localStorage.removeItem(this.userDetails);
  }

  getAuthToken(): string | null {
    return localStorage.getItem(this.jwtToken);
  }

  setAuthToken(user: string): any {
    localStorage.setItem(this.jwtToken, JSON.stringify(user));
  }

  destroyToken(): any {
    window.localStorage.removeItem(this.jwtToken);
  }

  getSidebarDetails(): any | null {
    var value = localStorage.getItem(this.sidebar);
    return value && JSON.parse(value);
  }

  setSidebarDetails(sidebar: any): any {
    localStorage.setItem(this.sidebar, JSON.stringify(sidebar));
  }

  logout(): any {
    localStorage.clear();
    sessionStorage.clear();
  }
}
