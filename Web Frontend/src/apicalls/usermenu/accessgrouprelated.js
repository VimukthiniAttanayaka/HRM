
const apiUrl = process.env.REACT_APP_API_URL;
import { toast } from 'react-toastify';

import ReturnResponse from '../../publicmodels/ReturnResonse'

export const GrantAccessUserMenu = async (formData) => {
    let resw = new ReturnResponse();
    console.log(formData)
    // Submit the form data to your backend API/
    const response = await fetch(apiUrl + 'UserMenu/GrantAccess', {
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
  

  export const RemoveAccessUserMenu = async (formData) => {
    let resw = new ReturnResponse();
    console.log(formData)
    // Submit the form data to your backend API/
    const response = await fetch(apiUrl + 'UserMenu/RemoveAccess', {
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