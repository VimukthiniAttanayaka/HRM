
import { UserLogModel, UserLogModel_Content, UserLogModel_Title, UserLogModel_Header, UserLogModel_CopyRight } from "src/views/logreports/userlog/data";

const apiUrl = process.env.REACT_APP_API_URL;
const companyname = process.env.COMPANY_NAME;
const COPYRIGHT = process.env.COPYRIGHT;

// console.log(apiUrl)
export const getUserLogReport = async (formData) => {
    const UserLogDetails = new UserLogModel();

    // console.log(companyname);

    const res = await fetch(apiUrl + 'LogReports/get_UserLogReport', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData),
    })
        .then(response => response.json())
        .then(json => {
            let res1 = JSON.parse(JSON.stringify(json))
            UserLogDetails.CompanyTitle = " DoashaIT (PVT) LTD ";
            UserLogDetails.LoggedUser = "Neelaka";
            UserLogDetails.PrintedDate = new Date().toLocaleDateString();
            UserLogDetails.Copyright = "Doashait © 2024 .";

            let obj_t = new UserLogModel_Title();
            obj_t.LoggedUserTitle = "Logged User : ";
            obj_t.LoggedUser = "Neelaka";
            obj_t.CompanyTitle = " DoashaIT (PVT) LTD ";
            obj_t.PrintedDateTitle = "Printed Date : ";
            obj_t.PrintedDate = new Date().toLocaleDateString();

            let obj_h = new UserLogModel_Header();
            obj_h.ReportTitle = "User Log Report";

            let obj_c = new UserLogModel_CopyRight();
            obj_c.Copyright = "Doashait © 2024 .";

            UserLogDetails.titlelist[0] = obj_t;
            UserLogDetails.headerlist[0] = obj_h;
            UserLogDetails.copyrightlist[0] = obj_c;

            for (let index = 0; index < res1[0].UserLog.length; index++) {
                let element = res1[0].UserLog[index];
                // console.log(element)
                let obj_c = new UserLogModel_Content();
                obj_c.id = element.UserLogId;
                obj_c.userid = element.UserID;
                obj_c.username = element.UserName;
                obj_c.loggedin = element.LoggedDateTime;
                obj_c.logout = element.LoggedDateTime;
                UserLogDetails.content[index] = obj_c;
            }
        })
    // console.log(UserLogDetails)
    return UserLogDetails;
};
