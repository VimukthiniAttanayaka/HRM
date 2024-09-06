const apiUrl = process.env.REACT_APP_API_URL;

export class EmployeeDetail {
  constructor(EME_EmployeeID,
    EME_FirstName,
    EME_LastName,
    EME_EmployeeType,
    EME_PrefferedName,
    EME_ReportingManager,
    EME_MobileNumber,
    EME_Status) {

    this.id = EME_EmployeeID;
    this.FirstName = EME_FirstName;
    this.LastName = EME_LastName;
    this.EmployeeType = EME_EmployeeType;
    this.PrefferedName = EME_PrefferedName;
    this.ReportingManager = EME_ReportingManager;
    this.MobileNumber = EME_MobileNumber;
    if (EME_Status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}

// console.log(apiUrl)
export const getEmployeeAll = async (formData) => {
  const EmployeeDetails = [];

  const res = await fetch(apiUrl + 'employee/get_employee_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
 
      for (let index = 0; index < res1[0].Employee.length; index++) {
        let element = res1[0].Employee[index];
        // console.log(element)
        EmployeeDetails[index] = new EmployeeDetail(
          element.EME_EmployeeID,
          element.EME_FirstName,
          element.EME_LastName,
          element.EME_EmployeeType,
          element.EME_PrefferedName,
          element.EME_ReportingManager,
          element.EME_MobileNumber,
          element.EME_Status);
      }
      // console.log(EmployeeDetails)
    })

  return EmployeeDetails;
};

export const requestdata_Employee_DropDowns_All = async (formData) => {

  const optionsEmployee = [];
  const res = await fetch(apiUrl + 'employee/get_employee_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Employee.length; index++) {
        const EmployeeData = {
          key: res1[0].Employee[index].USR_EmployeeID,
          value: res1[0].Employee[index].USR_PrefferedName
        };
        optionsEmployee[index] = EmployeeData
      }
      console.log(optionsEmployee)
    })
  return optionsEmployee;
}
