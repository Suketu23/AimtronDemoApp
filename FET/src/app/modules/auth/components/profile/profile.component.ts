import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/core/services';
import { CommonService } from 'src/app/core/services/common.service';
import { Department, Role, UserModel } from 'src/app/models';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss'],
})
export class ProfileComponent implements OnInit {
  userform: FormGroup;
  roleList: Role[];
  departmentList: Department[];
  userId: string | null;
  user: UserModel | null;
  disableRoles = true;

  constructor(
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private commonService: CommonService,
    private authService: AuthService
  ) {
    this.userform = this.formBuilder.group({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      phoneNumber: new FormControl('', [
        Validators.required,
        Validators.pattern(/^[0-9]{10,10}$/),
      ]),
      roleId: new FormControl('', [Validators.required]),
      departmentId: new FormControl('', [Validators.required]),
    });

    this.roleList = [];

    this.departmentList = [];
    this.userId = null;
    this.user = null;
  }

  ngOnInit(): void {
    this.userId = this.route.snapshot.paramMap.get('id');
    this.getDepartments();
    this.getRoles();
    this.setFormData();
  }

  /**
   * Method to fetch department data from server
   */
  getDepartments(): any {
    this.commonService.getDepartments().subscribe((response: any) => {
      this.departmentList = response.departments;
    });
  }

  /**
   * Method to fetch Role data from server
   */
  getRoles(): any {
    this.commonService.getRoles().subscribe((response: any) => {
      this.roleList = response.roles;
    });
  }

  /**
   * Method to set form values
   */
  setFormData(): void {
    this.user = this.authService.getAuthUserDetails();

    if (this.user) {
      this.user.role && this.user.role.toString() === 'Admin'
        ? (this.disableRoles = false)
        : true;
      this.user.firstName
        ? this.userform.controls.firstName.setValue(this.user.firstName)
        : null;
      this.user.lastName
        ? this.userform.controls.lastName.setValue(this.user.lastName)
        : null;
      this.user.phoneNumber
        ? this.userform.controls.phoneNumber.setValue(this.user.phoneNumber)
        : null;
      this.user.email
        ? this.userform.controls.email.setValue(this.user.email)
        : null;
      this.user.roleId
        ? this.userform.controls.roleId.setValue(this.user.roleId)
        : null;
      this.user.departmentId
        ? this.userform.controls.departmentId.setValue(this.user.departmentId)
        : null;
    }
  }

  /**
   * Method to edit user profile
   * @param user User
   */
  editUserProfile(user: UserModel): any {
    this.userId ? (user.id = this.userId) : null;
    this.commonService.editProfile(user).subscribe((response: any) => {
      this.authService.setAuthUserDetails(user);
    });

    this.snackBar.open('User profile updated successfully!', 'Message', {
      duration: 2500,
      verticalPosition: 'bottom',
    });
  }
}
