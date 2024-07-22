import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const ExternalUserPopup = ({ visible, onClose, onOpen, ExternalUserDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [FirstName, setFirstName] = useState('')
  const [LastName, setLastName] = useState('')
  const [EmailAddress, setEmailAddress] = useState('')
  const [MobileNumber, setMobileNumber] = useState('')
  const [Remarks, setRemarks] = useState('')
  const [EmployeeID, setEmployeeID] = useState('')
  const [PhoneNumber, setPhoneNumber] = useState('')
  const [UserName, setUserName] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeIsActive = (event) => { }
  const handleChangeEmployeeID = (event) => {
    setEmployeeID(event.target.value)
  }
  const handleChangeFirstName = (event) => {
    setFirstName(event.target.value)
  }
  const handleChangeLastName = (event) => {
    setLastName(event.target.value)
  }
  const handleChangeEmailAddress = (event) => {
    setEmailAddress(event.target.value)
  }
  const handleChangeMobileNumber = (event) => {
    setMobileNumber(event.target.value)
  }
  const handleChangeRemarks = (event) => {
    setRemarks(event.target.value)
  }
  const handleChangePhoneNumber = (event) => {
    setPhoneNumber(event.target.value)
  }
  const handleChangeUserName = (event) => {
    setUserName(event.target.value)
  }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      LVT_ExternalUserID: ExternalUserId,
      LVT_LeaveAlotment: leaveAlotmentId,
      LVT_ExternalUser: ExternalUser,
      LVT_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'ExternalUser/add_new_ExternalUser', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Leave Type data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Leave Type data:', response.statusText)
    }
  }

  // console.log(ExternalUserDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Internal User</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Internal User</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmployeeID</h6>
                    </CInputGroupText>
                  </CCol>

                  <CFormInput placeholder="EmployeeID" name="EmployeeID" value={ExternalUserDetails.UD_EmployeeID} onChange={handleChangeEmployeeID}

                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>FirstName</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="FirstName" name="FirstName" value={ExternalUserDetails.UD_FirstName} onChange={handleChangeFirstName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LastName</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="LastName" name="LastName" value={ExternalUserDetails.UD_LastName} onChange={handleChangeLastName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmailAddress</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="EmailAddress" name="EmailAddress" value={ExternalUserDetails.UD_EmailAddress} onChange={handleChangeEmailAddress}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>MobileNumber</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="MobileNumber" name="MobileNumber" value={ExternalUserDetails.UD_MobileNumber} onChange={handleChangeMobileNumber}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="PhoneNumber" name="PhoneNumber" value={ExternalUserDetails.UD_PhoneNumber} onChange={handleChangePhoneNumber}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remarks</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="Remarks" name="Remarks" value={ExternalUserDetails.UD_Remarks} onChange={handleChangeRemarks}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserName</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="UserName" name="UserName" value={ExternalUserDetails.UD_UserName} onChange={handleChangeUserName}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck label="Status" defaultChecked />
                </CInputGroup>
                <div className="d-grid">
                  <CButton color="success" type='submit'>Submit</CButton>
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default ExternalUserPopup
