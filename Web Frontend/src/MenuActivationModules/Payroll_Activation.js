import {convertStringToBoolean} from '../menuActivation'
    
  export const getMenu_HRM_MDJobRole = () => {
    let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_JobRole"));
    return item1;
  };
  
  export const getMenu_HRM_MDSalaryType = () => {
    let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_SalaryType"));
    return item1;
  };
  
  export const getMenu_HRM_MDJobType = () => {
    let item1 = convertStringToBoolean(localStorage.getItem("HRM_MasterData_JobType"));
    return item1;
  };
  