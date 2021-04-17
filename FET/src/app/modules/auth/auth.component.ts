import { Component, OnInit } from '@angular/core';
import { AuthService, HeaderService } from 'src/app/core/services';
import { CommonService } from 'src/app/core/services/common.service';
import { Role, UserModel } from 'src/app/models';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
})
export class AuthComponent implements OnInit {
  constructor(
    public headerService: HeaderService,
    private commonService: CommonService,
    private authService: AuthService
  ) {}

  ngOnInit(): any {
    this.commonService.getUsers().subscribe((res: any) => {
      this.commonService.users = res.users;
      const userEmail = this.authService.getAuthUser();
      this.authService.setAuthUserDetails(
        res.users.find((x: UserModel) => x.email === userEmail)
      );
    });

    this.commonService.getRoles().subscribe((res: any) => {
      this.commonService.roles = res.roles;
    });

    this.commonService.getDepartments().subscribe((res: any) => {
      this.commonService.departments = res.departments;
    });
  }
}
