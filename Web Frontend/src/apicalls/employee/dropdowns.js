const apiUrl = process.env.REACT_APP_API_URL;

export const Dropdowns_Employee = async (formData) => {

  const optionsEmployee = [];
  const res = await fetch(apiUrl + 'employee/get_employee_all', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))

      for (let index = 0; index < res1[0].Employee.length; index++) {
        const EmployeeData = {
          key: res1[0].Employee[index].EME_EmployeeID,
          value: res1[0].Employee[index].EME_PrefferedName
        };
        optionsEmployee[index] = EmployeeData
      }
    })
  return optionsEmployee;
}
