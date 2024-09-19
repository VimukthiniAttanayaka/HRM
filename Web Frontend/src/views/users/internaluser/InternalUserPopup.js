import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CTabs, CTabList, CTabContent,CTabPanel , CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CTab, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import { requestdata_UserRoles_DropDowns_All } from '../../../apicalls/userrole/get_all_list.js';
import InternalUserPopup_Details from './InternalUserPopup_Details.js';
import InternalUserPopup_Access from './InternalUserPopup_Access.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const InternalUserPopup = ({ visible, onClose, onOpen, InternalUserDetails, popupStatus  }) => {
  let templatetype = 'translation_internaluser'
  let templatetype_base = 'translation'

  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit Internal User', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Internal User', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Internal User', templatetype)
    } else {
      return getLabelText('Create New Internal User', templatetype)
    }
  }
  // useEffect(() => {
  //   requestdata();
  // }, []);

  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Internal User</CButton>
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

              <InternalUserPopup_Details popupStatus={popupStatus} InternalUserDetails={InternalUserDetails} />
              <InternalUserPopup_Access popupStatus={popupStatus} InternalUserDetails={InternalUserDetails} />

            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default InternalUserPopup
