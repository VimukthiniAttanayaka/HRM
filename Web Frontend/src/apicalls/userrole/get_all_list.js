const apiUrl = process.env.REACT_APP_API_URL;

export class UserRoleDetail {
  constructor(id, userrole, status) {
    this.id = id;
    this.userrole = userrole;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}

// console.log(apiUrl)
export const getUserRoleAll = async (formData) => {
  const UserRoleDetails = [];

  const res = await fetch(apiUrl + 'userrole/get_userrole_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
         
      for (let index = 0; index < res1[0].UserRole.length; index++) {
        let element = res1[0].UserRole[index];
        // console.log(element)
        UserRoleDetails[index] = new UserRoleDetail(element.EUR_UserRoleID, element.EUR_UserRole, element.EUR_Status);
      }
      // console.log(UserRoleDetails)
    })

  return UserRoleDetails;
};