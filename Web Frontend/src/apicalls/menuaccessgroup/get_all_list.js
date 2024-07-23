const apiUrl = process.env.REACT_APP_API_URL;

// export class MenuAccessGroupDetail {
//   constructor(id, leavetype, status, Alotment) {
//     this.leavetype = leavetype;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
// console.log(apiUrl)
export const getMenuAccessGroupAll = async (formData) => {
  const MenuAccessGroupDetails = [];

  const res = await fetch(apiUrl + 'MenuAccessGroup/get_MenuAccessGroup_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class MenuAccessGroupDetail {
        constructor(MenuAccessID, AccessGroupID, status, UserMenuID) {
          this.MenuAccessID = MenuAccessID;
          this.AccessGroupID = AccessGroupID;
          this.UserMenuID = UserMenuID;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].MenuAccessGroup.length; index++) {
        let element = res1[0].MenuAccessGroup[index];
        // console.log(element)
        MenuAccessGroupDetails[index] = new MenuAccessGroupDetail(element.UMA_MenuAccessID, element.UMA_AccessGroupID, element.UMA_Status, element.UMA_UserMenuID);
      }
      // console.log(LeaveTypeDetails)
    })

  return MenuAccessGroupDetails;
};

// export const requestdata_Employee_DropDowns_All = async (formData) => {

//   const optionsEmployee = [];
//   const res = await fetch(apiUrl + 'employee/get_employee_all', {
//     method: 'POST',
//     headers: { 'Content-Type': 'application/json' },
//     body: JSON.stringify(formData),
//   })
//     .then(response => response.json())
//     .then(json => {
//       let res1 = JSON.parse(JSON.stringify(json))

//       for (let index = 0; index < res1[0].Employee.length; index++) {
//         const EmployeeData = {
//           key: res1[0].Employee[index].USR_EmployeeID,
//           value: res1[0].Employee[index].USR_PrefferedName
//         };
//         optionsEmployee[index] = EmployeeData
//       }
//       console.log(optionsEmployee)
//     })
//   return optionsEmployee;
// }