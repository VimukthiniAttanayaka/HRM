import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { modifyUserMenu } from '../../../apicalls/usermenu/modify.js';
import { deleteUserMenu } from '../../../apicalls/usermenu/delete.js';
import { addNewUserMenu } from '../../../apicalls/usermenu/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const UserMenuPopup = ({ visible, onClose, onOpen, UserMenuDetails, popupStatus, StatusInDB }) => {
  let templatetype = 'translation_usermenu'
  let templatetype_base = 'translation'
  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [UserMenuId, setUserMenuId] = useState('')
  const [UserMenu, setUserMenu] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeUserMenu = (event) => {
    setUserMenu(event.target.value)
  }
  const handleChangeId = (event) => {
    setUserMenuId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

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
      UUM_UserMenuID: UserMenuId,
      UUM_UserMenu: UserMenu,
      UUM_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyUserMenu(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteUserMenu(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewUserMenu(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  useEffect(() => {
    // console.log(UserMenuDetails)
    setUserMenuId(UserMenuDetails.UUM_UserMenuID)
    setUserMenu(UserMenuDetails.UUM_UserMenu)
    setIsActive(StatusInDB)
  }, [UserMenuDetails]);

  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
  // console.log(UserMenuDetails)
  
  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit UserMenu', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View UserMenu', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete UserMenu', templatetype)
    } else {
      return getLabelText('Create New UserMenu', templatetype)
    }
  }
  
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New UserMenu</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}</CModalTitle>
          {/* <CModalTitle id="TooltipsAndPopoverExample">Create New UserMenu</CModalTitle> */}
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />

              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserMenuID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="UserMenuID" name="UserMenuID" value={UserMenuId} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserMenu</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="UserMenu" name="UserMenu" value={UserMenu} onChange={handleChangeUserMenu}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck label="Status" defaultChecked />
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
export default UserMenuPopup
