import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdown, CDropdownItem, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { modifyUserRole } from '../../../apicalls/userrole/modify.js';
import { deleteUserRole } from '../../../apicalls/userrole/delete.js';
import { addNewUserRole } from '../../../apicalls/userrole/add_new.js';

import { getLabelText } from 'src/MultipleLanguageSheets'
import PopUpAlert from '../../shared/PopUpAlert.js'

const UserRolePopup_Details = ({ visible, onClose, onOpen, UserRoleDetails, popupStatus, StatusInDB }) => {
  let templatetype = 'translation_userrole'
  let templatetype_base = 'translation'

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [UserRoleId, setUserRoleId] = useState('')
  const [UserRole, setUserRole] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeUserRole = (event) => { setUserRole(event.target.value) }
  const handleChangeId = (event) => { setUserRoleId(event.target.value) }
  const handleChangeIsActive = (event) => { setIsActive(event.target.checked) }



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
      UUR_UserRoleID: UserRoleId,
      UUR_UserRole: UserRole,
      UUR_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyUserRole(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteUserRole(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewUserRole(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  useEffect(() => {
    // console.log(UserRoleDetails)
    setUserRoleId(UserRoleDetails.UUR_UserRoleID)
    setUserRole(UserRoleDetails.UUR_UserRole)
    setIsActive(StatusInDB)
  }, [UserRoleDetails]);

  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
  // console.log(UserRoleDetails)


  return (
    <>
      <CTabPanel className="p-3" itemKey="general">
        {/* <CButton color="primary" onClick={onOpen}>New Access Group</CButton> */}
        <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
        <CForm onSubmit={handleSubmit}>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>UserRoleID</h6>
              </CInputGroupText>
            </CCol>   <CFormInput placeholder="UserRoleID" name="UserRoleID" value={UserRoleId} onChange={handleChangeId}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>UserRole</h6>
              </CInputGroupText>
            </CCol>
            <CFormInput placeholder="UserRole" name="UserRole" value={UserRole} onChange={handleChangeUserRole}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Status</h6>
              </CInputGroupText>
            </CCol>
            <CFormCheck checked={isActive} onChange={handleChangeIsActive} label="Status" defaultChecked
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
export default UserRolePopup_Details
