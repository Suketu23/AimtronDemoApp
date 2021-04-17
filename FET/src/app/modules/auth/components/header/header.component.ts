import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService, HeaderService } from 'src/app/core/services';
import { UserModel } from 'src/app/models';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  constructor(
    private router: Router,
    private authService: AuthService,
    public headerService: HeaderService
  ) {}

  ngOnInit(): any {}

  toggleSide(): void {
    this.headerService.toggleSideBar();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  goToProfile(): void {
    const user: UserModel = this.authService.getAuthUserDetails();
    this.router.navigate([`/user/${user.id}`]);
  }
}
