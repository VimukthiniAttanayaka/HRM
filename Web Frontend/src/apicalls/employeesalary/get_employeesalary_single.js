const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeSalaryDetail {
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
export const getEmployeeSalarySingle = async (formData) => {
  console.log(formData)
  let resw = new EmployeeSalaryDetail();
  const res = await fetch(apiUrl + 'Employeesalary/get_Employeesalary_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].EmployeeSalary[0]
      // console.log(res2)
      console.log(res1[0].EmployeeSalary[0])
      // setUserRoleDetails(res1[0].UserRole[0]);
      // handleOpenPopup()
    })

  return resw;
};