const apiUrl = process.env.REACT_APP_API_URL;

// console.log(apiUrl)
export const getJobTypeAll = async (formData) => {
  const JobTypeDetails = [];
  // class JobHeader {
  //   constructor() { }
  //   // constructor(RC, Data) { RC = RC; Data = Data; }
  // }
  // const JobHeaders = new JobHeader();

  const res = await fetch(apiUrl + 'JobType/get_JobType_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
// console.log(res1);

      class JobTypeDetail {
        constructor(id, JobType, status) {
          this.JobType = JobType;
          this.id = id;
          if (status == true) { this.status = "Active"; }
          else { this.status = "Inactive"; }
        }
      }

      let RC = res1[0].RC;
      // console.log(RC);
      for (let index = 0; index < res1[0].JobType.length; index++) {
        let element = res1[0].JobType[index];
        // console.log(element)
        JobTypeDetails[index] = new JobTypeDetail(element.MDJT_JobTypeID, element.MDJT_JobType, element.MDJT_Status);
      }
      // JobHeaders.RC=RC;
      // JobHeaders.Data=JobTypeDetails;
      // console.log(JobTypeDetails)
    })

  return JobTypeDetails;// JobTypeDetails;
};