import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CFormTextarea, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import axios from 'axios';
import { getLabelText } from 'src/MultipleLanguageSheets'
import { modifyEmployeeContact } from '../../../apicalls/employeecontact/modify.js';
import { deleteEmployeeContact } from '../../../apicalls/employeecontact/delete.js';
import { addNewEmployeeContact } from '../../../apicalls/employeecontact/add_new.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { format, parse } from 'date-fns'

const EmployeePopupTab_Contact_Grid_Popup = ({ toggleCreate, EmployeeDetails, popupStatus, visible1, onClose1, onOpen1, StatusInDB, EmployeeContactDetails, employeeId }) => {
  let templatetype = 'translation_employeecontact'
  let templatetype_base = 'translation'

  const apiUrl = process.env.REACT_APP_API_URL;

  // const [employeeId, setEmployeeId] = useState()
  const [id, setID] = useState(0);
  const [address, setAddress] = useState('')
  const [emailAddress, setEmailAddress] = useState('')
  const [mobileNumber, setMobileNumber] = useState('')
  const [phoneNumber1, setPhoneNumber1] = useState('')
  const [phoneNumber2, setPhoneNumber2] = useState('')
  const [Remarks, setRemarks] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAddress = (event) => {
    setAddress(event.target.value)
  }
  const handleChangeEmailAddress = (event) => {
    setEmailAddress(event.target.value)
  }
  const handleChangeMobileNumber = (event) => {
    setMobileNumber(event.target.value)
  }
  const handleChangePhoneNumber1 = (event) => {
    setPhoneNumber1(event.target.value)
  }
  const handleChangePhoneNumber2 = (event) => {
    setPhoneNumber2(event.target.value)
  }

  const handleChangeRemarks = (event) => {
    setRemarks(event.target.value)
  }
  const handleChangeIsActive = (event) => { StatusInDB = event.target.checked; setIsActive(event.target.checked) }

  const handleSubmit = async (event) => {
    event.preventDefault();

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EEC_CustomerID: "string",
      EEC_EmployeeID: employeeId,
      EEC_ID: id,
      EEC_Address: address,
      EEC_EmailAddress: emailAddress,
      EEC_MobileNumber: mobileNumber,
      EEC_PhoneNumber1: phoneNumber1,
      EEC_PhoneNumber2: phoneNumber2,
      EEC_Remarks: Remarks,
      EEC_Status: isActive,
    }

    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyEmployeeContact(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteEmployeeContact(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewEmployeeContact(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      console.log(APIReturn.msg)
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit Contact', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Contact', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Contact', templatetype)
    } else {
      return getLabelText('Create New Contact', templatetype)
    }
  }
  useEffect(() => {
    if (popupStatus == 'create') {
      setID(0)
      setAddress('')
      setEmailAddress('')
      setMobileNumber('')
      setPhoneNumber1('')
      setPhoneNumber2('')
      setRemarks('')
      setIsActive(true)
    }
    else {
      setID(EmployeeContactDetails.EEC_ID)
      // console.log(EmployeeContactDetails)
      setAddress(EmployeeContactDetails.EEC_Address)
      setEmailAddress(EmployeeContactDetails.EEC_EmailAddress)
      setMobileNumber(EmployeeContactDetails.EEC_MobileNumber)
      setPhoneNumber1(EmployeeContactDetails.EEC_PhoneNumber1)
      setPhoneNumber2(EmployeeContactDetails.EEC_PhoneNumber2)
      setRemarks(EmployeeContactDetails.EEC_Remarks)
      setIsActive(EmployeeContactDetails.EEJR_Status)
    }
  }, [EmployeeContactDetails]);

  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose1();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');


  return (
    <>
      <CButton color="primary" onClick={() => { toggleCreate();/*onOpen1*/ }}>Add New Contact</CButton>
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
                      <h6>Address</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Address" name="Address"
                    value={address} onChange={handleChangeAddress}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmailAddress</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="EmailAddress" name="emailAddress"
                    value={emailAddress} onChange={handleChangeEmailAddress}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>MobileNumber</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="MobileNumber" name="mobileNumber"
                    value={mobileNumber} onChange={handleChangeMobileNumber}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber1</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber1" name="phoneNumber1"
                    value={phoneNumber1} onChange={handleChangePhoneNumber1}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber2</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber2" name="phoneNumber2"
                    value={phoneNumber2} onChange={handleChangePhoneNumber2}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remarks</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormTextarea placeholder="Remarks" name="Remarks" value={Remarks}
                    onChange={handleChangeRemarks}
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
                  <CFormCheck checked={isActive} onChange={handleChangeIsActive} label="Status"
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />
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
export default EmployeePopupTab_Contact_Grid_Popup
