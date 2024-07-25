const apiUrl = process.env.REACT_APP_API_URL;

export class DepartmentDetail {
  constructor(id, Department, status) {
    this.Department = Department;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getDepartmentAll = async (formData) => {
  const DepartmentDetails = [];

  const res = await fetch(apiUrl + 'Department/get_Department_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class DepartmentDetail {
        constructor(id, Department, status) {
          this.Department = Department;
          this.id = id;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].Department.length; index++) {
        let element = res1[0].Department[index];
        // console.log(element)
        DepartmentDetails[index] = new DepartmentDetail(element.EUR_DepartmentID, element.EUR_Department, element.EUR_Status);
      }
      // console.log(DepartmentDetails)
    })

  return DepartmentDetails;
};

export const requestdata_Departments_DropDowns_All = async (formData) => {

  const optionsDepartment = [];
  const res = await fetch(apiUrl + 'Department/get_Department_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Department.length; index++) {
        const DepartmentData = {
          key: res1[0].Department[index].EUR_DepartmentID,
          value: res1[0].Department[index].EUR_Department
        };
        optionsDepartment[index] = DepartmentData
      }
    })
  return optionsDepartment;
}
