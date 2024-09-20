const apiUrl = process.env.REACT_APP_API_URL;

import ReturnResponse from '../../publicmodels/ReturnResonse'

export const addNewCustomer = async (formData) => {

  let resw = new ReturnResponse();
  const res = await fetch(apiUrl + 'Customer/add_new_customer', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
    .then(response => response.json())
    .then(json => {
      let res1 = JSON.parse(JSON.stringify(json))
      resw = res1[0]
       console.log(res1)
    })

  return resw;
};
