import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { HttpClientService } from 'src/app/core/interceptors/http-client.service';
import { UserLogin } from 'src/app/models';
import { AuthService } from './auth.service';
import { CommonService } from './common.service';

@Injectable({
  providedIn: 'root',
})
export class NonAuthService {
  constructor(private httpService: HttpClientService) {}

  loginUser(userModel: UserLogin): any {
    return this.httpService.post(`api/LogIn/validate`, userModel).pipe(
      catchError((error) => {
        return throwError(error);
      }),
      map((response: any) => {
        return response.model;
      })
    );
  }
}
