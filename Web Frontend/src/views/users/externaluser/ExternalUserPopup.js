import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CTabs, CTabList, CTabContent, CTabPanel, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CTab, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import { requestdata_UserRoles_DropDowns_All } from '../../../apicalls/userrole/get_all_list.js';
import ExternalUserPopup_Details from './ExternalUserPopup_Details.js';
import ExternalUserPopup_Access from './ExternalUserPopup_Access.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const ExternalUserPopup = ({ visible, onClose, onOpen, ExternalUserDetails, popupStatus, StatusInDB }) => {
  let templatetype = 'translation_externaluser'
  let templatetype_base = 'translation'

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

              <ExternalUserPopup_Details popupStatus={popupStatus} visible={visible} StatusInDB={StatusInDB} ExternalUserDetails={ExternalUserDetails} onClose={onClose} />
              <ExternalUserPopup_Access popupStatus={popupStatus} ExternalUserDetails={ExternalUserDetails} />

            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default ExternalUserPopup
