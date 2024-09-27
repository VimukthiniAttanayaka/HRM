import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import EmployeePopupTab_General from './EmployeePopupTab_General.js';
import EmployeePopupTab_Profile_Grid from './EmployeePopupTab_Profile_Grid.js';
import EmployeePopupTab_Contact_Grid from './EmployeePopupTab_Contact_Grid.js';
import EmployeePopupTab_Salary_Grid from './EmployeePopupTab_Salary_Grid.js';
import EmployeePopupTab_JobRoleGrid from './EmployeePopupTab_JobRole_Grid.js';
import EmployeePopupTab_ReportingManagerGrid from './EmployeePopupTab_ReportingManager_Grid.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

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
              <CTab
                disabled={(popupStatus == 'create') ? true : false}
                itemKey="profile">Profile</CTab>

              <CTab disabled={(popupStatus == 'create') ? true : false}
                itemKey="contact">Contact</CTab>

              <CTab disabled={(popupStatus == 'create') ? true : false}
                itemKey="salary">Salary</CTab>

              <CTab disabled={(popupStatus == 'create') ? true : false}
                itemKey="jobrole">Job Description</CTab>

              <CTab disabled={(popupStatus == 'create') ? true : false}
                itemKey="reportingmanager">Reporting Manager</CTab>

            </CTabList>
            <CTabContent>
              <EmployeePopupTab_General popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_Profile_Grid popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_Contact_Grid popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_Salary_Grid popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} />
              <EmployeePopupTab_JobRoleGrid popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} employeeId={employeeId} />
              <EmployeePopupTab_ReportingManagerGrid popupStatus={popupStatus} EmployeeDetails={EmployeeDetails} employeeId={employeeId} />
            </CTabContent>
          </CTabs>
        </CModalBody>
      </CModal>
    </>
  )
}
export default EmployeePopupTab
