import { Injectable } from '@angular/core';
import {
  Router,
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { Role } from 'src/app/models';
import { SideBar } from '../common.constant';
import { AuthService } from '../services';
import { CommonService } from '../services/common.service';

@Injectable()
export class AccessGuard implements CanActivate {
  userRole: any;
  sidebarList: any;
  constructor(
    private router: Router,
    private authService: AuthService,
    private commonService: CommonService
  ) {
    this.userRole = null;
    this.sidebarList = null;
  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
    if (route) {
      const sidebar = this.authService.getSidebarDetails();
      const side: any = sidebar.find(
        (x: any) =>
          x.route.toString() ===
          '/'.concat(route.routeConfig?.path ? route.routeConfig?.path : '')
      );

      // logged in so return true
      return side.hasAccess;
    }

    // not logged in so redirect to login page with the return url
    this.router.navigate(['/']);
    return false;
  }
}
