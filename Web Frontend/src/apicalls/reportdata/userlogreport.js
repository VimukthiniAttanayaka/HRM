const apiUrl = process.env.REACT_APP_API_URL;
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
            UserLogDetails.CompanyTitle="DoashaIT (PVT) LTD";
            UserLogDetails.LoggedUser="Neelaka";
            UserLogDetails.PrintedDate=new Date().toLocaleDateString();

            for (let index = 0; index < res1[0].AccessGroup.length; index++) {
                let element = res1[0].AccessGroup[index];
                // console.log(element)
                let obj_c = new UserLogModel_Content();
                obj_c.id = element.UAG_AccessGroupID;
                obj_c.name = element.UAG_AccessGroup;
                obj_c.surname = element.UAG_Status;
                UserLogDetails.content[index] = obj_c;
            }
        })

    return UserLogDetails;
};
