import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CCol, CInputGroupText, CModalBody, CModalTitle, CModalFooter,CFormCheck,CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const EmployeePopup = ({ visible, onClose, onOpen }) => {

  const handleSubmit = (event) => {
    event.preventDefault();

  };
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Employee</CButton>
      <CModal size='lg'
        scrollable="true"
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Employee</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4" md={9}>
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Company Id</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Company Id" name="customerId"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Department Id</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Department Id" name="DepartmentId"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>

                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Employee ID</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Employee ID" name="EmployeeID"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>FirstName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="FirstName" name="FirstName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LastName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="LastName" name="LastName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PrefferedName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PrefferedName" name="PrefferedName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>OrgStructuralLevel1</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="OrgStructuralLevel1" name="OrgStructuralLevel1"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>OrgStructuralLevel2</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="OrgStructuralLevel2" name="OrgStructuralLevel2"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>DepartmentDetail1</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="DepartmentDetail1" name="DepartmentDetail1"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>DepartmentDetail2</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="DepartmentDetail2" name="DepartmentDetail2"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>DepartmentDetail3</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="DepartmentDetail3" name="DepartmentDetail3"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobCodeDescription</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobCodeDescription" name="JobCodeDescription"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Address</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Address" name="Address"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmailAddress</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="EmailAddress" name="EmailAddress"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>MobileNumber</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="MobileNumber" name="MobileNumber"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber1</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber1" name="PhoneNumber1"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber2</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber2" name="PhoneNumber2"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>RankDescription</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="RankDescription" name="RankDescription"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>StaffLocation</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="StaffLocation" name="StaffLocation"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remarks</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Remarks" name="Remarks"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Pwd</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Pwd" name="Pwd"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LastResetDateTime</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="LastResetDateTime" name="LastResetDateTime"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>SyncedDateTime</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="SyncedDateTime" name="SyncedDateTime"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveFrom</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="ActiveFrom" name="ActiveFrom"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveTo</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="ActiveTo" name="ActiveTo"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol><CFormCheck label="Status" defaultChecked />
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
export default EmployeePopup
