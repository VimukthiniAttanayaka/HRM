const apiUrl = process.env.REACT_APP_API_URL;
import { toast } from 'react-toastify';

import ReturnResponse from '../../publicmodels/ReturnResonse'

export const modifyExternalUser = async (formData) => {
  let resw = new ReturnResponse();
  console.log(formData)
  // Submit the form data to your backend API/
  const response = await fetch(apiUrl + 'ExternalUser/modify_user', {
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
  //   console.log('External User data submitted successfully!')
  // } else {
  //   // Handle submission errors
  //   console.error('Error submitting External User data:', response.statusText)
  // }
};
