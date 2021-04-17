import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CommonService } from 'src/app/core/services/common.service';
import { Department } from 'src/app/models';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.scss'],
})
export class DepartmentComponent implements OnInit, OnDestroy {
  dataSource: Department[];
  displayedColumns: string[];
  selectedDept: Department | null;
  deptInput: any;

  constructor(
    private commonService: CommonService,
    private snackBar: MatSnackBar
  ) {
    this.dataSource = [];
    this.displayedColumns = ['name', 'actions'];
    this.selectedDept = null;
    this.deptInput = '';
  }

  ngOnInit(): void {
    this.getDepartments();
  }

  ngOnDestroy(): void {
    this.selectedDept = null;
  }

  /**
   * Method triggered when user role is created or updated
   * @param dept Department
   */
  createDepartment(dept: any): any {
    console.log(dept);
    const deptModel: Department = {
      name: dept,
    };
    if (this.selectedDept) deptModel.id = this.selectedDept.id;
    this.commonService
      .createUpdateDepartment(deptModel)
      .subscribe((response: any) => {
        this.deptInput = '';
        this.selectedDept = null;
        this.getDepartments();
        this.snackBar.open('Department saved successfully!', 'Message', {
          duration: 2500,
          verticalPosition: 'bottom',
        });
      });
  }

  /**
   * Method to fetch department data from server
   */
  getDepartments(): any {
    this.commonService.getDepartments().subscribe((response: any) => {
      this.dataSource = response.departments;
    });
  }

  /**
   * Method on click of edit button, assigns selected dept in form to edit
   * @param dept Department
   */
  editDepartment(dept: Department): any {
    this.selectedDept = dept;
    this.deptInput = dept.name;
  }
}
