import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody,CCol,CInputGroupText, CModalTitle, CModalFooter, CModalHeader,CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const LeaveTypePopup = ({ visible, onClose, onOpen, leaveTypeDetails }) => {

  const handleSubmit = (event) => {
    event.preventDefault();

  };
  const[leaveTypeId, setLeaveTypeId] = useState('')
  const [leaveAlotmentId, setLeaveAlotmentId] = useState('')
  const [leaveType, setLeaveType] = useState('')

  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }
  const handleChangeLeaveType = (event) => {
    setLeaveType(event.target.value)
  }
  const handleChangeId= (event) => {
    setLeaveTypeId(event.target.value)
  }

  console.log(leaveTypeDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New LeaveType</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New LeaveType</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveTypeID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="LeaveTypeID" name="LeaveTypeID" value={leaveTypeDetails.LVT_LeaveTypeID} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveType</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="LeaveType" name="LeaveType" value={leaveTypeDetails.LVT_LeaveType} onChange={handleChangeLeaveType}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveAlotment</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="LeaveAlotment" name="LeaveAlotment" value={leaveTypeDetails.LVT_LeaveAlotment} onChange={handleChangeAlotment}
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
export default LeaveTypePopup
