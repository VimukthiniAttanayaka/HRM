import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import axios from 'axios';
import General from './General.js';
import Profile from './Profile.js';

const Contact = ({EmployeeDetails, popupStatus }) => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const [employeeId, setEmployeeId] = useState()
  const [address, setAddress] = useState('')
  const [emailAddress, setEmailAddress] = useState('')
  const [mobileNumber, setMobileNumber] = useState('')
  const [phoneNumber1, setPhoneNumber1] = useState('')
  const [phoneNumber2, setPhoneNumber2] = useState('')

  const handleChangeAddress = (event) => {
    setAddress(event.target.value)
  }
  const handleChangeEmailAddress = (event) => {
    setEmailAddress(event.target.value)
  }
  const handleChangeMobileNumber = (event) => {
    setMobileNumber(event.target.value)
  }
  const handleChangePhoneNumber1 = (event) => {
    setPhoneNumber1(event.target.value)
  }
  const handleChangePhoneNumber2 = (event) => {
    setPhoneNumber2(event.target.value)
  }

  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_CustomerID: "string",
      EME_Address: address,
      EME_EmailAddress: emailAddress,
      EME_MobileNumber: mobileNumber,
      EME_PhoneNumber1: phoneNumber1,
      EME_PhoneNumber2: phoneNumber2,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/add_new_employee', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      // onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
    }
  }
  const handleEdit = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_CustomerID: "string",
      EME_Address: address,
      EME_EmailAddress: emailAddress,
      EME_MobileNumber: mobileNumber,
      EME_PhoneNumber1: phoneNumber1,
      EME_PhoneNumber2: phoneNumber2,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/modify_employee', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
    }
  }
  const handleDelete = async (event) => {
    console.log('Delete Department')
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_EmployeeID: employeeId,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/inactivate_employee', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
    }
  }

  const handleSubmitData = async (event) => {
    event.preventDefault()

    if (popupStatus == 'create') {
      handleCreate(event)
    } else if (popupStatus == 'edit') {
      handleEdit(event)
    } else if (popupStatus == 'delete') {
      handleDelete(event)
    }

  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setAddress('')
      setEmailAddress('')
      setMobileNumber('')
      setPhoneNumber1('')
      setPhoneNumber2('')
    }
    else {
      setAddress(EmployeeDetails.EME_Address)
      setEmailAddress(EmployeeDetails.EME_EmailAddress)
      setMobileNumber(EmployeeDetails.EME_MobileNumber)
      setPhoneNumber1(EmployeeDetails.EME_PhoneNumber1)
      setPhoneNumber2(EmployeeDetails.EME_PhoneNumber2)
    }
  }, [EmployeeDetails]);

  return (
    <>
      <CTabPanel className="p-3" itemKey="contact">
        <CInputGroup className="mb-3">
          <CCol md={4}>
            <CInputGroupText>
              <h6>Address</h6>
            </CInputGroupText>
          </CCol> <CFormInput placeholder="Address" name="Address"
            value={address} onChange={handleChangeAddress}
          />
        </CInputGroup>
        <CInputGroup className="mb-3">
          <CCol md={4}>
            <CInputGroupText>
              <h6>EmailAddress</h6>
            </CInputGroupText>
          </CCol> <CFormInput placeholder="EmailAddress" name="emailAddress"
            value={emailAddress} onChange={handleChangeEmailAddress}
          />
        </CInputGroup>
        <CInputGroup className="mb-3">
          <CCol md={4}>
            <CInputGroupText>
              <h6>MobileNumber</h6>
            </CInputGroupText>
          </CCol> <CFormInput placeholder="MobileNumber" name="mobileNumber"
            value={mobileNumber} onChange={handleChangeMobileNumber}
          />
        </CInputGroup>
        <CInputGroup className="mb-3">
          <CCol md={4}>
            <CInputGroupText>
              <h6>PhoneNumber1</h6>
            </CInputGroupText>
          </CCol> <CFormInput placeholder="PhoneNumber1" name="phoneNumber1"
            value={phoneNumber1} onChange={handleChangePhoneNumber1}
          />
        </CInputGroup>
        <CInputGroup className="mb-3">
          <CCol md={4}>
            <CInputGroupText>
              <h6>PhoneNumber2</h6>
            </CInputGroupText>
          </CCol> <CFormInput placeholder="PhoneNumber2" name="phoneNumber2"
            value={phoneNumber2} onChange={handleChangePhoneNumber2}
          />
        </CInputGroup>
        <div className="d-grid">
          {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>Delete</CButton> :
            <CButton color="success" type='submit'>Submit</CButton>)}
        </div>
      </CTabPanel>
    </>
  )
}
export default Contact
