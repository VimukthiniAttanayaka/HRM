
import {convertStringToBoolean} from '../menuActivation'

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
  
  export const getMenu_HRM_MDLeaveType = () => {
    let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_LeaveType"));
    return item1;
  };
  
  
  export const getMenu_HRM_MDJobType = () => {
    let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_JobType"));
    return item1;
  };
  