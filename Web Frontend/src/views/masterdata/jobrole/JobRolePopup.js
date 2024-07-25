import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const JobRolePopup = ({ visible, onClose, onOpen, JobRoleDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [JobRoleId, setJobRoleId] = useState('')
  const [JobRole, setJobRole] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeJobRole = (event) => {
    setJobRole(event.target.value)
  }
  const handleChangeId = (event) => {
    setJobRoleId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      MDJR_JobRoleID: JobRoleId,
      MDJR_JobRole: JobRole,
      MDJR_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'JobRole/add_new_JobRole', {
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

  console.log(JobRoleDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New JobRole</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New JobRole</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobRoleID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="JobRoleID" name="JobRoleID" value={JobRoleDetails.MDJR_JobRoleID} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobRole</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="JobRole" name="JobRole" value={JobRoleDetails.MDJR_JobRole} onChange={handleChangeJobRole}
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
export default JobRolePopup
