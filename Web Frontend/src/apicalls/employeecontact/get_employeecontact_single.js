const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeContactDetail {
  EEJR_ID; EEJR_EmployeeID; EEJR_ContactID; EEJR_ActiveFrom; EEJR_ActiveTo; 
  EEJR_Status; EEJR_CreatedBy; EEJR_CreatedDateTime; EEJR_ModifiedBy; EEJR_ModifiedDateTime; EEJR_Remarks;

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