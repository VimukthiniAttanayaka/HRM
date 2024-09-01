import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CFormSelect, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

import { requestdata_Employee_DropDowns_All } from '../../../apicalls/employee/get_all_list.js';

const ReportingManagerSearchPopup = ({ visible, onClose, onOpen, ReportingManagerDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [ReportingManagerID, setReportingManagerID] = useState('')
  const [EmployeeID, setEmployeeID] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeReportingManagerID = (event) => {
    setReportingManagerID(event.target.value)
  }
  const handleChangeEmployeeID = (event) => {
    setEmployeeID(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      LVT_InternalUserID: InternalUserId,
      LVT_LeaveAlotment: leaveAlotmentId,
      LVT_InternalUser: InternalUser,
      LVT_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'InternalUser/add_new_InternalUser', {
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

  const [selectedOptionReportingManagerID, setSelectedOptionReportingManagerID] = useState(null);

  const [selectedOptionEmployeeID, setSelectedOptionEmployeeID] = useState(null);
  
  const [optionsReportingManagerID, setOptionsReportingManagerID] = useState([]);
    
  const [optionsEmployeeID, setOptionsEmployeeID] = useState([]);
  
  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const ReportingManagerDetails = await requestdata_Employee_DropDowns_All(formData)

    setOptionsReportingManagerID(ReportingManagerDetails);

    const EmployeeDetails = await requestdata_Employee_DropDowns_All(formData)

    setOptionsEmployeeID(EmployeeDetails);

  }

  useEffect(() => {
    requestdata();
  }, []);

  console.log(ReportingManagerDetails)

  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Reporting Manager</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Reporting Manager</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Reporting Manager ID</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect value={selectedOptionReportingManagerID} onChange={(e) => setSelectedOptionReportingManagerID(e.target.value)}>
                    {optionsEmployeeID.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Employee ID</h6>
                    </CInputGroupText>
                  </CCol>

                  <CFormSelect value={selectedOptionEmployeeID} onChange={(e) => setSelectedOptionEmployeeID(e.target.value)}>
                    {optionsEmployeeID.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck label="Status" defaultChecked />
                </CInputGroup>
                <div className="d-grid">
                  <CButton color="success" type='submit'>Submit</CButton>
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default ReportingManagerSearchPopup
