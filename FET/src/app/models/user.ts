export interface EditUserModel {
  firstName?: string;
  lastName?: string;
  phoneNumber?: string;
}

export interface UserModel extends EditUserModel {
  id: string;
  email: string;
  password: string;
  roleId: string;
  departmentId: string;
  department?: string;
  role?: string;
}
