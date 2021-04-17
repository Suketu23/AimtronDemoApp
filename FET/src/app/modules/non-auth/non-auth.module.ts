import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { NonAuthRoutingModule } from './non-auth-routing.module';

import { LoginComponent } from './components';
import { NonAuthComponent } from './non-auth.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [NonAuthComponent, LoginComponent],
  imports: [CommonModule, NonAuthRoutingModule, SharedModule, HttpClientModule],
})
export class NonAuthModule {}
