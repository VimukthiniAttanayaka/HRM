const apiUrl = process.env.REACT_APP_API_URL;
const COMPANY_NAME = process.env.COMPANY_NAME;
const COPYRIGHT = process.env.COPYRIGHT;
import { AuditLogModel, AuditLogModel_Content } from "src/views/logreports/auditlog/data";

// console.log(apiUrl)
export const getAuditLogReport = async (formData) => {
    const AuditLogDetails = new AuditLogModel();

    const res = await fetch(apiUrl + 'LogReports/get_auditLogReport', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData),
    })
        .then(response => response.json())
        .then(json => {
            let res1 = JSON.parse(JSON.stringify(json))
            AuditLogDetails.CompanyTitle = COMPANY_NAME;
            AuditLogDetails.LoggedAudit = "Neelaka";
            AuditLogDetails.PrintedDate = new Date().toLocaleDateString();
            AuditLogDetails.Copyright = COPYRIGHT;

            for (let index = 0; index < res1[0].AuditLog.length; index++) {
                let element = res1[0].AuditLog[index];
                // console.log(element)
                let obj_c = new AuditLogModel_Content();
                obj_c.id = element.AuditLogId;
                obj_c.Auditid = element.AuditID;
                obj_c.Auditname = element.AuditName;
                obj_c.LoggedDateTime = element.LoggedDateTime;
                obj_c.AuditLogOffTime = element.LoggedDateTime;
                AuditLogDetails.content[index] = obj_c;
            }
        })

    return AuditLogDetails;
};
