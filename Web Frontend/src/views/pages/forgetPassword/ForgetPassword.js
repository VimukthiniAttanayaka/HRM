import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import {
  CButton,
  CCard,
  CCardBody,
  CCardGroup,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
} from '@coreui/react-pro'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import { setMenu } from '../../../menuActivation'

const ForgetPassword = () => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [menuLIst, setMenuList] = useState([]);

  class UserMenuDetail {
    constructor(active, menuName) {
      this.active = active;
      this.menuName = menuName
    }
  }

  const handleSubmit = async (event) => {

    const formData = {
      username: userName,
      password: password
    }
    // Submit the form data to your backend API
    const res = await fetch(apiUrl + 'login/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
        console.log(res1.user[0].UserAccessList);
        for (let index = 0; index < res1.user[0].UserAccessList.length; index++) {
          let element = res1.user[0].UserAccessList[index];
          // console.log(element)
          setMenuList[index] = new UserMenuDetail(element.MNU_Active, element.MNU_MenuName);
        }

        localStorage.setItem('token', res1.user[0].UD_AuthorizationToken)
        localStorage.setItem('staff_id', 'res1.user[0].UD_AuthorizationToken')
        localStorage.setItem('customer_id', 'cus1')

        const courses = [
          { name: "HRM_employee", active: true },
          { name: "HRM_customer", active: true },
          { name: "HRM_user", active: false },
          { name: "Attendance", active: true },
        ];
        setMenu(courses);
        console.log(menuLIst);
      })

    // if (response.ok) {

    // Handle successful submission (e.g., display a success message)
    //   console.log('Customer data submitted successfully!')
    // } else {
    //   // Handle submission errors
    //   console.error('Error submitting customer data:', response.statusText)
    // }
  }

  return (
    <div className="bg-body-tertiary min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center p-4">
          <CCol md={8}>
            <CCardGroup>
              <CCard className="p-4">
                <CCardBody>
                  <CForm onSubmit={handleSubmit}>
                    <h1>Forget Password</h1>
                    <p className="text-body-secondary">Sign In to your account</p>
                    <CInputGroup className="mb-3">
                      <CInputGroupText>
                        <CIcon icon={cilUser} />
                      </CInputGroupText>
                      <CFormInput placeholder="Username" autoComplete="username" value={userName} onChange={(e) => setUserName(e.target.value)} />
                    </CInputGroup>
                    <CInputGroup className="mb-4">
                      <CInputGroupText>
                        <CIcon icon={cilLockLocked} />
                      </CInputGroupText>
                      <CFormInput
                        type="password"
                        placeholder="Password"
                        autoComplete="current-password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                      />
                    </CInputGroup>
                    <CRow>
                      <CCol xs={6}>
                        <CButton color="primary" className="px-4" type='submit'>
                          Login
                        </CButton>
                      </CCol>
                      <CCol xs={6} className="text-right">
                        <CButton color="link" className="px-0">
                          Forgot password?
                        </CButton>
                      </CCol>
                    </CRow>
                  </CForm>
                </CCardBody>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default ForgetPassword
