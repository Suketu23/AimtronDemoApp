export const BroadcastKeys = {
  headerSearchValue: 'headerSearchValue',
  userRoles: 'userRoles',
  cartCount: 'cartCount',
};

export const Roles = {
  admin: 'Admin',
  department: 'Department',
  client: 'User',
};

export const SideBar = [
  {
    displayName: 'Dashboard',
    route: '/dashboard',
    icon: 'dashboard',
  },
  {
    displayName: 'User',
    route: '/user',
    access: [Roles.admin],
    icon: 'person',
  },
  {
    displayName: 'Department',
    route: '/department',
    access: [Roles.admin, Roles.department],
    icon: 'account_tree',
  },
  {
    displayName: 'Role',
    route: '/role',
    access: [Roles.admin],
    icon: 'supervisor_account',
  },
];
