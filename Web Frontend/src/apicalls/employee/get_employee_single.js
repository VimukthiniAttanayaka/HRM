const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeDetail {
  EME_CustomerID;
  EME_DepartmentID;
  EME_EmployeeID;
  EME_FirstName;
  EME_LastName;
  EME_Gender;
  EME_MaritalStatus;
  EME_Nationality;
  EME_BloodGroup;
  EME_NIC;
  EME_Passport;
  EME_DrivingLicense;
  EME_PrefferedName;
  EME_JobTitle_Code;
  EME_ReportingManager;
  EME_EmployeeType;
  EME_PayeeTaxNumber;
  EME_Salary;
  EME_Address;
  EME_EmailAddress;
  EME_MobileNumber;
  EME_PhoneNumber1;
  EME_PhoneNumber2;
  EME_DateOfHire;
  EME_Status;
  EME_DateOfBirth;
}
// console.log(apiUrl)
export const getEmployeeSingle = async (formData) => {
  console.log(formData)
  let resw=new EmployeeDetail();
  const res = await fetch(apiUrl + 'employee/get_employee_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
  .then(response => response.json())
  .then(json => {
    let res1 = JSON.parse(JSON.stringify(json))
    resw=res1[0].Employee[0]
    // console.log(res2)
    // console.log(res1[0].Employee[0])
    // setLeaveTypeDetails(res1[0].LeaveType[0]);
    // handleOpenPopup()
  })

    return resw;
};
