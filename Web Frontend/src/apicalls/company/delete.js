const apiUrl = process.env.REACT_APP_API_URL;

export const deleteCustomer = async (formData) => {

  const response = await fetch(apiUrl + 'Customer/inactivate_customer', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })
  .then(response => response.json())
  .then(json => {

    let res1 = JSON.parse(JSON.stringify(json))
    resw = res1[0]
    console.log(resw)
  })

return resw;
};
