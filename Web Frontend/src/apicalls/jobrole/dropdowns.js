const apiUrl = process.env.REACT_APP_API_URL;

export const Dropdowns_JobRole = async (formData) => {

  const optionsJobRole = [];
  const res = await fetch(apiUrl + 'jobrole/get_jobrole_all', {
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
