import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CTabs, CCol, CTabList, CTab, CTabContent, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import UserRolePopup_Details from './UserRolePopup_Details.js';
import UserRolePopup_AccessGroup from './UserRolePopup_AccessGroup.js';

const UserRolePopup = ({ visible, onClose, onOpen, UserRoleDetails, checkAccessGroupListItems, popupStatus }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [UserRoleId, setUserRoleId] = useState('')
  const [UserRole, setUserRole] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeUserRole = (event) => {
    setUserRole(event.target.value)
  }
  const handleChangeId = (event) => {
    setUserRoleId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      EUR_UserRoleID: UserRoleId,
      EUR_UserRole: UserRole,
      EUR_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'UserRole/add_new_UserRole', {
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

  // console.log(UserRoleDetails)
  const [checkedItems, setCheckedItems] = useState([]);

  const handleCheckboxChange = (event) => {
    const { checked, value } = event.target;
    if (checked) {
      setCheckedItems([...checkedItems, value]);
    } else {
      setCheckedItems(checkedItems.filter(item => item !== value));
    }
  };

  const options = [
    { value: 'option1', label: 'Option 1' },
    { value: 'option2', label: 'Option 2' },
    { value: 'option3', label: 'Option 3' },
  ];

  return (
    <>
      <CButton color="primary" onClick={onOpen}>New UserRole</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New UserRole</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CTabs activeItemKey="general">
            <CTabList variant="tabs">
              <CTab itemKey="general">General</CTab>
              <CTab itemKey="groups">Groups</CTab>
            </CTabList>
            <CTabContent>

              <UserRolePopup_Details popupStatus={popupStatus} UserRoleDetails={UserRoleDetails} />
              <UserRolePopup_AccessGroup popupStatus={popupStatus} UserRoleDetails={UserRoleDetails} />

            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default UserRolePopup
