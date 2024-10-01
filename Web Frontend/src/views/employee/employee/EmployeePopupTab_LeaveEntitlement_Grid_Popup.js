import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CFormTextarea, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { Dropdowns_LeaveType } from '../../../apicalls/leavetype/dropdowns.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import { modifyEmployeeLeaveEntitlement } from '../../../apicalls/employeeleaveentitlement/modify.js';
import { deleteEmployeeLeaveEntitlement } from '../../../apicalls/employeeleaveentitlement/delete.js';
import { addNewEmployeeLeaveEntitlement } from '../../../apicalls/employeeleaveentitlement/add_new.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { format, parse } from 'date-fns'

const EmployeePopupTab_LeaveEntitlement_Grid_Popup = ({ toggleCreate, EmployeeDetails, popupStatus, visible1, onClose1,
  onOpen1, StatusInDB, EmployeeLeaveEntitlementDetails, employeeId }) => {
  let templatetype = 'translation_employeeleaveentitlement'
  let templatetype_base = 'translation'
  const apiUrl = process.env.REACT_APP_API_URL;

  // const [employeeId, setEmployeeId] = useState()
  const [id, setID] = useState(0);
  const [remain, setRemain] = useState('manageelent')
  const [activeFrom, setActiveFrom] = useState('2024-01-01')
  const [activeTo, setActiveTo] = useState('2024-01-01')
  const [leaveType, setLeaveType] = useState('fullTime')
  const [leaveAlotment, setLeaveAlotment] = useState(0)
  const [isActive, setIsActive] = useState(true)
  const [optionsLeaveType, setOptionsLeaveType] = useState([]);

  const [selectedOptionLeaveType, setSelectedOptionLeaveType] = useState('');

  const handleChangeRemain = (event) => {
    setRemain(event.target.value)
  }
  const handleChangeActiveFrom = (event) => {
    setActiveFrom(event.target.value)
  }
  const handleChangeActiveTo = (event) => {
    setActiveTo(event.target.value)
  }
  const handleChangeLeaveType = (event) => {
    setLeaveType(event.target.value)
  }
  const handleChangeLeaveAlotment = (event) => {
    setLeaveAlotment(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }


  const handleSubmit = async (event) => {
    event.preventDefault();

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EEC_CustomerID: "string",
      EELE_EmployeeID: employeeId,
      EELE_ID: id,
      EELE_LeaveAlotment: parseInt(leaveAlotment),
      EELE_ActiveFrom: (popupStatus=='edit' || popupStatus=='delete')? activeFrom: activeFrom.toJSON(),
      EELE_ActiveTo: (popupStatus=='edit' || popupStatus=='delete')? activeTo: activeTo.toJSON(),
      EELE_LeaveTypeID: selectedOptionLeaveType,
      EELE_Remain:  parseInt(remain),
      EELE_Status: isActive,
    }

    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyEmployeeLeaveEntitlement(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteEmployeeLeaveEntitlement(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewEmployeeLeaveEntitlement(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      console.log(APIReturn.msg)
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const LeaveTypeDetails = await Dropdowns_LeaveType(formData)
    setOptionsLeaveType(LeaveTypeDetails);
    // console.log(LeaveTypeDetails)
  }
  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit LeaveEntitlement', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View LeaveEntitlement', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete LeaveEntitlement', templatetype)
    } else {
      return getLabelText('Create New LeaveEntitlement', templatetype)
    }
  }
  useEffect(() => {
    if (popupStatus == 'create') {
      setID(0)
      setLeaveAlotment('')
      setActiveFrom('')
      setActiveTo('')
      setSelectedOptionLeaveType('')
      setRemain('')
      setIsActive(true)
    }
    else {
      console.log(EmployeeLeaveEntitlementDetails)
      setID(EmployeeLeaveEntitlementDetails.EELE_ID)
      setLeaveAlotment(EmployeeLeaveEntitlementDetails.EELE_LeaveAlotment)
      setActiveFrom(EmployeeLeaveEntitlementDetails.EELE_ActiveFrom)
      setActiveTo(EmployeeLeaveEntitlementDetails.EELE_ActiveTo)
      setSelectedOptionLeaveType(EmployeeLeaveEntitlementDetails.EELE_LeaveTypeID)
      setRemain(EmployeeLeaveEntitlementDetails.EELE_Remain)
      setIsActive(EmployeeLeaveEntitlementDetails.EELE_Status)
    }
  }, [EmployeeLeaveEntitlementDetails]);

  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose1();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');

  useEffect(() => {
    requestdata();
  }, []);


  return (
    <>
      <CButton color="primary" onClick={() => { toggleCreate();/*onOpen1*/ }}>Assign Leave Entitlement</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible1}
        onClose={onClose1}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}
            {/* {popupStatusSetup()} */}
          </CModalTitle>
        </CModalHeader>
        <CModalBody>

          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Leave Type</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect required
                    disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    value={selectedOptionLeaveType} onChange={(e) => setSelectedOptionLeaveType(e.target.value)}>
                    {optionsLeaveType.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveFrom</h6>
                    </CInputGroupText>
                  </CCol>
                  {(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ?
                    <CFormInput placeholder="ActiveFrom" name="ActiveFrom" value={activeFrom}
                      disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                      format="YYYY-MM-DD" /> :
                    <CDatePicker placeholder="ActiveFrom" name="ActiveFrom" date={activeFrom}
                      onDateChange={(date) => { setActiveFrom(date) }}
                      inputDateParse={(date) => parse(date, 'dd-MMM-yyyy', new Date())}
                      inputDateFormat={(date) => format(new Date(date), 'dd-MMM-yyyy')}
                    />}
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveTo</h6>
                    </CInputGroupText>
                  </CCol>
                  {(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ?
                    <CFormInput placeholder="ActiveTo" name="ActiveTo" value={activeTo}
                      disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                      format="YYYY-MM-DD" /> :
                    <CDatePicker placeholder="ActiveTo" name="ActiveTo" date={activeTo}
                      onDateChange={(date) => { setActiveTo(date) }}
                      inputDateParse={(date) => parse(date, 'dd-MMM-yyyy', new Date())}
                      inputDateFormat={(date) => format(new Date(date), 'dd-MMM-yyyy')}
                    />}
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>leaveAlotment</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="leaveAlotment" name="leaveAlotment" type='number'
                    value={leaveAlotment} onChange={handleChangeLeaveAlotment}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remain</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="Remain" name="Remain" value={remain} type='number'
                    onChange={(e) => setRemain(e.target.value)}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    required>
                  </CFormInput>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck checked={isActive} onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                </CInputGroup>
                <div className="d-grid">
                  {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>Delete</CButton> :
                    <CButton color="success" type='submit'>Submit</CButton>)}
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default EmployeePopupTab_LeaveEntitlement_Grid_Popup
