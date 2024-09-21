import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CTabs, CCol, CTabList, CTab, CTabContent, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import UserRolePopup_Details from './UserRolePopup_Details.js';
import UserRolePopup_AccessGroup from './UserRolePopup_AccessGroup.js';

const UserRolePopup = ({ visible, onClose, onOpen, UserRoleDetails, popupStatus }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [UserRoleId, setUserRoleId] = useState('')

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

              <UserRolePopup_Details onClose={onClose} popupStatus={popupStatus} UserRoleDetails={UserRoleDetails} />
              <UserRolePopup_AccessGroup onClose={onClose} popupStatus={popupStatus} UserRoleDetails={UserRoleDetails} />

            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default UserRolePopup
