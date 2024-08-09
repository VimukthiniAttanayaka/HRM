import React, {useEffect, useState} from 'react'
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
import UserProfileContact from "./UserProfileContact";
import {getEmployeeSingle} from "../../apicalls/employee/get_employee_single";
import {getStaffID} from "../../staticClass";

const Profile = () => {

  const formData = {
    EME_EmployeeID: getStaffID(),
    AUD_notificationToken: '',
    UD_UserID: ''
  }
  let [employeeData, setEmployData] =  useState(getEmployeeSingle(formData))

  useEffect(() => {
    async function fetchData() {
      // You can await here
      let tmpEmpData = await getEmployeeSingle(formData)
      setEmployData(tmpEmpData)
      // ...
    }
    fetchData();
  }, []);

  return (
    <div className="bg-body-tertiary min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center p-4">
          <CCol md={8}>
            <CCardGroup>
              <CCard className="p-4">
                <CTabs activeItemKey="profile">
                  <CTabList variant="tabs">
                    {/*<CTab itemKey="home">Home</CTab>*/}
                    <CTab itemKey="profile">Profile</CTab>
                    <CTab itemKey="contact">Contact</CTab>
                    {/*<CTab disabled itemKey="disabled">Disabled</CTab>*/}
                  </CTabList>
                  <CTabContent>
                    <CTabPanel className="p-3" itemKey="home">
                      Home tab content
                    </CTabPanel>
                    <CTabPanel className="p-3" itemKey="profile">
                      <ProfileTabContent employeeData={employeeData}></ProfileTabContent>
                    </CTabPanel>
                    <CTabPanel className="p-3" itemKey="contact">
                      <UserProfileContact employeeData={employeeData}></UserProfileContact>
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
