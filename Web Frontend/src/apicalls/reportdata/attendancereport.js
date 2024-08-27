const apiUrl = process.env.REACT_APP_API_URL;
const COMPANY_NAME = process.env.COMPANY_NAME;
const COPYRIGHT = process.env.COPYRIGHT;
import { AttendanceModel, AttendanceModel_Content, AttendanceModel_Title, AttendanceModel_Header, AttendanceModel_CopyRight } from "src/views/Report/attendancereport/data.js";

// console.log(apiUrl)
export const getAttendanceReport = async (formData) => {
    const AttendanceDetails = new AttendanceModel();

    const res = await fetch(apiUrl + 'Reports/get_AttendanceReport', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData),
    })
        .then(response => response.json())
        .then(json => {
            let res1 = JSON.parse(JSON.stringify(json))
            AttendanceDetails.CompanyTitle = " DoashaIT (PVT) LTD ";
            AttendanceDetails.LoggedUser = "Neelaka";
            AttendanceDetails.PrintedDate = new Date().toLocaleDateString();
            AttendanceDetails.Copyright = "Doashait © 2024 .";

            let obj_t = new AttendanceModel_Title();
            obj_t.LoggedUserTitle = "Logged User : ";
            obj_t.LoggedUser = "Neelaka";
            obj_t.CompanyTitle = " DoashaIT (PVT) LTD ";
            obj_t.PrintedDateTitle = "Printed Date : ";
            obj_t.PrintedDate = new Date().toLocaleDateString();

            let obj_h = new AttendanceModel_Header();
            obj_h.ReportTitle = "User Log Report";

            let obj_c = new AttendanceModel_CopyRight();
            obj_c.Copyright = "Doashait © 2024 .";

            AttendanceDetails.titlelist[0] = obj_t;
            AttendanceDetails.headerlist[0] = obj_h;
            AttendanceDetails.copyrightlist[0] = obj_c;

            for (let index = 0; index < res1[0].Attendance.length; index++) {
                let element = res1[0].Attendance[index];
                // console.log(element)
                let obj_c = new AttendanceModel_Content();
                obj_c.action = element.Action;
                obj_c.description = element.Description;
                obj_c.createdBy = element.CreatedBy;
                obj_c.clientIP = element.ClientIP;
                obj_c.createdDateTime = element.CreatedDateTime;
                obj_c.sequenceNo = element.SequenceNo;
                obj_c.module = element.Module;
                obj_c.controler = element.Controler;
                obj_c.actionType = element.ActionType;
                obj_c.actionMap_ID = element.ActionMap_ID;

                AttendanceDetails.content[index] = obj_c;
            }
        })

    return AttendanceDetails;
};
