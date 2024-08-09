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
  CInputGroupText, CTabs, CTabList, CTab, CTabContent, CTabPanel,
  CRow,
} from '@coreui/react-pro'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import ProfileTabContent from "./ProfileTabContent";

const Profile = () => {

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
                <CTabs activeItemKey="profile">
                  <CTabList variant="tabs">
                    <CTab itemKey="home">Home</CTab>
                    <CTab itemKey="profile">Profile</CTab>
                    <CTab itemKey="contact">Contact</CTab>
                    <CTab disabled itemKey="disabled">Disabled</CTab>
                  </CTabList>
                  <CTabContent>
                    <CTabPanel className="p-3" itemKey="home">
                      Home tab content
                    </CTabPanel>
                    <CTabPanel className="p-3" itemKey="profile">
                      <ProfileTabContent></ProfileTabContent>
                    </CTabPanel>
                    <CTabPanel className="p-3" itemKey="contact">
                      Contact tab content
                    </CTabPanel>
                    <CTabPanel className="p-3" itemKey="disabled">
                      Disabled tab content
                    </CTabPanel>
                  </CTabContent>
                </CTabs>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Profile
