const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeLeaveEntitlementDetail {
  EELE_ID;
  EELE_EmployeeID;
  EELE_Status;
  EELE_CreatedBy;
  EELE_CreatedDateTime;
  EELE_ModifiedBy;
  EELE_ModifiedDateTime;
  EELE_LeaveTypeID;
  EELE_Remain;
  EELE_ActiveFrom;
  EELE_ActiveTo;
  EELE_LeaveAlotment;

}
// console.log(apiUrl)
export const getEmployeeLeaveEntitlementSingle = async (formData) => {
  console.log(formData)
  let resw = new EmployeeLeaveEntitlementDetail();
  const res = await fetch(apiUrl + 'Employeeleaveentitlement/get_Employeeleaveentitlement_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].EmployeeLeaveEntitlement[0]
      // console.log(res2)
      console.log(res1[0].EmployeeLeaveEntitlement[0])
      // setUserRoleDetails(res1[0].UserRole[0]);
      // handleOpenPopup()
    })

  return resw;
};