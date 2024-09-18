import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CTabs, CTabList, CTabContent,CTabPanel , CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CTab, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import { requestdata_UserRoles_DropDowns_All } from '../../../apicalls/userrole/get_all_list.js';
import ExternalUserPopup_Details from './ExternalUserPopup_Details.js';
import ExternalUserPopup_Access from './ExternalUserPopup_Access.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const ExternalUserPopup = ({ visible, onClose, onOpen, ExternalUserDetails, popupStatus  }) => {
  let templatetype = 'translation_jobrole'
  let templatetype_base = 'translation'

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  // const [selectedOptionUserRole, setSelectedOptionUserRole] = useState('');
  // const [FirstName, setFirstName] = useState('')
  // const [LastName, setLastName] = useState('')
  // const [EmailAddress, setEmailAddress] = useState('')
  // const [MobileNumber, setMobileNumber] = useState('')
  // const [Remarks, setRemarks] = useState('')
  // const [EmployeeID, setEmployeeID] = useState('')
  // const [PhoneNumber, setPhoneNumber] = useState('')
  // const [UserName, setUserName] = useState('')
  // const [isActive, setIsActive] = useState(true)

  // const handleChangeIsActive = (event) => { }
  // const handleChangeEmployeeID = (event) => {
  //   setEmployeeID(event.target.value)
  // }
  // const handleChangeFirstName = (event) => {
  //   setFirstName(event.target.value)
  // }
  // const handleChangeLastName = (event) => {
  //   setLastName(event.target.value)
  // }
  // const handleChangeEmailAddress = (event) => {
  //   setEmailAddress(event.target.value)
  // }
  // const handleChangeMobileNumber = (event) => {
  //   setMobileNumber(event.target.value)
  // }
  // const handleChangeRemarks = (event) => {
  //   setRemarks(event.target.value)
  // }
  // const handleChangePhoneNumber = (event) => {
  //   setPhoneNumber(event.target.value)
  // }
  // const handleChangeUserName = (event) => {
  //   setUserName(event.target.value)
  // }

  // const handleSubmit = async (event) => {
  //   event.preventDefault()

  //   // Validation (optional)
  //   // You can add validation logic here to check if all required fields are filled correctly

  //   // Prepare form data
  //   const formData = {
  //     LVT_ExternalUserID: ExternalUserId,
  //     LVT_LeaveAlotment: leaveAlotmentId,
  //     LVT_ExternalUser: ExternalUser,
  //     LVT_Status: isActive,
  //   }
  //   // Submit the form data to your backend API
  //   const response = await fetch(apiUrl + 'ExternalUser/add_new_ExternalUser', {
  //     method: 'POST',
  //     headers: { 'Content-Type': 'application/json' },
  //     body: JSON.stringify(formData),
  //   })

  //   if (response.ok) {
  //     console.log(response);
  //     // Handle successful submission (e.g., display a success message)
  //     console.log('Leave Type data submitted successfully!')
  //   } else {
  //     // Handle submission errors
  //     console.error('Error submitting Leave Type data:', response.statusText)
  //   }
  // }

  // const [selectedOptionEmployeeID, setSelectedOptionEmployeeID] = useState('');

  // // console.log(ExternalUserDetails)
  // const [optionsUserRole, setOptionsUserRole] = useState([]);

  // async function requestdata() {
  //   const formData = {
  //     USR_EmployeeID: 'sedcx'
  //   }

  //   const UserRoleDetails = await requestdata_UserRoles_DropDowns_All(formData)

  //   setOptionsUserRole(UserRoleDetails);

  // }

  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit External User', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View External User', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete External User', templatetype)
    } else {
      return getLabelText('Create New External User', templatetype)
    }
  }
  // useEffect(() => {
  //   requestdata();
  // }, []);

  return (
    <>
      <CButton color="primary" onClick={onOpen}>New External User</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CTabs activeItemKey="general">
            <CTabList variant="tabs">
              <CTab itemKey="general">General</CTab>
              <CTab itemKey="access">Access</CTab>
            </CTabList>
            <CTabContent>

              <ExternalUserPopup_Details popupStatus={popupStatus} ExternalUserDetails={ExternalUserDetails} />
              <ExternalUserPopup_Access popupStatus={popupStatus} ExternalUserDetails={ExternalUserDetails} />

            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default ExternalUserPopup
