import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonService } from 'src/app/core/services/common.service';
import { Department, Role, UserModel } from 'src/app/models';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss'],
})
export class UserComponent implements OnInit {
  userform: FormGroup;
  roleList: Role[];
  departmentList: Department[];

  dataSource: UserModel[];
  displayedColumns: string[];

  constructor(
    private formBuilder: FormBuilder,
    private commonService: CommonService,
    private snackBar: MatSnackBar
  ) {
    this.userform = this.formBuilder.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      roleId: new FormControl('', [Validators.required]),
      departmentId: new FormControl('', [Validators.required]),
    });

    this.roleList = [];

    this.departmentList = [];

    this.displayedColumns = [
      'firstName',
      'lastName',
      'email',
      'phoneNumber',
      'role',
      'department',
    ];

    this.dataSource = [];
  }

  ngOnInit(): void {
    this.getDepartments();
    this.getRoles();
    this.getUsers();
  }

  /**
   * Method toretrive all users from server
   */
  getUsers(): any {
    this.commonService.getUsers().subscribe((response: any) => {
      this.dataSource = response.users;
      this.dataSource.forEach((data) => {
        data.department = this.departmentList.find(
          (x) => x.id === data.departmentId
        )?.name;
        data.role = this.roleList.find((x) => x.id === data.roleId)?.name;
      });
    });
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
   * Method to create user for admin
   * @param user User
   */
  createUser(user: UserModel): any {
    console.log(user);
    this.commonService.createLoginUser(user).subscribe((response: any) => {
      console.log(response);
      this.getUsers();
      this.userform.reset();
      for (let name in this.userform.controls) {
        this.userform.controls[name].setErrors(null);
      }
      this.snackBar.open('User created successfully!', 'Message', {
        duration: 2500,
        verticalPosition: 'bottom',
      });
    });
  }
}
