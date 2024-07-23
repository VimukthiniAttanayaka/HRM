import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const UserRolePopup = ({ visible, onClose, onOpen, MenuAccessGroupDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [MenuAccessGroupId, setMenuAccessGroupId] = useState('')
  const [AccessGroupID, setAccessGroupID] = useState('')
  const [UserMenuID, setUserMenuID] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAccessGroupID = (event) => {
    setAccessGroupID(event.target.value)
  }
  const handleChangeUserMenuID = (event) => {
    setUserMenuID(event.target.value)
  }
  const handleMenuAccessGroupId = (event) => {
    setMenuAccessGroupId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      LVT_UserRoleID: MenuAccessGroupId,
      LVT_LeaveAlotment: leaveAlotmentId,
      LVT_UserRole: MenuAccessGroup,
      LVT_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'MenuAccessGroup/add_new_MenuAccessGroup', {
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

  // console.log(MenuAccessGroupDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Menu Access Group</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Menu Access Group</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserRoleID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="UserRoleID" name="UserRoleID" value={MenuAccessGroupDetails.LVT_UserRoleID} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserRole</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="UserRole" name="UserRole" value={MenuAccessGroupDetails.LVT_UserRole} onChange={handleChangeUserRole}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveAlotment</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="LeaveAlotment" name="LeaveAlotment" value={MenuAccessGroupDetails.LVT_LeaveAlotment} onChange={handleChangeAlotment}
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
export default UserRolePopup
