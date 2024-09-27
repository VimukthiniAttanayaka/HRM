const apiUrl = process.env.REACT_APP_API_URL;

// export class JobTypeDetail {
//   constructor(id, JobType, status, Alotment) {
//     this.JobType = JobType;
//     this.id = id;
//     this.alotment = Alotment
//     if (status == true) { this.status = "Active"; }
//     else { this.status = "Inactive"; }
//   }
// }
export class JobTypeDetail {
  MDJT_JobTypeID;
  MDJT_JobType;
  MDJT_Description;
  MDJT_Status;
  MDJT_CreatedBy;
  MDJT_CreatedDateTime;
  MDJT_ModifiedBy;
  MDJT_ModifiedDateTime;
}
// console.log(apiUrl)
export const getJobTypeSingle = async (formData) => {

  let resw = new JobTypeDetail();
  const res = await fetch(apiUrl + 'JobType/get_JobType_single', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0].JobType[0]
      // console.log(res2)
      // console.log(res1[0].JobType[0])
      // setJobTypeDetails(res1[0].JobType[0]);
      // handleOpenPopup()
    })

  return resw;
};
