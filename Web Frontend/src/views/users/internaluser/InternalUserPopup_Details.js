import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CTabPanel, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker, CFormTextarea } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { Dropdowns_UserRole } from '../../../apicalls/userrole/dropdowns.js';
import { Dropdowns_Employee } from '../../../apicalls/employee/dropdowns.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import { modifyInternalUser } from '../../../apicalls/internaluser/modify.js';
import { deleteInternalUser } from '../../../apicalls/internaluser/delete.js';
import { addNewInternalUser } from '../../../apicalls/internaluser/add_new.js';
// import EmployeeGridModel from '../../sharedgridselectables/CustomerGridModel.js';
import { getEmployeeSingle } from '../../../apicalls/employee/get_employee_single.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { format, parse } from 'date-fns'
import CollapseDropdownList from 'src/views/shared/CollapseDropdownList.js';

const InternalUserPopup_Details = ({ visible, onClose, onOpen, InternalUserDetails, popupStatus, StatusInDB }) => {
  let templatetype = 'translation_internaluser'
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
  const [EmployeeID, setEmployeeID] = useState('')
  const [EmployeeName, setEmployeeName] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeIsActive = (event) => { setIsActive(event.target.checked) }
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

    const formData = {
      UE_UserID: UserID, UE_FirstName: FirstName, UE_LastName: LastName,
      UE_EmailAddress: EmailAddress, UE_MobileNumber: MobileNumber, UE_PhoneNumber: PhoneNumber, UE_Remarks: Remarks,
      UE_ActiveFrom: ActiveFrom.toJSON(), UE_ActiveTo: ActiveTo.toJSON(),
      UE_Status: isActive,
      UD_UserID: staffId,
      UE_EmployeeID: EmployeeID,
      UE_UserRoleID: UserRoleID
    }
    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyInternalUser(formData)
      console.log(APIReturn)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteInternalUser(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewInternalUser(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  // console.log(InternalUserDetails)
  const [optionsUserRole, setOptionsUserRole] = useState([]);
  const [optionsEmployee, setOptionsEmployee] = useState([]);

  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const UserRoleDetails = await Dropdowns_UserRole(formData)

    setOptionsUserRole(UserRoleDetails);

    const EmployeeDetails = await Dropdowns_Employee(formData)
    setOptionsEmployee(EmployeeDetails);

  }

  async function loadDetails_Employee(item) {
    if (item !== undefined) {
      // console.log(item)
      const token = getJWTToken();
      const staffId = getStaffID();
      const customerId = getCustomerID();

      const formData = {
        // UD_StaffID: staffId,
        // AUD_notificationToken: token,
        EME_EmployeeID: item
      }
      const EmployeeDetails = await getEmployeeSingle(formData)
      // console.log(EmployeeDetails)
      setEmployeeID(EmployeeDetails.EME_EmployeeID)
      setEmployeeName(EmployeeDetails.EME_PrefferedName)
      handleCloseEmp_Popup();
    }
  }

  useEffect(() => {
    // console.log(InternalUserDetails)
    setFirstName(InternalUserDetails.UE_FirstName)
    setLastName(InternalUserDetails.UE_LastName)
    setEmailAddress(InternalUserDetails.UE_EmailAddress)
    setMobileNumber(InternalUserDetails.UE_MobileNumber)
    setRemarks(InternalUserDetails.UE_Remarks)
    setEmployeeID(InternalUserDetails.UE_EmployeeID)
    setPhoneNumber(InternalUserDetails.UE_PhoneNumber)
    setUserID(InternalUserDetails.UE_UserID)
    setActiveFrom(InternalUserDetails.UE_ActiveFrom)
    setActiveTo(InternalUserDetails.UE_ActiveTo)
    // setIsActive(InternalUserDetails.UE_status)
    // loadDetails_Employee(InternalUserDetails.UE_EmployeeID)
    setUserRole(InternalUserDetails.UserRole)
    setUserRoleID(InternalUserDetails.UE_UserRoleID)
    setIsActive(StatusInDB)
    requestdata();
  }, [InternalUserDetails]);

  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose();
  };
  const handleCloseEmp_Popup = () => {
    setOpenEmp_Popup(false);
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');


  const EmployeeSearchOnClick = () => {
    // console.log(true)
    setOpenEmp_Popup(true);
  };
  // const handleClick = () => {
  //   // Your JavaScript code here
  //   console.log('Button clicked!');
  // };

  return (
    <>
      <CTabPanel className="p-3" itemKey="general">

        <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />

        {/* <EmployeeGridModel open={openEmp_Popup} handleClose={handleCloseEmp_Popup} loadDetails={loadDetails_Employee}></EmployeeGridModel> */}

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
                <h6>Employee</h6>
              </CInputGroupText>
            </CCol>

            {/* <CFormInput placeholder="EmployeeName" name="EmployeeName" value={EmployeeName} disabled />

            <CButton color="success" onClick={EmployeeSearchOnClick}>{getLabelText('Search', templatetype)}</CButton> */}
            {popupStatus == 'create' ?
              <CollapseDropdownList optionsList={optionsEmployee}
                setSelectedOption={setEmployeeID} setSelectedValue={setEmployeeName}
                selectedOption={EmployeeID} SelectedValue={EmployeeName}
                disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}></CollapseDropdownList>
              : <CFormInput placeholder="UserRole" name="UserRole" value={UserRole}
                disabled={true} />}
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>User Role</h6>
              </CInputGroupText>
            </CCol>

            {/* <CFormSelect value={selectedOptionUserRole} onChange={(e) => setSelectedOptionUserRole(e.target.value)}>
              {optionsUserRole.map((option) => (
                <option key={option.key} value={option.key}>
                  {option.value}
                </option>
              ))}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
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
            <CFormTextarea placeholder="Remarks" name="Remarks" value={Remarks} onChange={handleChangeRemarks}
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
export default InternalUserPopup_Details
