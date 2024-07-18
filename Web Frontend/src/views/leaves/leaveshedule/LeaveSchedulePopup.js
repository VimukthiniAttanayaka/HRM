import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CModalTitle, CModalFooter,CCol,CInputGroupText,CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
const LeaveSchedulePopup = ({ visible, onClose, onOpen }) => {
  const [customerId, setCustomerId] = useState('')
  const handleSubmit = (event) => {
    event.preventDefault();

  };
  return (
    <>
      <CButton color="primary" onClick={onOpen}>{customerId ? "Edit" : "Apply New Leave"}</CButton>
      <CModal size='lg'
        scrollable="true"
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">{customerId ? "Edit" : "Apply New Leave"}</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
              <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>InTime</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="InTime" name="InTime"
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>OutTime</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="OutTime" name="OutTime"
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Reason</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="Reason" name="Reason"
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EndDate</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="EndDate" name="EndDate"
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Total</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="Total" name="Total"
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>AttendanceDate</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="AttendanceDate" name="AttendanceDate"
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>StartDate</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="StartDate" name="StartDate"
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol><CFormCheck label="Status" defaultChecked />
                </CInputGroup> <div className="d-grid">
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
export default LeaveSchedulePopup
