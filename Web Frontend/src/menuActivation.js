export const setMenu = (menuItem) => {
  return menuItem.map((item) => {
    // console.log(item.menuName, item.active);
    localStorage.setItem(item.menuName, item.active);
  });
};

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

export const getMenu_HRM_EEmployeeJobDiscription = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Employee_EmployeeJobDiscription"));
  return item1;
};

export const getMenu_HRM_AAttendanceSearch = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Attendance_AttendanceSearch"));
  return item1;
};

export const getMenu_HRM_AMarkAttendance = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Attendance_MarkAttendance"));
  return item1;
};

export const getMenu_HRM_AGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Attendance_Group"));
  return item1;
};

export const getMenu_HRM_LGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Leave_Group"));
  return item1;
};

export const getMenu_HRM_LLeaveSchedule = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Leave_LeaveSchedule"));
  return item1;
};

export const getMenu_HRM_LLeaveToApprove = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Leave_LeaveToApprove"));
  return item1;
};

export const getMenu_HRM_LLeaveEntitlement = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Leave_LeaveEntitlement"));
  return item1;
};

export const getMenu_HRM_LLeaveType = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_Leave_LeaveType"));
  return item1;
};

export const getMenu_HRM_RPGroup = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_ReportingPerson_Group"));
  return item1;
};

export const getMenu_HRM_RPHierarchyManagement = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_ReportingPerson_HierarchyManagement"));
  return item1;
};

export const getMenu_HRM_RPReportingPerson = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_ReportingPerson_ReportingPerson"));
  return item1;
};

export const getMenu_HRM_RPReportingManagerSearch = () => {
  let item1 = convertStringToBoolean(localStorage.getItem("HRM_ReportingPerson_ReportingManagerSearch"));
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


export const convertStringToBoolean = (item) => {
// console.log(item)
  if (item === 'true') {
    return true;
  } else {
    return false;
  }
};
