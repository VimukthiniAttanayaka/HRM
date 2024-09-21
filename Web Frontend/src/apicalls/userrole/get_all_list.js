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
        UserRoleDetails[index] = new UserRoleDetail(element.UUR_UserRoleID, element.UUR_UserRole, element.UUR_Status);
      }
      // console.log(UserRoleDetails)
    })

  return UserRoleDetails;
};


export const getAccessGroupListForUserRole = async (formData) => {
  const AccessGroupDetails = [];
  // console.log(formData)
  const res = await fetch(apiUrl + 'userrole/get_AccessGroup_all_ForUserRole', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class AccessGroupDetail {
        constructor(id, accessgroup, status) {
         this.id = id;
          this.accessgroup = accessgroup;          
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].AccessGroup.length; index++) {
        let element = res1[0].AccessGroup[index];
        // console.log(element)
        AccessGroupDetails[index] = new AccessGroupDetail(element.UAG_AccessGroupID, element.UAG_AccessGroup, element.UAG_Status);
      }
      // console.log(AccessGroupDetails)
    })

  return AccessGroupDetails;
};
