const apiUrl = process.env.REACT_APP_API_URL;

// export class UserAccessGroupDetail {
//   constructor(UserAccessGroupID, MenuAccessID, status, UserName) {
//     this.UserAccessGroupID = UserAccessGroupID;
//     this.MenuAccessID = MenuAccessID;
//     this.UserName = UserName;
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
// console.log(apiUrl)
export const getUserAccessGroupAll = async (formData) => {
  const UserAccessGroupDetails = [];

  const res = await fetch(apiUrl + 'UserRoleAccessGroup/get_UserRoleAccessGroup_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)

      class UserAccessGroupDetail {
        constructor(UserAccessGroupID, MenuAccessID, status, UserName) {
          this.UserAccessGroupID = UserAccessGroupID;
          this.MenuAccessID = MenuAccessID;
          this.UserName = UserName;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].UserRoleAccessGroup.length; index++) {
        let element = res1[0].UserRoleAccessGroup[index];
        // console.log(element)
        UserAccessGroupDetails[index] = new UserAccessGroupDetail(element.UUAG_UserAccessGroupID, element.UUAG_MenuAccessID, element.UUAG_Status, element.UUAG_UserName);
      }
      // console.log(UserAccessGroupDetails)
    })
  // console.log(UserAccessGroupDetails)
  return UserAccessGroupDetails;
};

// export const requestdata_UserAccessGroup_DropDowns_All = async (formData) => {

//   const optionsUserAccessGroup = [];
//   const res = await fetch(apiUrl + 'UserAccessGroup/get_UserAccessGroup_all', {
//     method: 'POST',
//     headers: { 'Content-Type': 'application/json' },
//     body: JSON.stringify(formData),
//   })
//     .then(response => response.json())
//     .then(json => {
//       let res1 = JSON.parse(JSON.stringify(json))

//       for (let index = 0; index < res1[0].UserAccessGroup.length; index++) {
//         const UserAccessGroupData = {
//           key: res1[0].UserAccessGroup[index].USR_UserAccessGroupID,
//           value: res1[0].UserAccessGroup[index].USR_PrefferedName
//         };
//         optionsUserAccessGroup[index] = UserAccessGroupData
//       }
//       console.log(optionsUserAccessGroup)
//     })
//   return optionsUserAccessGroup;
// }