import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CTabPanel, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { Dropdowns_UserRole } from '../../../apicalls/userrole/dropdowns.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import { modifyExternalUser } from '../../../apicalls/externaluser/modify.js';
import { deleteExternalUser } from '../../../apicalls/externaluser/delete.js';
import { addNewExternalUser } from '../../../apicalls/externaluser/add_new.js';

import PopUpAlert from '../../shared/PopUpAlert.js'

const ExternalUserPopup_Details = ({ visible, onClose, onOpen, ExternalUserDetails, popupStatus }) => {
  let templatetype = 'translation_jobrole'
  let templatetype_base = 'translation'

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [selectedOptionUserRole, setSelectedOptionUserRole] = useState('');
  const [FirstName, setFirstName] = useState('')
  const [LastName, setLastName] = useState('')
  const [EmailAddress, setEmailAddress] = useState('')
  const [MobileNumber, setMobileNumber] = useState('')
  const [Remarks, setRemarks] = useState('')
  const [ActiveFrom, setActiveFrom] = useState(new Date())
  const [ActiveTo, setActiveTo] = useState(new Date())
  const [PhoneNumber, setPhoneNumber] = useState('')
  const [UserID, setUserID] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeIsActive = (event) => { setIsActive(event.target.checked) }
  const handleChangeFirstName = (event) => { setFirstName(event.target.value) }
  const handleChangeLastName = (event) => { setLastName(event.target.value) }
  const handleChangeEmailAddress = (event) => { setEmailAddress(event.target.value) }
  const handleChangeMobileNumber = (event) => { setMobileNumber(event.target.value) }
  const handleChangeRemarks = (event) => { setRemarks(event.target.value) }
  const handleChangePhoneNumber = (event) => { setPhoneNumber(event.target.value) }
  const handleChangeUserID = (event) => { setUserID(event.target.value) }
  const handleChangeActiveFrom = (event) => { setActiveFrom(event.target.value) }
  const handleChangeActiveTo = (event) => { setActiveTo(event.target.value) }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    // console.log(isActive)
    const formData = {
      UE_UserID: UserID, UE_FirstName: FirstName, UE_LastName: LastName,
      UE_EmailAddress: EmailAddress, UE_MobileNumber: MobileNumber, UE_PhoneNumber: PhoneNumber, UE_Remarks: Remarks,
      UE_UserRole:selectedOptionUserRole,
      // UE_ActiveFrom: ActiveFrom, UE_ActiveTo: ActiveTo,
      UE_Status: isActive
    }

    if (popupStatus == 'edit') {
      const APIReturn = await modifyExternalUser(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteExternalUser(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewExternalUser(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  // console.log(ExternalUserDetails)
  const [optionsUserRole, setOptionsUserRole] = useState([]);

  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const UserRoleDetails = await Dropdowns_UserRole(formData)

    setOptionsUserRole(UserRoleDetails);

  }

  useEffect(() => {
    console.log(ExternalUserDetails)
    setFirstName(ExternalUserDetails.UE_FirstName)
    setLastName(ExternalUserDetails.UE_LastName)
    setEmailAddress(ExternalUserDetails.UE_EmailAddress)
    setMobileNumber(ExternalUserDetails.UE_MobileNumber)
    setRemarks(ExternalUserDetails.UE_Remarks)
    // setEmployeeID(ExternalUserDetails.UE_EmployeeID)
    setPhoneNumber(ExternalUserDetails.UE_PhoneNumber)
    setUserID(ExternalUserDetails.UE_UserID)
    setActiveFrom(ExternalUserDetails.UE_ActiveFrom)
    setActiveTo(ExternalUserDetails.UE_ActiveTo)
    setIsActive(ExternalUserDetails.UE_status)
    // console.log(ActiveFrom)
    // setActiveFrom(new Date('2023-12-25'))
    // console.log(ActiveFrom)
    requestdata();
  }, [ExternalUserDetails]);

  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');

  return (
    <>
      <CTabPanel className="p-3" itemKey="general">
        <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
        <CForm onSubmit={handleSubmit}>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>UserID</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="UserID" name="UserID" value={UserID} onChange={handleChangeUserID}
              disabled={(popupStatus == 'view' || popupStatus == 'delete' || popupStatus == 'edit') ? true : false}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>User Role</h6>
              </CInputGroupText>
            </CCol>

            <CFormSelect value={selectedOptionUserRole} onChange={(e) => setSelectedOptionUserRole(e.target.value)}>
              {optionsUserRole.map((option) => (
                <option key={option.key} value={option.key}>
                  {option.value}
                </option>
              ))}
            </CFormSelect>
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>FirstName</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="FirstName" name="FirstName" value={FirstName} onChange={handleChangeFirstName}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>LastName</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="LastName" name="LastName" value={LastName} onChange={handleChangeLastName}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>EmailAddress</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="EmailAddress" name="EmailAddress" value={EmailAddress} onChange={handleChangeEmailAddress}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>MobileNumber</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="MobileNumber" name="MobileNumber" value={MobileNumber} onChange={handleChangeMobileNumber}

            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>PhoneNumber</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="PhoneNumber" name="PhoneNumber" value={PhoneNumber} onChange={handleChangePhoneNumber}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>ActiveFrom</h6>
              </CInputGroupText>
            </CCol>
            <CDatePicker placeholder="ActiveFrom" name="ActiveFrom" value={ActiveFrom} onChange={handleChangeActiveFrom}
              // disabled={(popupStatus == 'view' || popupStatus == 'delete' || popupStatus == 'edit') ? true : false} 
              />
            <CDatePicker
              value={ActiveFrom}
              onChange={(date) => setSelectedDate(date)}
            />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>ActiveTo</h6>
              </CInputGroupText>
            </CCol>
            <CDatePicker placeholder="ActiveTo" name="ActiveTo" value={ActiveTo} onChange={handleChangeActiveTo}
              // disabled={(popupStatus == 'view' || popupStatus == 'delete' || popupStatus == 'edit') ? true : false}
               />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Remarks</h6>
              </CInputGroupText>
            </CCol>
            <CFormInput placeholder="Remarks" name="Remarks" value={Remarks} onChange={handleChangeRemarks}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Status</h6>
              </CInputGroupText>
            </CCol>
            <CFormCheck checked={isActive} onChange={handleChangeIsActive} label="Status"
             disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <div className="d-grid">
            {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>{getLabelText('Delete', templatetype)}</CButton> :
              <CButton color="success" type='submit'>{getLabelText('Submit', templatetype)}</CButton>)}
          </div>
        </CForm>
      </CTabPanel>
    </>
  )
}
export default ExternalUserPopup_Details
