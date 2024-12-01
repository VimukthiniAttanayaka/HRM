import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CFormSwitch, CCollapse, CCardFooter, CModalBody, CTabPanel, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { Dropdowns_UserRole } from '../../../apicalls/userrole/dropdowns.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import { modifyExternalUser } from '../../../apicalls/externaluser/modify.js';
import { deleteExternalUser } from '../../../apicalls/externaluser/delete.js';
import { addNewExternalUser } from '../../../apicalls/externaluser/add_new.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { format, parse } from 'date-fns'
import CollapseDropdownList from 'src/views/shared/CollapseDropdownList.js';


const ExternalUserPopup_Details = ({ visible, onClose, onOpen, ExternalUserDetails, popupStatus, StatusInDB }) => {
  let templatetype = 'translation_externaluser'
  let templatetype_base = 'translation'

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  // const [selectedOptionUserRole, setSelectedOptionUserRole] = useState('');
  const [FirstName, setFirstName] = useState('')
  const [LastName, setLastName] = useState('')
  const [EmailAddress, setEmailAddress] = useState('')
  const [MobileNumber, setMobileNumber] = useState('')
  const [Remarks, setRemarks] = useState('')
  const [ActiveFrom, setActiveFrom] = useState(new Date())
  const [ActiveTo, setActiveTo] = useState(new Date())
  const [PhoneNumber, setPhoneNumber] = useState('')
  const [UserID, setUserID] = useState('')
  const [UserRole, setUserRole] = useState('')
  const [UserRoleID, setUserRoleID] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeIsActive = (event) => { StatusInDB = event.target.checked; 
    setIsActive(event.target.checked) }
  const handleChangeFirstName = (event) => { setFirstName(event.target.value) }
  const handleChangeLastName = (event) => { setLastName(event.target.value) }
  const handleChangeEmailAddress = (event) => { setEmailAddress(event.target.value) }
  const handleChangeMobileNumber = (event) => { setMobileNumber(event.target.value) }
  const handleChangeRemarks = (event) => { setRemarks(event.target.value) }
  const handleChangePhoneNumber = (event) => { setPhoneNumber(event.target.value) }
  const handleChangeUserID = (event) => { setUserID(event.target.value) }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    // console.log(isActive)

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    if (UserRoleID === '__') {
      setDialogTitle("Alert");
      setDialogContent("Invalid UserRole");
      setOpen(true);
      return
    }
    const formData = {
      UE_UserID: UserID,
      UE_FirstName: FirstName,
      UE_LastName: LastName,
      UE_EmailAddress: EmailAddress,
      UE_MobileNumber: MobileNumber,
      UE_PhoneNumber: PhoneNumber,
      UE_Remarks: Remarks,
      UE_ActiveFrom: ActiveFrom.toJSON(),
      UE_ActiveTo: ActiveTo.toJSON(),
      UE_Status: isActive,
      UD_UserID: staffId,
      UE_UserRoleID: UserRoleID
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
    console.log(UserRoleDetails)
  }

  useEffect(() => {
    console.log(ExternalUserDetails)
    setFirstName(ExternalUserDetails.UE_FirstName)
    setLastName(ExternalUserDetails.UE_LastName)
    setEmailAddress(ExternalUserDetails.UE_EmailAddress)
    setMobileNumber(ExternalUserDetails.UE_MobileNumber)
    setRemarks(ExternalUserDetails.UE_Remarks)
    setPhoneNumber(ExternalUserDetails.UE_PhoneNumber)
    setUserID(ExternalUserDetails.UE_UserID)
    setActiveFrom(ExternalUserDetails.UE_ActiveFrom)
    setActiveTo(ExternalUserDetails.UE_ActiveTo)
    setUserRole(ExternalUserDetails.UserRole)
    setUserRoleID(ExternalUserDetails.UE_UserRoleID)
    // setIsActive(ExternalUserDetails.UE_status)
    // console.log(isActive)    
    setIsActive(StatusInDB)
    requestdata();
  }, [ExternalUserDetails]);

  const [open, setOpen] = useState(false);

  const handleClose = () => {
    setOpen(false);
    if (DialogTitle === "Alert") { } else { onClose(); }
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

            {/* <CFormInput
        label="Filter"
        value={filterValue}
        onChange={setFilterValue}
      />
          <CFormSelect 
          // value={selectedOptionUserRole}
          value={selectedOption}
              // onChange={(e) => setSelectedOptionUserRole(e.target.value)}
              onChange={setSelectedOption}
              filterOptions={filterOptions}>
              {optionsUserRole.map((option) => (
                <option key={option.key} value={option.key}>
                  {option.value}
                </option>
              ))}
            </CFormSelect> */}
            {popupStatus == 'create' ?
                <CollapseDropdownList optionsList={optionsUserRole}
                setSelectedOption={setUserRoleID} setSelectedValue={setUserRole}
                selectedOption={UserRoleID} SelectedValue={UserRole}
                disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}></CollapseDropdownList>
              : <CFormInput placeholder="UserRole" name="UserRole" value={UserRole} 
                disabled={true} />}
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>FirstName</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="FirstName" name="FirstName" value={FirstName} onChange={handleChangeFirstName}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>LastName</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="LastName" name="LastName" value={LastName} onChange={handleChangeLastName}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>EmailAddress</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="EmailAddress" name="EmailAddress" value={EmailAddress} onChange={handleChangeEmailAddress}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>MobileNumber</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="MobileNumber" name="MobileNumber" value={MobileNumber} onChange={handleChangeMobileNumber}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>PhoneNumber</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="PhoneNumber" name="PhoneNumber" value={PhoneNumber} onChange={handleChangePhoneNumber}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>ActiveFrom</h6>
              </CInputGroupText>
            </CCol>
            {(popupStatus == 'view' || popupStatus == 'delete') ?
              <CFormInput placeholder="ActiveFrom" name="ActiveFrom" value={ActiveFrom}
                disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} /> :
              <CDatePicker placeholder="ActiveFrom" name="ActiveFrom" date={ActiveFrom}
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
            {(popupStatus == 'view' || popupStatus == 'delete') ?
              <CFormInput placeholder="ActiveTo" name="ActiveTo" value={ActiveTo}
                disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} /> :
              <CDatePicker placeholder="ActiveTo" name="ActiveTo" date={ActiveTo}
                onDateChange={(date) => { setActiveTo(date) }}
                inputDateParse={(date) => parse(date, 'dd-MMM-yyyy', new Date())}
                inputDateFormat={(date) => format(new Date(date), 'dd-MMM-yyyy')}
              />}
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Remarks</h6>
              </CInputGroupText>
            </CCol>
            <CFormInput placeholder="Remarks" name="Remarks" value={Remarks} onChange={handleChangeRemarks}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />

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
            {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>{getLabelText('Delete', templatetype)}</CButton> :
              <CButton color="success" type='submit'>{getLabelText('Submit', templatetype)}</CButton>)}
          </div>
        </CForm>
      </CTabPanel>
    </>
  )
}
export default ExternalUserPopup_Details
