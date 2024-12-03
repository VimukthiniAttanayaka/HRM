import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CFormTextarea, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import { Dropdowns_TerminationType } from '../../../apicalls/terminationtype/dropdowns.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import { modifyEmployeeTermination } from '../../../apicalls/employeetermination/modify.js';
import { deleteEmployeeTermination } from '../../../apicalls/employeetermination/delete.js';
import { addNewEmployeeTermination } from '../../../apicalls/employeetermination/add_new.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { format, parse } from 'date-fns'

const EmployeePopupTab_Termination_Grid_Popup = ({ toggleCreate, EmployeeDetails, popupStatus, visible1, onClose1,
  onOpen1, StatusInDB, EmployeeTerminationDetails, employeeId }) => {
  let templatetype = 'translation_employeetermination'
  let templatetype_base = 'translation'
  const apiUrl = process.env.REACT_APP_API_URL;

  // const [employeeId, setEmployeeId] = useState()
  const [id, setID] = useState(0);
  const [remarks, setRemarks] = useState('manageesnt')
  const [activeFrom, setActiveFrom] = useState('2024-01-01')
  const [activeTo, setActiveTo] = useState('2024-01-01')
  const [terminationType, setTerminationType] = useState('fullTime')
  const [termination, setTermination] = useState(0)
  const [isActive, setIsActive] = useState(true)
  const [optionsTerminationType, setOptionsTerminationType] = useState([]);

  const [selectedOptionTerminationType, setSelectedOptionTerminationType] = useState('');

  const handleChangeRemarks = (event) => {
    setRemarks(event.target.value)
  }
  const handleChangeActiveFrom = (event) => {
    setActiveFrom(event.target.value)
  }
  const handleChangeActiveTo = (event) => {
    setActiveTo(event.target.value)
  }
  const handleChangeTerminationType = (event) => {
    setTerminationType(event.target.value)
  }
  const handleChangeTermination = (event) => {
    setTermination(event.target.value)
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
      EES_EmployeeID: employeeId,
      EES_ID: id,
      EES_Termination: parseInt(termination),
      EES_ActiveFrom: activeFrom.toJSON(),
      EES_ActiveTo: activeTo.toJSON(),
      EES_TerminationType: selectedOptionTerminationType,
      EES_Remarks: remarks,
      EES_Status: isActive,
    }

    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyEmployeeTermination(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteEmployeeTermination(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewEmployeeTermination(formData)
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

    // const TerminationTypeDetails = await Dropdowns_TerminationType(formData)
    // setOptionsTerminationType(TerminationTypeDetails);
    // console.log(TerminationTypeDetails)
  }
  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit Termination', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Termination', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Termination', templatetype)
    } else {
      return getLabelText('Create New Termination', templatetype)
    }
  }
  useEffect(() => {
    if (popupStatus == 'create') {
      setID(0)
      setTermination('')
      setActiveFrom('')
      setActiveTo('')
      setSelectedOptionTerminationType('')
      setRemarks('')
      setIsActive(true)
    }
    else {
      setID(EmployeeTerminationDetails.EES_ID)
      // console.log(EmployeeTerminationDetails)
      setTermination(EmployeeTerminationDetails.EES_Termination)
      setActiveFrom(EmployeeTerminationDetails.EES_ActiveFrom)
      setActiveTo(EmployeeTerminationDetails.EES_ActiveTo)
      setSelectedOptionTerminationType(EmployeeTerminationDetails.EES_TerminationType)
      setRemarks(EmployeeTerminationDetails.EES_Remarks)
      setIsActive(EmployeeTerminationDetails.EES_Status)
    }
  }, [EmployeeTerminationDetails]);

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
      <CButton color="primary" onClick={() => { toggleCreate();/*onOpen1*/ }}>Termination</CButton>
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
                      <h6>Termination Type</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormSelect required
                    disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    value={selectedOptionTerminationType} onChange={(e) => setSelectedOptionTerminationType(e.target.value)}>
                    {optionsTerminationType.map((option) => (
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
                      <h6>Termination</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="Termination" name="termination" type='number'
                    value={termination} onChange={handleChangeTermination}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remarks</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormTextarea placeholder="Remarks" name="Remarks" value={remarks}
                    onChange={(e) => setRemarks(e.target.value)}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                    required>
                  </CFormTextarea>
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
export default EmployeePopupTab_Termination_Grid_Popup
