import {
  Component,
  OnInit,
  OnChanges,
  Input,
  SimpleChanges,
} from '@angular/core';
import { Router } from '@angular/router';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';

import { HeaderService, AuthService } from 'src/app/core/services';
import { SideBar } from './../../../../core/common.constant';
import { CommonService } from 'src/app/core/services/common.service';
import { Role } from 'src/app/models';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
  animations: [
    trigger('openClose', [
      state(
        'open',
        style({
          height: '*',
        })
      ),
      state(
        'closed',
        style({
          height: '0px',
        })
      ),
      transition('open => closed', [animate('250ms ease-in-out')]),
      transition('closed => open', [animate('250ms ease-in-out')]),
    ]),
  ],
})
export class SidebarComponent implements OnInit, OnChanges {
  events: string[] = [];
  @Input() opened: boolean;
  sidebarList: any;
  userRole: any;

  constructor(
    protected headerService: HeaderService,
    private router: Router,
    private authService: AuthService,
    private commonService: CommonService
  ) {
    this.userRole = null;
    this.sidebarList = [];
    this.opened = true;
  }

  ngOnChanges(sub: SimpleChanges): any {
    console.log(sub);

    if (sub.opened && sub.opened.currentValue !== sub.opened.previousValue) {
      this.opened = sub.opened.currentValue;
    }
  }

  ngOnInit(): any {
    if (!this.commonService.roles || this.commonService.roles.length === 0) {
      this.commonService.getRoles().subscribe((res: any) => {
        this.commonService.roles = res.roles;
        const user = this.authService.getAuthUserDetails();
        this.userRole = this.commonService.roles.find(
          (x: Role) => x.id?.toString() === user.roleId.toString()
        );
        user.role = this.userRole.name;
        this.authService.setAuthUserDetails(user);

        this.sidebarList = SideBar.map((x: any) => {
          const obj: any = Object.assign({}, x);
          obj.hasAccess = x.access
            ? x.access.includes(this.userRole.name)
            : true;
          return obj;
        });
        this.commonService.sidebarList = this.sidebarList;
        this.authService.setSidebarDetails(this.sidebarList);
      });
    }

    this.opened = this.headerService.showSideBar;
  }

  onClickMenuItem(nav: any): any {
    if (nav.subMenus) {
      this.sidebarList[this.sidebarList.indexOf(nav)].isExpanded = !this
        .sidebarList[this.sidebarList.indexOf(nav)].isExpanded;
    } else {
      this.router.navigateByUrl(`${[nav.route]}`);
    }
  }
}
