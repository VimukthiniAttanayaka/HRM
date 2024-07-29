import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CModalTitle, CModalFooter, CCol, CInputGroupText, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CTimePicker, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
const LeaveSchedulePopup = ({ visible, onClose, onOpen, leaveScheduleDetails }) => {
  const now = new Date();
  const [customerId, setCustomerId] = useState('')
  const [Reason, setReason] = useState('')
  const [EndDate, setEndDate] = useState(now)
  const [StartDate, setStartDate] = useState(now)
  const [StartTime, setStartTime] = useState(now)
  const [EndTime, setEndTime] = useState(now)


  const handleSubmit = (event) => {
    event.preventDefault();

  };
  const handleChangeReason = (event) => {
    setReason(event.target.value)
  }
  const handleChangeEndDate = (event) => {
    setEndDate(event.target.value)
  }
  const handleChangeStartDate = (event) => {
    setStartDate(event.target.value)
  }
  const handleChangeStartTime= (event) => {
    setStartTime(event.target.value)
  }
  const handleChangeEndTime= (event) => {
    setEndTime(event.target.value)
  }
  // console.log(leaveScheduleDetails.LV_LeaveEndDate)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>{customerId ? "Edit" : "Apply New Leave"}</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
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
                  </CCol>   <CTimePicker placeholder="StartTime" name="StartTime"
                  time={leaveScheduleDetails.LV_LeaveStartTime} onChange={handleChangeStartTime}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>OutTime</h6>
                    </CInputGroupText>
                  </CCol>    <CTimePicker placeholder="EndTime" name="EndTime"
                  time={leaveScheduleDetails.LV_LeaveEndTime} onChange={handleChangeEndTime}
                  />
                </CInputGroup>

                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EndDate</h6>
                    </CInputGroupText>
                  </CCol>  <CDatePicker placeholder="EndDate" name="EndDate" disabled
                    date={leaveScheduleDetails.LV_LeaveEndDate} onChange={handleChangeEndDate}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>StartDate</h6>
                    </CInputGroupText>
                  </CCol>  <CDatePicker placeholder="StartDate" name="StartDate" disabled
                    date={leaveScheduleDetails.LV_LeaveStartDate} onChange={handleChangeStartDate}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Reason</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="Reason" name="Reason"
                    value={leaveScheduleDetails.LV_Reason} onChange={handleChangeReason}
                  />
                </CInputGroup>
                {/* <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol><CFormCheck label="Status" defaultChecked />
                </CInputGroup> */}
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
export default LeaveSchedulePopup
