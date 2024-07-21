import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const ReportingManagerSearchPopup = ({ visible, onClose, onOpen, InternalUserDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [InternalUserId, setInternalUserId] = useState('')
  const [leaveAlotmentId, setLeaveAlotmentId] = useState('')
  const [InternalUser, setInternalUser] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }
  const handleChangeInternalUser = (event) => {
    setInternalUser(event.target.value)
  }
  const handleChangeId = (event) => {
    setInternalUserId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      LVT_InternalUserID: InternalUserId,
      LVT_LeaveAlotment: leaveAlotmentId,
      LVT_InternalUser: InternalUser,
      LVT_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'InternalUser/add_new_InternalUser', {
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

  console.log(InternalUserDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New InternalUser</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New InternalUser</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>InternalUserID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="InternalUserID" name="InternalUserID" value={InternalUserDetails.LVT_InternalUserID} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>InternalUser</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="InternalUser" name="InternalUser" value={InternalUserDetails.LVT_InternalUser} onChange={handleChangeInternalUser}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveAlotment</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="LeaveAlotment" name="LeaveAlotment" value={InternalUserDetails.LVT_LeaveAlotment} onChange={handleChangeAlotment}
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
export default ReportingManagerSearchPopup
