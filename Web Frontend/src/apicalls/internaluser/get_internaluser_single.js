const apiUrl = process.env.REACT_APP_API_URL;

// export class LeaveScheduleDetail {
//   constructor(id, leavetype, status, Alotment) {
//     this.leavetype = leavetype;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class InternalUserDetail {
  UD_EmployeeID;
  UD_FirstName;
  UD_LastName;
  UD_EmailAddress;
  UD_MobileNumber;
  UD_PhoneNumber;
  UD_Remarks;
  authorizationToken;
  UD_UserName;
  UD_Status;
}

// console.log(apiUrl)
export const getInternalUserSingle = async (formData) => {

  let resw = new InternalUserDetail();
  const res = await fetch(apiUrl + 'internaluser/get_user_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // resw = res1[0].LeaveType[0]
      // console.log(res2)
      // console.log(res1[0].LeaveType[0])
      // setLeaveTypeDetails(res1[0].LeaveType[0]);
      // handleOpenPopup()
    })

  return resw;
};