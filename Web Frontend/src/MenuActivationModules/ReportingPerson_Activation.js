 
import {convertStringToBoolean} from '../menuActivation'

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