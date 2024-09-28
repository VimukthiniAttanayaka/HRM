const apiUrl = process.env.REACT_APP_API_URL;

// console.log(apiUrl)
export const getEmployeeSalaryAll = async (formData) => {
  const EmployeeSalaryDetails = [];

  const res = await fetch(apiUrl + 'EmployeeSalary/get_EmployeeSalary_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class EmployeeSalaryDetail {
        constructor(id, EmployeeID,
          Salary,
          ActiveFrom,
          ActiveTo,
          SalaryType,
          status) {
          this.EmployeeID = EmployeeID;
          this.Salary = Salary;
          this.ActiveFrom = ActiveFrom;
          this.ActiveTo = ActiveTo;
          this.SalaryType = SalaryType;
          this.id = id;
          // console.log(status)
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].EmployeeSalary.length; index++) {
        let element = res1[0].EmployeeSalary[index];
        // console.log(element)
        EmployeeSalaryDetails[index] = new EmployeeSalaryDetail(element.EES_ID,
          element.EES_EmployeeID,
          element.EES_Salary,
          element.EES_ActiveFrom,
          element.EES_ActiveTo,
          element.EES_SalaryType,
          element.EES_Status);
      }
      // console.log(EmployeeSalaryDetails)
    })

  return EmployeeSalaryDetails;
};