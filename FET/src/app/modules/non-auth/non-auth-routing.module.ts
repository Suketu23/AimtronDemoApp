import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { NonAuthComponent } from './non-auth.component';
import { LoginComponent } from './components';

const routes: Routes = [
  {
    path: '',
    component: NonAuthComponent,
    children: [
      { path: '', component: LoginComponent },
      { path: 'login', component: LoginComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class NonAuthRoutingModule { }
