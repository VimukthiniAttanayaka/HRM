import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CTabs, CTabList, CTabContent, CTabPanel, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CTab, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import AccessGroupPopup_Details from './AccessGroupPopup_Details.js';
import AccessGroupPopup_Menus from './AccessGroupPopup_Menus.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const AccessGroupPopup = ({ visible, onClose, onOpen, AccessGroupDetails, popupStatus, StatusInDB }) => {
  let templatetype = 'translation_accessgroup'
  let templatetype_base = 'translation'
  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };


  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit Access Group', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Access Group', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Access Group', templatetype)
    } else {
      return getLabelText('Create New Access Group', templatetype)
    }
  }

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
          {/* <CModalTitle id="TooltipsAndPopoverExample">Create New Access Group</CModalTitle> */}
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}</CModalTitle>
          </CModalHeader>
        <CModalBody>
          <CTabs activeItemKey="general">
            <CTabList variant="tabs">
              <CTab itemKey="general">General</CTab>
              <CTab itemKey="menus">Menus</CTab>
            </CTabList>
            <CTabContent>

              <AccessGroupPopup_Details popupStatus={popupStatus} onClose={onClose} AccessGroupDetails={AccessGroupDetails} StatusInDB={StatusInDB} />
              <AccessGroupPopup_Menus popupStatus={popupStatus} AccessGroupDetails={AccessGroupDetails} />

            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default AccessGroupPopup
