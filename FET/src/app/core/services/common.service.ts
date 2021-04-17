import { Injectable } from '@angular/core';
import { throwError, interval, Observable } from 'rxjs';
import { catchError, mergeMap, map } from 'rxjs/operators';

import { HttpClientService } from 'src/app/core/interceptors/http-client.service';
import { BroadcastService } from './broadcast.service';
import { BroadcastKeys } from '../common.constant';
import { UserModel } from 'src/app/models';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  // userRoles = [];
  departments = [];
  roles = [];
  users = [];
  sidebarList = [];

  constructor(
    private httpService: HttpClientService,
    private broadcastService: BroadcastService
  ) {}

  // getRoles(): any {
  //   return new Observable((observer) =>
  //     observer.next([
  //       {
  //         id: 1,
  //         name: 'Admin',
  //       },
  //       {
  //         id: 2,
  //         name: 'Employee',
  //       },
  //       {
  //         id: 3,
  //         name: 'Client',
  //       },
  //     ])
  //   );
  // }

  // getUserRoles(): any {
  //   interval(30 * 1000)
  //     .pipe(
  //       catchError((error) => {
  //         return throwError(error);
  //       }),
  //       mergeMap(() => this.getRoles())
  //     )
  //     .subscribe((response: any) => {
  //       this.onRoleSuscription(response);
  //     });
  // }

  // private onRoleSuscription(response: any): any {
  //   this.userRoles = response;
  //   this.broadcastService.broadcast(BroadcastKeys.userRoles, response);
  // }

  //#region Department services
  getDepartments(): any {
    return this.httpService.get(`api/departments/list`).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        this.departments = response.model;
        return response.model;
      })
    );
  }

  createUpdateDepartment(dept: any): any {
    return this.httpService.post(`api/departments`, dept).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        return response.model;
      })
    );
  }

  getDepartmentById(deptId: any): any {
    return this.httpService.get(`api/departments/${deptId}`).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        return response.model;
      })
    );
  }

  deleteDepartment(dept: any): any {
    return this.httpService.delete(`api/departments`, dept).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        return response;
      })
    );
  }
  //#endregion

  //#region Role services
  getRoles(): any {
    return this.httpService.get(`api/roles/list`).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        this.roles = response.model;
        return response.model;
      })
    );
  }

  createUpdateRole(role: any): any {
    return this.httpService.post(`api/roles`, role).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        return response.model;
      })
    );
  }

  getRoleById(roleId: any): any {
    return this.httpService.get(`api/roles/${roleId}`).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        return response.model;
      })
    );
  }

  deleteRole(role: any): any {
    return this.httpService.delete(`api/roles`, role).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        return response;
      })
    );
  }
  //#endregion

  //#region User services
  getUsers(): any {
    return this.httpService.get(`api/users/list`).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        this.users = response.model;
        return response.model;
      })
    );
  }

  createLoginUser(user: UserModel): any {
    return this.httpService.post(`api/LogIn/create`, user).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        this.getUsers();
        return response.model;
      })
    );
  }

  editProfile(user: any): any {
    return this.httpService.post(`api/users`, user).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        this.getUsers();
        return response.model;
      })
    );
  }

  getUserById(userId: any): any {
    return this.httpService.get(`api/user/${userId}`).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        return response.model;
      })
    );
  }

  deleteUser(user: any): any {
    return this.httpService.delete(`api/users`, user).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        this.getUsers();
        return response;
      })
    );
  }
  //#endregion
}
