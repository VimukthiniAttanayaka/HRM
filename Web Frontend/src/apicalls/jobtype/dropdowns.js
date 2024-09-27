const apiUrl = process.env.REACT_APP_API_URL;

export const Dropdowns_JobType = async (formData) => {

  const optionsJobType = [];
  const res = await fetch(apiUrl + 'jobtype/get_jobtype_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      // console.log(res1)
      for (let index = 0; index < res1[0].JobType.length; index++) {
        const JobTypeData = {
          key: res1[0].JobType[index].MDJT_JobTypeID,
          value: res1[0].JobType[index].MDJT_JobType
        };
        optionsJobType[index] = JobTypeData
      }

    })
  return optionsJobType;
}
