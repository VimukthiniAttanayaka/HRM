
import { GetDataList as ExitInterviewQuestions_GetDataList } from '../controllers/exitinterviewquestions_controllers.js';
import { GetDataList as Employee_GetDataList } from '../controllers/employee_controllers.js';

export const setDataByPage = (filename, data) => {

    if (filename == "exitinterviewquestions") {
        // console.log(filename);
        return ExitInterviewQuestions_GetDataList(data)
    }
    if (filename == "employees") {
        // console.log(filename);
        return Employee_GetDataList(data)
    }
}