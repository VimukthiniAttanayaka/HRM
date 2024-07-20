import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody,CCol,CInputGroupText, CModalTitle,CDropdown,CDropdownItem,CDropdownMenu,CDropdownToggle, CModalFooter, CModalHeader,CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const LeaveEntitlementPopup = ({ visible, onClose, onOpen, leaveEntitlementDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const[leaveTypeId, setLeaveTypeId] = useState('')
  const [leaveAlotmentId, setLeaveAlotmentId] = useState('')
  const [leaveType, setLeaveType] = useState('')
  const [isActive, setIsActive] = useState(true)
  const [leaveEntitlementId, setLeaveEntitlementId] = useState(0)  
  const [employeeID, setEmployeeID] = useState('')

  const  handleChangeEmployeeID = (event) => {
    setEmployeeID(event.target.value)
  }
  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }  
  const handleChangeLeaveTypeId = (event) => {
    setLeaveTypeId(event.target.value)
  }
  const handleChangeLeaveType = (event) => {
    setLeaveType(event.target.value)
  }
  const handleChangeId= (event) => {
    setLeaveEntitlementId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      LVE_LeaveTypeID: leaveTypeId,
      LVE_EmployeeID: employeeID,
      LVE_LeaveAlotment: leaveAlotmentId,
      LVE_LeaveEntitlementID: leaveEntitlementId,
      LVE_LeaveType: leaveType,
      LVE_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'leavetype/add_new_LeaveEntitlement', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Leave Entitlement data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Leave Entitlement data:', response.statusText)
    }
  }

  console.log(leaveEntitlementDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New LeaveEntitlement</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New LeaveEntitlement</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
              <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmployeeID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="EmployeeID" name="EmployeeID" value={leaveEntitlementDetails.LVE_EmployeeID} onChange={handleChangeEmployeeID}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  /><CDropdown variant="nav-item">
                  <CDropdownToggle color="secondary">Dropdown button</CDropdownToggle>
                  <CDropdownMenu>
                    <CDropdownItem href="#">Action</CDropdownItem>
                    <CDropdownItem href="#">Another action</CDropdownItem>
                    <CDropdownItem href="#">Something else here</CDropdownItem>
                  </CDropdownMenu>
                </CDropdown>
                </CInputGroup>
                 <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveTypeID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="LeaveTypeID" name="LeaveTypeID" value={leaveEntitlementDetails.LVE_LeaveTypeID} onChange={handleChangeLeaveTypeId}
                                 // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveType</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="LeaveType" name="LeaveType" value={leaveEntitlementDetails.LVE_LeaveType} onChange={handleChangeLeaveType}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveAlotment</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="LeaveAlotment" name="LeaveAlotment" value={leaveEntitlementDetails.LVE_LeaveAlotment} onChange={handleChangeAlotment}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck label="Status" defaultChecked/>
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
export default LeaveEntitlementPopup
