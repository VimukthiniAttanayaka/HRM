import {convertStringToBoolean} from '../menuActivation'

export const getMenu_HRM_EEmployee = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Employee_Employee"));
  return item1;
};

export const getMenu_HRM_ECustomer = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Employee_Customer"));
  return item1;
};

export const getMenu_HRM_EGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Employee_Group"));
  return item1;
};

export const getMenu_HRM_EEmployeeJobDescription = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Employee_EmployeeJobDescription"));
  return item1;
};

export const getMenu_HRM_UMGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_UserManagement_Group"));
  return item1;
};

export const getMenu_HRM_UMInternalUser = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_UserManagement_InternalUser"));
  return item1;
};

export const getMenu_HRM_UMExternelUser = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_UserManagement_ExternelUser"));
  return item1;
};

export const getMenu_HRM_UMUserRole = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_UserManagement_UserRole"));
  return item1;
};

export const getMenu_HRM_UMAccessGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_UserManagement_AccessGroup"));
  return item1;
};

export const getMenu_HRM_UMMenuAccessGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_UserManagement_MenuAccessGroup"));
  return item1;
};

export const getMenu_HRM_UMUserRoleAccessGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_UserManagement_UserRoleAccessGroup"));
  return item1;
};

export const getMenu_HRM_UMUserMenu = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_UserManagement_UserMenu"));
  return item1;
};

export const getMenu_HRM_MDGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_Group"));
  return item1;
};

export const getMenu_HRM_MDBranch = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_Branch"));
  return item1;
};

export const getMenu_HRM_MDCountry = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_Country"));
  return item1;
};

export const getMenu_HRM_MDDepartment = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_Department"));
  return item1;
};

export const getMenu_HRM_MDJobRole = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_JobRole"));
  return item1;
};

export const getMenu_HRM_MDJobType = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_JobType"));
  return item1;
};

export const getMenu_HRM_MDLocation = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_Location"));
  return item1;
};
