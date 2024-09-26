const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeContactDetail {
  EEC_ID;
  EEC_EmployeeID;
  EEC_Address;
  EEC_EmailAddress;
  EEC_MobileNumber;
  EEC_Status;
  EEC_Remarks;
  EEC_PhoneNumber1;
  EEC_PhoneNumber2;
}
// console.log(apiUrl)
export const getEmployeeContactSingle = async (formData) => {
  console.log(formData)
  let resw = new EmployeeContactDetail();
  const res = await fetch(apiUrl + 'Employeecontact/get_Employeecontact_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].EmployeeContact[0]
      // console.log(res2)
      console.log(res1[0].EmployeeContact[0])
      // setUserRoleDetails(res1[0].UserRole[0]);
      // handleOpenPopup()
    })

  return resw;
};