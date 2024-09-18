const apiUrl = process.env.REACT_APP_API_URL;

export class ExternalUserDetail {
  UE_UserID; UE_FirstName; UE_LastName; UE_EmailAddress; UE_MobileNumber; UE_PhoneNumber; UE_Remarks; UE_ActiveFrom; UE_ActiveTo; UE_Status; UE_Pwd; UE_PwdSalt; UE_PwdLastResetDateTime; UE_CreatedBy;
  UE_CreatedDateTime; UE_ModifiedBy; UE_ModifiedDateTime; UE_Otp; UE_Otp_Generate_On;
  authorizationToken;
}

// console.log(apiUrl)
export const getExternalUserSingle = async (formData) => {

  let resw = new ExternalUserDetail();
  const res = await fetch(apiUrl + 'externaluser/get_user_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      // console.log(JSON.stringify(json))
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].User[0]
      // console.log(res2)
      // console.log(res1[0].LeaveType[0])
      // setExternalUserDetails(res1[0].User[0]);
      // handleOpenPopup()
    })

  return resw;
};