const apiUrl = process.env.REACT_APP_API_URL;

import ReturnResponse from '../../publicmodels/ReturnResonse'

export const addNewEmployeeTermination = async (formData) => {
  let resw = new ReturnResponse();
  // Submit the form data to your backend API/
  const response = await fetch(apiUrl + 'employeeTermination/add_new_employeeTermination', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
  .then(response => response.json())
  .then(json => {

    let res1 = JSON.parse(JSON.stringify(json))
    resw = res1[0]
    console.log(resw)

    // alert(resw.msg)
  })

return resw;
};