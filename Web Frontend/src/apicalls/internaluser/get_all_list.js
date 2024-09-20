const apiUrl = process.env.REACT_APP_API_URL;

export class InternalUserDetail {
  constructor(EmployeeID,
    UserID,
    FirstName,
    LastName,
    EmailAddress,
    MobileNumber,
    PhoneNumber,
    Remarks,ActiveFrom,ActiveTo,
    Status) {
    this.EmployeeID = EmployeeID;
    this.FirstName = FirstName;
    this.LastName = LastName;
    this.EmailAddress = EmailAddress;
    this.MobileNumber = MobileNumber;
    this.PhoneNumber = PhoneNumber;
    this.Remarks = Remarks;
    this.UserID = UserID;
    this.ActiveFrom = ActiveFrom;
    this.ActiveTo = ActiveTo;
    
    // console.log(Status)
    if (Status === true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getInternalUserAll = async (formData) => {
  const InternalUserDetails = [];

  const res = await fetch(apiUrl + 'internaluser/get_user_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].User.length; index++) {
        let element = res1[0].User[index];
        console.log(element)
        InternalUserDetails[index] = new InternalUserDetail(
          element.UE_EmployeeID,
          element.UE_UserID, element.UE_FirstName, element.UE_LastName, element.UE_EmailAddress,
          element.UE_MobileNumber, element.UE_PhoneNumber, element.UE_Remarks, element.UE_ActiveFrom,
           element.UE_ActiveTo, element.UE_Status);
      }
      console.log(InternalUserDetails)
    })

  return InternalUserDetails;
};
