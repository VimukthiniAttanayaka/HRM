
import { GetDataList as ExitInterviewQuestions_GetDataList } from '../controllers/exitinterviewquestions_controllers.js';
import { GetDataList as Employee_GetDataList } from '../controllers/employee_controllers.js';
import { GetDataList as Branch_GetDataList } from '../controllers/branch_controllers.js';
import { GetDataList as Location_GetDataList } from '../controllers/location_controllers.js';
import { GetDataList as Country_GetDataList } from '../controllers/country_controllers.js';
import { GetDataList as Department_GetDataList } from '../controllers/department_controllers.js';
import { GetDataList as JobRole_GetDataList } from '../controllers/jobrole_controllers.js';

export const setDataByPage = (filename, data) => {

    if (filename == "exitinterviewquestions") {
        // console.log(filename);
        return ExitInterviewQuestions_GetDataList(data)
    }
    if (filename == "employees") {
        // console.log(filename);
        return Employee_GetDataList(data)
    }
    if (filename == "branch") {
        // console.log(filename);
        return Branch_GetDataList(data)
    }
      if (filename == "location") {
        // console.log(filename);
        return Location_GetDataList(data)
    }
    if (filename == "country") {
        // console.log(filename);
        return Country_GetDataList(data)
    }
    if (filename == "department") {
        // console.log(filename);
        return Department_GetDataList(data)
    }  
    if (filename == "jobrole") {
        // console.log(filename);
        return JobRole_GetDataList(data)
    }
}