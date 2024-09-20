import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CTabs, CTabList, CTabContent,CTabPanel , CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CTab, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import AccessGroupPopup_Details from './AccessGroupPopup_Details.js';
import AccessGroupPopup_Menus from './AccessGroupPopup_Menus.js';


const AccessGroupPopup = ({ visible, onClose, onOpen, AccessGroupDetails, checkMenuListItems, popupStatus , StatusInDB  }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
 

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

              <AccessGroupPopup_Details popupStatus={popupStatus} AccessGroupDetails={AccessGroupDetails} StatusInDB={StatusInDB} />
              <AccessGroupPopup_Menus popupStatus={popupStatus} AccessGroupDetails={AccessGroupDetails} />

            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default AccessGroupPopup
