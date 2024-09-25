const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeJobRoleDetail {
  EEJR_ID; EEJR_EmployeeID; EEJR_JobRoleID; EEJR_ActiveFrom; EEJR_ActiveTo; 
  EEJR_Status; EEJR_CreatedBy; EEJR_CreatedDateTime; EEJR_ModifiedBy; EEJR_ModifiedDateTime; EEJR_Remarks;

}
// console.log(apiUrl)
export const getEmployeeJobRoleSingle = async (formData) => {
console.log(formData)
  let resw = new EmployeeJobRoleDetail();
  const res = await fetch(apiUrl + 'Employeejobrole/get_Employeejobrole_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].EmployeeJobRole[0]
      // console.log(res2)
      console.log(res1[0].EmployeeJobRole[0])
      // setUserRoleDetails(res1[0].UserRole[0]);
      // handleOpenPopup()
    })

  return resw;
};