import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const UserMenuPopup = ({ visible, onClose, onOpen, UserMenuDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [UserMenuId, setUserMenuId] = useState('')
  const [UserMenu, setUserMenu] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeUserMenu = (event) => {
    setUserMenu(event.target.value)
  }
  const handleChangeId = (event) => {
    setUserMenuId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      UUM_UserMenuID: UserMenuId,
      UUM_LeaveAlotment: leaveAlotmentId,
      UUM_UserMenu: UserMenu,
      UUM_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'UserMenu/add_new_UserMenu', {
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

  // console.log(UserMenuDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New UserMenu</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New UserMenu</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserMenuID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="UserMenuID" name="UserMenuID" value={UserMenuDetails.UUM_UserMenuID} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserMenu</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="UserMenu" name="UserMenu" value={UserMenuDetails.UUM_UserMenu} onChange={handleChangeUserMenu}
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
export default UserMenuPopup
