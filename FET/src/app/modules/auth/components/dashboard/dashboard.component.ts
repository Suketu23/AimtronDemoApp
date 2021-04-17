import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/core/services';
import { UserModel } from 'src/app/models';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  user: UserModel;
  constructor(private authService: AuthService) {
    this.user = this.authService.getAuthUserDetails();
  }

  ngOnInit(): void {}
}
