const apiUrl = process.env.REACT_APP_API_URL;

// export class LeaveScheduleDetail {
//   constructor(id, userrole, status, Alotment) {
//     this.userrole = userrole;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class LeaveScheduleDetail  {
  LVT_UserRoleID;
  LVT_UserRole;
  LVT_Status;
  LVT_CreatedBy;
  LVT_CreatedDateTime;
  LVT_ModifiedBy;
  LVT_ModifiedDateTime;
}
// console.log(apiUrl)
export const getUserRoleSingle = async (formData) => {
   
  let resw=new LeaveScheduleDetail();
  const res = await fetch(apiUrl + 'userrole/get_userrole_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
  .then(response => response.json())
  .then(json => {
    let res1 = JSON.parse(JSON.stringify(json))
    resw=res1[0].UserRole[0]
    // console.log(res2)
    // console.log(res1[0].UserRole[0])
    // setUserRoleDetails(res1[0].UserRole[0]);
    // handleOpenPopup()
  })
    
    return resw;
};