import React, { useState, useEffect } from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
  CFormCheck,
  CFormSelect,
} from '@coreui/react-pro'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass';
import GoogleMaps from './GoogleMaps';

const MarkAttendance = () => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      CUS_ID: customerId,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'customer/add_new_customer', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Company data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Company data:', response.statusText)
    }
  }

  const auth = localStorage.getItem('token');

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();
    // const config = {
    //   headers: { Authorization: `Bearer ${auth}` }
    // };
    const formData = {
      UD_StaffID: staffId,
      AUD_notificationToken: token,
      CUS_ID: 'cus1'
    }
    const res = await fetch(apiUrl + 'customer/get_customers_single', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
        console.log(res1);
      })
  }
  useEffect(() => {
    requestdata();
  }, [auth]);

  return (
    <div className="bg-body-tertiary min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={9}>
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <CForm onSubmit={handleSubmit}>
                  <h1>Mark</h1>
                  <p className="text-body-secondary">Mark Attendance</p>
                  <GoogleMaps/>

                  <div className="d-grid">
                    <CButton color="success" type='submit'>Submit</CButton>
                  </div>
                </CForm>
              </CCardBody>
            </CCard>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default MarkAttendance
