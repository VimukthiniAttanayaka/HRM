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
import { useNavigate } from 'react-router-dom';

const Login = () => {

  const navigate = useNavigate();
  const apiUrl = process.env.REACT_APP_API_URL;

  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [menuList, setMenuList] = useState([]);

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
        // let menuList = [];
        console.log(res1.user[0].UserAccessList);
        for (let index = 0; index < res1.user[0].UserAccessList.length; index++) {
          let element = res1.user[0].UserAccessList[index];
          // console.log(element)
          menuList[index] = new UserMenuDetail(element.MNU_Active, element.MNU_MenuName);
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
        setMenu(menuList);
        console.log(menuList);
        navigate('/dashboard');
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
                    <h1>Login</h1>
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
                        <CButton color="link" className="px-0" href="#/forgetpassword">
                          Forgot password?
                        </CButton>
                      </CCol>
                    </CRow>
                  </CForm>
                </CCardBody>
              </CCard>
              <CCard  className="text-white bg-primary py-5" style={{ width: '44%' }}>
                <CCardBody className="text-center">
                  <div>
                    <h2>Sign up</h2>
                    <p>Your Username and Password must be kept confidential at all times. Passwords should never be shared or exposed to others. You will not let anyone else access your account, or do anything else that might jeopardize the security of your account. You are responsible for the confidentiality of your user account.</p>
                    {/* <p>ඔබගේ පරිශීලක නාමය සහ මුරපදය සෑම විටම රහසිගතව තබා ගත යුතුය. මුරපද කිසිවිටෙක අන් අය සමග බෙදා නොගත යුතුය. ඔබ වෙනත් කිසිවෙකුට ඔබගේ ගිණුමට ප්‍රවේශ වීමට ඉඩ නොතැබිය යුතු අතර, ඔබගේ ගිණුමේ ආරක්ෂාවට තර්ජනයක් විය හැකි වෙනත් කිසිවක් කිරීමට ඔබ අන් අයට ඉඩ නොදිය යුතුය. ඔබගේ පරිශීලක ගිණුමේ රහස්‍යභාවය පිළිබඳව පූර්ණ වගකීම ඔබ සතුය.</p>
                    <p>உங்கள் Username மற்றும் Password எப்போதும் ரகசியமாக வைக்கப்பட வேண்டும். Password ஒருபோதும் மற்றவர்களுடன் பகிரவோ அல்லது வெளிப்படுத்தவோ கூடாது. உங்கள் User Account வேறு யாரையும் பயன்படுத்த அனுமதிக்க வேண்டாம். மற்றும் உங்கள் User Account பாதுகாப்பை பாதிக்கக்கூடிய வேறு எதையும் செய்ய வேண்டாம் . உங்கள் User Account ரகசியத்தன்மைக்கு நீங்கள் பொறுப்பு.</p> */}
                    <Link to="/register">
                      <CButton color="primary" disabled className="mt-3">
                        Please Contact Admin
                      </CButton>
                    </Link>
                  </div>
                </CCardBody>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Login
