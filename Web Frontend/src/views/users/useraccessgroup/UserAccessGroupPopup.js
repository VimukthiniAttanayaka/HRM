import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CFormSelect, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import { requestdata_UserName_DropDowns_All } from '../../../apicalls/usergeneral/get_all_list.js';
import { requestdata_AccessGroup_DropDowns_All } from '../../../apicalls/accessgroup/get_all_list.js';

const UserAccessGroupPopup = ({ visible, onClose, onOpen, UserAccessGroupDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [UserAccessGroupId, setUserAccessGroupId] = useState('')
  const [leaveAlotmentId, setLeaveAlotmentId] = useState('')
  const [UserAccessGroup, setUserAccessGroup] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }
  const handleChangeUserAccessGroup = (event) => {
    setUserAccessGroup(event.target.value)
  }
  const handleChangeId = (event) => {
    setUserAccessGroupId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      UUAG_UserAccessGroupID: UserAccessGroupId,
      UUAG_LeaveAlotment: leaveAlotmentId,
      UUAG_UserAccessGroup: UserAccessGroup,
      UUAG_Status: isActive,
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
      console.log('UserAccessGroup data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting UserAccessGroup data:', response.statusText)
    }
  }

  const [optionsUserName, setOptionsUserName] = useState([]);
  const [optionsAccessGroup, setOptionsAccessGroup] = useState([]);

  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const AccessGroupDetails = await requestdata_AccessGroup_DropDowns_All(formData)

    setOptionsAccessGroup(AccessGroupDetails);

    const UserNameDetails = await requestdata_UserName_DropDowns_All(formData)

    setOptionsUserName(UserNameDetails);

  }

  useEffect(() => {
    requestdata();
  }, []);

  // console.log(UserAccessGroupDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New User Access Group</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New User Access Group</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>User Name</h6>
                    </CInputGroupText>
                  </CCol>    <CFormSelect value={optionsUserName} onChange={(e) => setOptionsUserName(e.target.value)}>
                    {optionsUserName.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Access Group</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect value={optionsAccessGroup} onChange={(e) => setOptionsAccessGroup(e.target.value)}>
                    {optionsAccessGroup.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
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
export default UserAccessGroupPopup
