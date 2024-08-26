const apiUrl = process.env.REACT_APP_API_URL;
const COMPANY_NAME = process.env.COMPANY_NAME;
const COPYRIGHT = process.env.COPYRIGHT;
import { ErrorLogModel, ErrorLogModel_Content, ErrorLogModel_Title, ErrorLogModel_Header, ErrorLogModel_CopyRight } from "src/views/logreports/errorlog/data";

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
            ErrorLogDetails.CompanyTitle = " DoashaIT (PVT) LTD ";
            ErrorLogDetails.LoggedUser = "Neelaka";
            ErrorLogDetails.PrintedDate = new Date().toLocaleDateString();
            ErrorLogDetails.Copyright = "Doashait © 2024 .";

            let obj_t = new ErrorLogModel_Title();
            obj_t.LoggedUserTitle = "Logged User : ";
            obj_t.LoggedUser = "Neelaka";
            obj_t.CompanyTitle = " DoashaIT (PVT) LTD ";
            obj_t.PrintedDateTitle = "Printed Date : ";
            obj_t.PrintedDate = new Date().toLocaleDateString();

            let obj_h = new ErrorLogModel_Header();
            obj_h.ReportTitle = "Error Log Report";

            let obj_c = new ErrorLogModel_CopyRight();
            obj_c.Copyright = "Doashait © 2024 .";

            ErrorLogDetails.titlelist[0] = obj_t;
            ErrorLogDetails.headerlist[0] = obj_h;
            ErrorLogDetails.copyrightlist[0] = obj_c;

            for (let index = 0; index < res1[0].ErrorLog.length; index++) {
                let element = res1[0].ErrorLog[index];
                // console.log(element)
                let obj_c = new ErrorLogModel_Content();

                obj_c.logid = element.ErrorLogId;
                obj_c.description = element.ErrorDescription;
                obj_c.errorpage = element.ErrorPage;
                obj_c.userid = element.ErrorUserId;
                obj_c.datetime = element.ErrorDatetime;
                obj_c.loggedip = element.ErrorLoggedIp;
                obj_c.errorref = element.ErrorRef;

                ErrorLogDetails.content[index] = obj_c;
            }
        })

    return ErrorLogDetails;
};
