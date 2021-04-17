import { Component, OnInit, OnDestroy } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';

import { NonAuthService, AuthService } from 'src/app/core/services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {
  userRoleId: any;
  loginForm: FormGroup;
  error: any;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private nonAuthService: NonAuthService,
    private authService: AuthService,
    public matDialog: MatDialog
  ) {
    this.loginForm = this.formBuilder.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    });
  }

  ngOnInit(): any {}

  ngOnDestroy(): any {
    this.error = null;
  }

  loginUser(form: any): any {
    if (this.loginForm.invalid) {
      return;
    }
    this.nonAuthService.loginUser(form.value).subscribe((response: any) => {
      if (response) {
        this.authService.setAuthToken(response);
        this.authService.setAuthUser(form.value.email);
      }

      window.location.reload();
    });
  }

  clearLocalStorage(): any {
    this.authService.logout();
    this.router.navigate(['./login']);
  }
}
