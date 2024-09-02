import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CTabs, CTabList, CTabContent,CTabPanel , CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CTab, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import AccessGroupPopup_Details from './AccessGroupPopup_Details.js';
import AccessGroupPopup_Menus from './AccessGroupPopup_Menus.js';


const AccessGroupPopup = ({ visible, onClose, onOpen, AccessGroupDetails, checkMenuListItems, popupStatus   }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [AccessGroupId, setAccessGroupId] = useState('')
  const [AccessGroup, setAccessGroup] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }
  const handleChangeAccessGroup = (event) => {
    setAccessGroup(event.target.value)
  }
  const handleChangeId = (event) => {
    setAccessGroupId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      UAG_AccessGroupID: AccessGroupId,
      UAG_AccessGroup: AccessGroup,
      UAG_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'AccessGroup/add_new_AccessGroup', {
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
  // const [checkMenuListItems, setcheckMenuListItems] = useState([]);

  const handleCheckboxChange = (event) => {
    const { checked, value } = event.target;
    if (checked) {
      setCheckedItems([...checkedItems, value]);
    } else {
      setCheckedItems(checkedItems.filter(item => item !== value));
    }
  };

  const options = [
    { value: 'option1', label: 'Option 1', checked: true },
    { value: 'option2', label: 'Option 2', checked: true },
    { value: 'option3', label: 'Option 3', checked: true },
  ];

  useEffect(() => {
  }, []);

 
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Access Group</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Access Group</CModalTitle>
        </CModalHeader>
        <CModalBody>
        <CTabs activeItemKey="general">
            <CTabList variant="tabs">
              <CTab itemKey="general">General</CTab>
              <CTab itemKey="menus">Menus</CTab>
            </CTabList>
            <CTabContent>

              <AccessGroupPopup_Details popupStatus={popupStatus} AccessGroupDetails={AccessGroupDetails} />
              <AccessGroupPopup_Menus popupStatus={popupStatus} AccessGroupDetails={AccessGroupDetails} />

            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default AccessGroupPopup
