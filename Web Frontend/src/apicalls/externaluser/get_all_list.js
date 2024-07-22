const apiUrl = process.env.REACT_APP_API_URL;

export class ExternalUserList {
  constructor(EmployeeID,
    FirstName,
    LastName,
    EmailAddress,
    MobileNumber,
    PhoneNumber,
    Remarks,
    UserName,
    Status) {
    this.EmployeeID = EmployeeID;
    this.FirstName = FirstName;
    this.LastName = LastName;
    this.EmailAddress = EmailAddress;
    this.MobileNumber = MobileNumber;
    this.PhoneNumber = PhoneNumber;
    this.Remarks = Remarks;
    this.UserName = UserName;
    // console.log(UserName)
    if (Status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getExternalUserAll = async (formData) => {
  const ExternalUserDetails = [];

  const res = await fetch(apiUrl + 'internaluser/get_user_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      // class ExternalUserDetail {
        // constructor(id, leavetype, status, Alotment) {
        //   this.leavetype = leavetype;
        //   this.id = id;
        //   this.alotment = Alotment
        //   if (status == true) { this.status = "Active"; }
        //   else { this.status = "Inactive"; }
        // }
      // }

      for (let index = 0; index < res1[0].User.length; index++) {
        let element = res1[0].User[index];
        // console.log(element)
        ExternalUserDetails[index] = new ExternalUserList(
          element.UD_EmployeeID,
          element.UD_FirstName,
          element.UD_LastName,
          element.UD_EmailAddress,
          element.UD_MobileNumber,
          element.UD_PhoneNumber,
          element.UD_Remarks,
          element.UD_UserName,
          element.UD_Status);
      }
      // console.log(ExternalUserDetails)
    })

  return ExternalUserDetails;
};

export const requestdata_LeaveTypes_DropDowns_All = async (formData) => {

  const optionsUserData = [];
  const res = await fetch(apiUrl + 'internaluser/get_user_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].User.length; index++) {
        const UserData = {
          key: res1[0].User[index].UD_UserName,
          value:res1[0].User[index].UD_FirstName+" "+ res1[0].User[index].UD_LastName
        };
        optionsUserData[index] = UserData
      }
      // console.log(optionsLeaveType)
    })
  return optionsUserData;
}