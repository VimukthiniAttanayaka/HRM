const apiUrl = process.env.REACT_APP_API_URL;

export class DepartmentDetail {
  EUR_DepartmentID;
  EUR_Department;
  EUR_Status;
  EUR_CreatedBy;
  EUR_CreatedDateTime;
  EUR_ModifiedBy;
  EUR_ModifiedDateTime;
}

export const addNewDepartment = async (formData) => {

  let resw = new DepartmentDetail();
  const res = await fetch(apiUrl + 'Department/add_new_department', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      console.log(res1)
      // resw = res1[0].Department[0]
    })

  return resw;
};
