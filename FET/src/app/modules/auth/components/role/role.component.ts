import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import { CommonService } from 'src/app/core/services/common.service';
import { Role } from 'src/app/models';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss'],
})
export class RoleComponent implements OnInit, OnDestroy {
  dataSource: any;
  displayedColumns: string[];

  selectedRole: Role | null;
  roleInput: any;

  constructor(
    public dialogService: MatDialog,
    private commonService: CommonService,
    private snackBar: MatSnackBar
  ) {
    this.dataSource = [];
    this.displayedColumns = ['name', 'actions'];
    this.selectedRole = null;
  }

  ngOnInit(): void {
    this.getRoles();
  }

  ngOnDestroy(): void {
    this.selectedRole = null;
  }

  /**
   * Method to create or update existing role
   * @param role role
   */
  createRole(role: any): any {
    const roleModel: Role = {
      name: role,
    };
    if (this.selectedRole) roleModel.id = this.selectedRole.id;
    this.commonService
      .createUpdateRole(roleModel)
      .subscribe((response: any) => {
        this.getRoles();
        this.roleInput = '';
        this.selectedRole = null;
        this.snackBar.open('Role saved successfully!', 'Message', {
          duration: 2500,
          verticalPosition: 'bottom',
        });
      });
  }

  /**
   * Method to fetch roles list from server
   */
  getRoles(): any {
    this.commonService.getRoles().subscribe((response: any) => {
      this.dataSource = response.roles;
    });
  }

  /**
   * Method on click of edit button, assigns selected role in form to edit
   * @param role Role
   */
  editRole(role: Role): any {
    this.selectedRole = role;
    this.roleInput = role.name;
  }
}
