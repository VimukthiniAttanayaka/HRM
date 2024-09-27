import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const JobTypePopup = ({ visible, onClose, onOpen, jobTypeDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [jobTypeId, setJobTypeId] = useState('')
  const [jobAlotmentId, setJobAlotmentId] = useState('')
  const [jobType, setJobType] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAlotment = (event) => {
    setJobAlotmentId(event.target.value)
  }
  const handleChangeJobType = (event) => {
    setJobType(event.target.value)
  }
  const handleChangeId = (event) => {
    setJobTypeId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      LVT_JobTypeID: jobTypeId,
      LVT_JobAlotment: jobAlotmentId,
      LVT_JobType: jobType,
      LVT_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'jobtype/add_new_jobtype', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Job Type data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Job Type data:', response.statusText)
    }
  }

  console.log(jobTypeDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New JobType</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New JobType</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobTypeID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="JobTypeID" name="JobTypeID" value={jobTypeDetails.LVT_JobTypeID} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobType</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="JobType" name="JobType" value={jobTypeDetails.LVT_JobType} onChange={handleChangeJobType}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobAlotment</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="JobAlotment" name="JobAlotment" value={jobTypeDetails.LVT_JobAlotment} onChange={handleChangeAlotment}
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
export default JobTypePopup
