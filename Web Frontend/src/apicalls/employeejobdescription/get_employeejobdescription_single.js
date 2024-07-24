const apiUrl = process.env.REACT_APP_API_URL;

// export class UserRoleDetail {
//   constructor(id, userrole, status, Alotment) {
//     this.userrole = userrole;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class UserRoleDetail {
  EUR_UserRoleID;
  EUR_UserRole;
  EUR_Status;
  EUR_CreatedBy;
  EUR_CreatedDateTime;
  EUR_ModifiedBy;
  EUR_ModifiedDateTime;
}
// console.log(apiUrl)
export const getUserRoleSingle = async (formData) => {

  let resw = new UserRoleDetail();
  const res = await fetch(apiUrl + 'userrole/get_userrole_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].UserRole[0]
      // console.log(res2)
      console.log(res1[0].UserRole[0])
      // setUserRoleDetails(res1[0].UserRole[0]);
      // handleOpenPopup()
    })

  return resw;
};