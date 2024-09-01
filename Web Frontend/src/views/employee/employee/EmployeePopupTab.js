import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import EmployeePopupTab_General from './EmployeePopupTab_General.js';
import EmployeePopupTab_Profile from './EmployeePopupTab_Profile.js';
import EmployeePopupTab_Contact from './EmployeePopupTab_Contact.js';
import EmployeePopupTab_Employment from './EmployeePopupTab_Employment.js';
import EmployeePopupTab_JobDescriptionGrid from './EmployeePopupTab_JobDescriptionGrid.js';
import EmployeePopupTab_JobDescriptionPopUp from './EmployeePopupTab_JobDescriptionPopUp.js';
import EmployeePopupTab_ReportingManager from './EmployeePopupTab_ReportingManager.js';

const EmployeePopupTab = ({ visible, onClose, onOpen, EmployeeDetails, popupStatus }) => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const [employeeId, setEmployeeId] = useState()

  const handleChangeEmployeeId = (event) => {
    setEmployeeId(event.target.value)
  }

  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return 'Edit Employee'
    } else if (popupStatus == 'view') {
      return 'View Employee'
    } else if (popupStatus == 'delete') {
      return 'Delete Employee'
    } else {
      return 'Create New Employee'
    }
  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setEmployeeId('')
    }
    else {
      setEmployeeId(EmployeeDetails.EME_EmployeeID)
    }
  }, [EmployeeDetails]);

  return (
    <>
      <CButton color="primary" onClick={onOpen}>Add New Employee</CButton>
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
          {/* {ImageDisplay(img[0])} */}
          <CTabs activeItemKey="general">
            <CTabList variant="tabs">
              <CTab itemKey="general">General</CTab>
              <CTab itemKey="profile">Profile</CTab>
              <CTab itemKey="contact">Contact</CTab>
              <CTab itemKey="employment">Employment</CTab>
              <CTab itemKey="jobDescription">Job Description</CTab>
              <CTab itemKey="reportingmanager">Reporting Manager</CTab>
            </CTabList>
            <CTabContent>
              <EmployeePopupTab_General popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_Profile popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_Contact popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_Employment popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_JobDescriptionGrid popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_ReportingManager popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default EmployeePopupTab
