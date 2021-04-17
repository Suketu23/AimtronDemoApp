import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';

import { AuthComponent } from './auth.component';
import { LandingPageComponent, HeaderComponent, SidebarComponent } from './components';

import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { RoleComponent } from './components/role/role.component';
import { DepartmentComponent } from './components/department/department.component';
import { UserComponent } from './components/user/user.component';
import { ProfileComponent } from './components/profile/profile.component';

@NgModule({
  declarations: [
    AuthComponent,
    LandingPageComponent,
    HeaderComponent,
    SidebarComponent,
    DashboardComponent,
    RoleComponent,
    DepartmentComponent,
    UserComponent,
    ProfileComponent,
  ],
  imports: [
    CommonModule,
    AuthRoutingModule,
    SharedModule,
  ],
})
export class AuthModule { }
