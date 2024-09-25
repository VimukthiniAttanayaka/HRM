const apiUrl = process.env.REACT_APP_API_URL;

// export class JobRoleDetail {
//   constructor(id, JobRole, status, Alotment) {
//     this.JobRole = JobRole;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class JobRoleDetail {
  MDJR_JobRoleID;
  MDJR_JobRole;
  MDJR_Description;
  MDJR_Status;
  MDJR_CreatedBy;
  MDJR_CreatedDateTime;
  MDJR_ModifiedBy;
  MDJR_ModifiedDateTime;
}
// console.log(apiUrl)
export const getJobRoleSingle = async (formData) => {

  let resw = new JobRoleDetail();
  const res = await fetch(apiUrl + 'JobRole/get_JobRole_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].JobRole[0]
      // console.log(res2)
      // console.log(res1[0].JobRole[0])
      // setJobRoleDetails(res1[0].JobRole[0]);
      // handleOpenPopup()
    })

  return resw;
};
