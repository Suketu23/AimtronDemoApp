import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccessGuard } from 'src/app/core/guards/access.guard';

import { AuthComponent } from './auth.component';
import {
  DashboardComponent,
  DepartmentComponent,
  ProfileComponent,
  RoleComponent,
  UserComponent,
} from './components';

const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'user', component: UserComponent, canActivate: [AccessGuard] },
      {
        path: 'department',
        component: DepartmentComponent,
        canActivate: [AccessGuard],
      },
      { path: 'role', component: RoleComponent, canActivate: [AccessGuard] },
      { path: 'user/:id', component: ProfileComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
