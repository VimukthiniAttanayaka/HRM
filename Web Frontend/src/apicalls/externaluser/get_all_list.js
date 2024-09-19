const apiUrl = process.env.REACT_APP_API_URL;

export class ExternalUserList {
  constructor(UserID, FirstName, LastName, EmailAddress,
    MobileNumber, PhoneNumber, Remarks, ActiveFrom, ActiveTo,
    Status) {
    this.UserID = UserID;
    this.FirstName = FirstName;
    this.LastName = LastName;
    this.EmailAddress = EmailAddress;
    this.MobileNumber = MobileNumber;
    this.PhoneNumber = PhoneNumber;
    this.Remarks = Remarks;
    this.ActiveFrom = ActiveFrom;
    this.ActiveTo = ActiveTo;

    if (Status === true) { this.status = "Active"; }
    else { this.status = "Inactive"; console.log(Status + 1) }
  }
}

// console.log(apiUrl)
export const getExternalUserAll = async (formData) => {
  const ExternalUserDetails = [];

  const res = await fetch(apiUrl + 'externaluser/get_user_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].User.length; index++) {
        let element = res1[0].User[index];
        // console.log(element)
        ExternalUserDetails[index] = new ExternalUserList(
          element.UE_UserID, element.UE_FirstName, element.UE_LastName, element.UE_EmailAddress,
          element.UE_MobileNumber, element.UE_PhoneNumber, element.UE_Remarks, element.UE_ActiveFrom,
          element.UE_ActiveTo, element.UE_Status);
      }
      // console.log(ExternalUserDetails)
    })

  return ExternalUserDetails;
};
