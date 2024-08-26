const apiUrl = process.env.REACT_APP_API_URL;
const COMPANY_NAME = process.env.COMPANY_NAME;
const COPYRIGHT = process.env.COPYRIGHT;
import { ErrorLogModel, ErrorLogModel_Content } from "src/views/logreports/errorlog/data";

// console.log(apiUrl)
export const getErrorLogReport = async (formData) => {
    const ErrorLogDetails = new ErrorLogModel();

    const res = await fetch(apiUrl + 'LogReports/get_errorLogReport', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData),
    })
        .then(response => response.json())
        .then(json => {
            let res1 = JSON.parse(JSON.stringify(json))
            ErrorLogDetails.CompanyTitle = COMPANY_NAME;
            ErrorLogDetails.LoggedError = "Neelaka";
            ErrorLogDetails.PrintedDate = new Date().toLocaleDateString();
            ErrorLogDetails.Copyright = COPYRIGHT;

            for (let index = 0; index < res1[0].ErrorLog.length; index++) {
                let element = res1[0].ErrorLog[index];
                // console.log(element)
                let obj_c = new ErrorLogModel_Content();
                obj_c.id = element.ErrorLogId;
                obj_c.Errorid = element.ErrorID;
                obj_c.Errorname = element.ErrorName;
                obj_c.LoggedDateTime = element.LoggedDateTime;
                obj_c.ErrorLogOffTime = element.LoggedDateTime;
                ErrorLogDetails.content[index] = obj_c;
            }
        })

    return ErrorLogDetails;
};
