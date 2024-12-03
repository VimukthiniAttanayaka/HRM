import {convertStringToBoolean} from '../menuActivation'
  
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
 