const apiUrl = process.env.REACT_APP_API_URL;

export class UserRoleDetail {
  UUM_UserRoleID;
  UUM_UserRole;
  UUM_Status;
  UUM_CreatedBy;
  UUM_CreatedDateTime;
  UUM_ModifiedBy;
  UUM_ModifiedDateTime;
}
// console.log(apiUrl)
export const getUserRoleSingle = async (formData) => {

  let resw = new UserRoleDetail();
  const res = await fetch(apiUrl + 'userrole/get_UserRole_single', {
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