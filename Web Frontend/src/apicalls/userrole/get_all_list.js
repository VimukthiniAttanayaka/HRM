const apiUrl = process.env.REACT_APP_API_URL;

export class LeaveScheduleDetail {
  constructor(id, userrole, status, Alotment) {
    this.userrole = userrole;
    this.id = id;
    this.alotment = Alotment
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


      class UserRoleDetail {
        constructor(id, userrole, status, Alotment) {
          this.userrole = userrole;
          this.id = id;
          this.alotment = Alotment
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].UserRole.length; index++) {
        let element = res1[0].UserRole[index];
        // console.log(element)
        UserRoleDetails[index] = new UserRoleDetail(element.LVT_UserRoleID, element.LVT_UserRole, element.LVT_Status, element.LVT_LeaveAlotment);
      }
      // console.log(UserRoleDetails)
    })

  return UserRoleDetails;
};

export const requestdata_UserRoles_DropDowns_All = async (formData) => {

  const optionsUserRole = [];
  const res = await fetch(apiUrl + 'userrole/get_userrole_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].UserRole.length; index++) {
        const UserRoleData = {
          key: res1[0].UserRole[index].LVT_UserRoleID,
          value: res1[0].UserRole[index].LVT_UserRole
        };
        optionsUserRole[index] = UserRoleData
      }
      // console.log(optionsUserRole)
    })
  return optionsUserRole;
}