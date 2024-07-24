const apiUrl = process.env.REACT_APP_API_URL;

export  class EmployeeJobDescriptionDetail {
  constructor(id, Employeeid,departmentid,jobdescriptionid, status) {
    this.Employeeid = Employeeid;
    this.departmentid = departmentid;
    this.jobdescriptionid =jobdescriptionid;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getEmployeeJobDescriptionAll = async (formData) => {
  const EmployeeJobDescriptionDetails = [];

  const res = await fetch(apiUrl + 'EmployeeJobDescription/get_EmployeeJobDescription_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class EmployeeJobDescriptionDetail {
        constructor(id, Employeeid,departmentid,jobdescriptionid, status) {
          this.Employeeid = Employeeid;
          this.departmentid = departmentid;
          this.jobdescriptionid =jobdescriptionid;
          this.id = id;
          // console.log(status)
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].EmployeeJobDescription.length; index++) {
        let element = res1[0].EmployeeJobDescription[index];
        // console.log(element)
        EmployeeJobDescriptionDetails[index] = new EmployeeJobDescriptionDetail(element.EEJ_EmployeeJobDescriptionID,
           element.EEJ_EmployeeID,element.EEJ_DepartmentID,element.EEJ_JobDescriptionID, element.EEJ_Status);
      }
      // console.log(EmployeeJobDescriptionDetails)
    })

  return EmployeeJobDescriptionDetails;
};

export const requestdata_EmployeeJobDescriptions_DropDowns_All = async (formData) => {

  const optionsEmployeeJobDescription = [];
  const res = await fetch(apiUrl + 'EmployeeJobDescription/get_EmployeeJobDescription_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      // for (let index = 0; index < res1[0].EmployeeJobDescription.length; index++) {
      //   const EmployeeJobDescriptionData = {
      //     key: res1[0].EmployeeJobDescription[index].EEJ_EmployeeJobDescriptionID,
      //     value: res1[0].EmployeeJobDescription[index].EEJ_EmployeeJobDescription
      //   };
      //   optionsEmployeeJobDescription[index] = EmployeeJobDescriptionData
      // }
    })
  return optionsEmployeeJobDescription;
}
