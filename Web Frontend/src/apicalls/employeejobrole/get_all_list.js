const apiUrl = process.env.REACT_APP_API_URL;

// console.log(apiUrl)
export const getEmployeeJobRoleAll = async (formData) => {
  const EmployeeJobRoleDetails = [];

  const res = await fetch(apiUrl + 'EmployeeJobRole/get_EmployeeJobRole_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class EmployeeJobRoleDetail {
        constructor(id, Employeeid, JobRoleID, JobType, Department, ActiveFrom, ActiveTo, status) {
          // this.Employeeid = Employeeid;
          this.JobRoleID = JobRoleID;
          this.ActiveFrom = ActiveFrom;
          this.ActiveTo = ActiveTo;
          this.Department = Department;
          this.JobType = JobType;
          this.id = id;
          // console.log(status)
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].EmployeeJobRole.length; index++) {
        let element = res1[0].EmployeeJobRole[index];
        // console.log(element)
        EmployeeJobRoleDetails[index] = new EmployeeJobRoleDetail(element.EEJR_ID, element.EEJR_EmployeeID, element.EEJR_JobRoleID,
          element.EEJR_JobType, element.EEJR_Department, element.EEJR_ActiveFrom, element.EEJR_ActiveTo, element.EEJR_Status);
      }
      // console.log(EmployeeJobRoleDetails)
    })

  return EmployeeJobRoleDetails;
};