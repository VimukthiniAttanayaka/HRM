const apiUrl = process.env.REACT_APP_API_URL;

export class LeaveScheduleDetail {
  constructor(id, JobRole, status) {
    this.JobRole = JobRole;
    this.id = id;
    if (status == true) { this.status = "Active"; }
    else { this.status = "Inactive"; }
  }
}
// console.log(apiUrl)
export const getJobRoleAll = async (formData) => {
  const JobRoleDetails = [];

  const res = await fetch(apiUrl + 'JobRole/get_JobRole_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))


      class JobRoleDetail {
        constructor(id, JobRole, status) {
          this.JobRole = JobRole;
          this.id = id;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      for (let index = 0; index < res1[0].JobRole.length; index++) {
        let element = res1[0].JobRole[index];
        // console.log(element)
        JobRoleDetails[index] = new JobRoleDetail(element.MDJR_JobRoleID, element.MDJR_JobRole, element.MDJR_Status);
      }
      // console.log(JobRoleDetails)
    })

  return JobRoleDetails;
};

export const requestdata_JobRoles_DropDowns_All = async (formData) => {

  const optionsJobRole = [];
  const res = await fetch(apiUrl + 'JobRole/get_JobRole_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].JobRole.length; index++) {
        const JobRoleData = {
          key: res1[0].JobRole[index].MDJR_JobRoleID,
          value: res1[0].JobRole[index].MDJR_JobRole
        };
        optionsJobRole[index] = JobRoleData
      }
    })
  return optionsJobRole;
}
