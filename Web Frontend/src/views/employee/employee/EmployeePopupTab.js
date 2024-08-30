import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import General from './General.js';
import Profile from './Profile.js';
import Contact from './Contact.js';
import Employment from './Employment.js';
import JobDiscription from './JobDiscription.js';

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
              <CTab itemKey="jobDiscription">Job Discription</CTab>
            </CTabList>
            <CTabContent>
              <General popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <Profile popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <Contact popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <Employment popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <JobDiscription popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default EmployeePopupTab
