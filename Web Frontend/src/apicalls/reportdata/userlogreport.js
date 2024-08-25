const apiUrl = process.env.REACT_APP_API_URL;
const COMPANY_NAME = process.env.COMPANY_NAME;
const COPYRIGHT = process.env.COPYRIGHT;
import { UserLogModel, UserLogModel_Content } from "src/views/logreports/userlog/data";

// console.log(apiUrl)
export const getUserLogReport = async (formData) => {
    const UserLogDetails = new UserLogModel();

    const res = await fetch(apiUrl + 'LogReports/get_UerLogReport', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData),
    })
        .then(response => response.json())
        .then(json => {
            let res1 = JSON.parse(JSON.stringify(json))
            UserLogDetails.CompanyTitle = COMPANY_NAME;
            UserLogDetails.LoggedUser = "Neelaka";
            UserLogDetails.PrintedDate = new Date().toLocaleDateString();
            UserLogDetails.Copyright = COPYRIGHT;

            for (let index = 0; index < res1[0].UserLog.length; index++) {
                let element = res1[0].UserLog[index];
                // console.log(element)
                let obj_c = new UserLogModel_Content();
                obj_c.id = element.UserLogId;
                obj_c.userid = element.UserID;
                obj_c.username = element.UserName;
                obj_c.LoggedDateTime = element.LoggedDateTime;
                obj_c.UserLogOffTime = element.LoggedDateTime;
                UserLogDetails.content[index] = obj_c;
            }
        })

    return UserLogDetails;
};
