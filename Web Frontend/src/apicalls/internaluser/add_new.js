const apiUrl = process.env.REACT_APP_API_URL;

import ReturnResponse from '../../publicmodels/ReturnResonse'

export const addNewInternalUser = async (formData) => {
  let resw = new ReturnResponse();
  // Submit the form data to your backend API/
  const response = await fetch(apiUrl + 'InternalUser/add_new_user', {
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
  // if (response.ok) {
  //   console.log(response);
  //   // Handle successful submission (e.g., display a success message)
  //   console.log('Leave Type data submitted successfully!')
  // } else {
  //   // Handle submission errors
  //   console.error('Error submitting Leave Type data:', response.statusText)
  // }
};
