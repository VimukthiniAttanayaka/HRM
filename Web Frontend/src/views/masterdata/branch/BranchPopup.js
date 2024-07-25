import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const BranchPopup = ({ visible, onClose, onOpen, branchDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [branchId, setBranchId] = useState('')
  const [leaveAlotmentId, setLeaveAlotmentId] = useState('')
  const [branch, setBranch] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }
  const handleChangeBranch = (event) => {
    setBranch(event.target.value)
  }
  const handleChangeId = (event) => {
    setBranchId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      MDB_BranchID: branchId,
      MDB_LeaveAlotment: leaveAlotmentId,
      MDB_Branch: branch,
      MDB_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'leavetype/add_new_leavetype', {
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

  // console.log(branchDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Branch</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Branch</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>BranchID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="BranchID" name="BranchID" value={branchDetails.MDB_BranchID} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Branch</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Branch" name="Branch" value={branchDetails.MDB_Branch} onChange={handleChangeBranch}
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
export default BranchPopup
