const apiUrl = process.env.REACT_APP_API_URL;

export const Dropdowns_Department = async (formData) => {

  const optionsDepartment = [];
  const res = await fetch(apiUrl + 'department/get_department_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Department.length; index++) {
        const DepartmentData = {
          key: res1[0].Department[index].MDD_DepartmentID,
          value: res1[0].Department[index].MDD_Department
        };
        optionsDepartment[index] = DepartmentData
      }
      // console.log(optionsDepartment)
    })
  return optionsDepartment;
}
