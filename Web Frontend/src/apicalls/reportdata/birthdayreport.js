const apiUrl = process.env.REACT_APP_API_URL;
const COMPANY_NAME = process.env.COMPANY_NAME;
const COPYRIGHT = process.env.COPYRIGHT;
import { BirthdayModel, BirthdayModel_Content, BirthdayModel_Title, BirthdayModel_Header, BirthdayModel_CopyRight } from "src/views/Report/birthdayreport/data.js";

// console.log(apiUrl)
export const getBirthdayReport = async (formData) => {
    const BirthdayDetails = new BirthdayModel();

    const res = await fetch(apiUrl + 'Reports/get_BirthdayReport', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData),
    })
        .then(response => response.json())
        .then(json => {
            let res1 = JSON.parse(JSON.stringify(json))
            BirthdayDetails.CompanyTitle = " DoashaIT (PVT) LTD ";
            BirthdayDetails.LoggedUser = "Neelaka";
            BirthdayDetails.PrintedDate = new Date().toLocaleDateString();
            BirthdayDetails.Copyright = "Doashait © 2024 .";

            let obj_t = new BirthdayModel_Title();
            obj_t.LoggedUserTitle = "Logged User : ";
            obj_t.LoggedUser = "Neelaka";
            obj_t.CompanyTitle = " DoashaIT (PVT) LTD ";
            obj_t.PrintedDateTitle = "Printed Date : ";
            obj_t.PrintedDate = new Date().toLocaleDateString();

            let obj_h = new BirthdayModel_Header();
            obj_h.ReportTitle = "Error Log Report";

            let obj_c = new BirthdayModel_CopyRight();
            obj_c.Copyright = "Doashait © 2024 .";

            BirthdayDetails.titlelist[0] = obj_t;
            BirthdayDetails.headerlist[0] = obj_h;
            BirthdayDetails.copyrightlist[0] = obj_c;

            for (let index = 0; index < res1[0].Birthday.length; index++) {
                let element = res1[0].Birthday[index];
                // console.log(element)
                let obj_c = new BirthdayModel_Content();

                obj_c.logid = element.BirthdayId;
                obj_c.description = element.ErrorDescription;
                obj_c.errorpage = element.ErrorPage;
                obj_c.userid = element.ErrorUserId;
                obj_c.datetime = element.ErrorDatetime;
                obj_c.loggedip = element.BirthdaygedIp;
                obj_c.errorref = element.ErrorRef;

                BirthdayDetails.content[index] = obj_c;
            }
        })

    return BirthdayDetails;
};
