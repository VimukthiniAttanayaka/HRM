import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdown, CDropdownItem, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { modifyAccessGroup } from '../../../apicalls/accessgroup/modify.js';
import { deleteAccessGroup } from '../../../apicalls/accessgroup/delete.js';
import { addNewAccessGroup } from '../../../apicalls/accessgroup/add_new.js';

import PopUpAlert from '../../shared/PopUpAlert.js'
import { getLabelText } from 'src/MultipleLanguageSheets'

const AccessGroupPopup_Details = ({ visible, onClose, onOpen, AccessGroupDetails, popupStatus, StatusInDB }) => {
  let templatetype = 'translation_accessgroup'
  let templatetype_base = 'translation'

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [AccessGroupId, setAccessGroupId] = useState('')
  const [AccessGroup, setAccessGroup] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAccessGroup = (event) => { setAccessGroup(event.target.value) }
  const handleChangeId = (event) => { setAccessGroupId(event.target.value) }
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
      UAG_AccessGroupID: AccessGroupId,
      UAG_AccessGroup: AccessGroup,
      UAG_Status: isActive,
      UD_UserID: staffId,
    }
    console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyAccessGroup(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteAccessGroup(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewAccessGroup(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  useEffect(() => {
    // console.log(AccessGroupDetails)
    setAccessGroupId(AccessGroupDetails.UAG_AccessGroupID)
    setAccessGroup(AccessGroupDetails.UAG_AccessGroup)
    setIsActive(StatusInDB)
  }, [AccessGroupDetails]);

  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');

  return (
    <>
      <CTabPanel className="p-3" itemKey="general">
        {/* <CButton color="primary" onClick={onOpen}>New Access Group</CButton> */}
        <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />

        <CForm onSubmit={handleSubmit}>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>AccessGroupId</h6>
              </CInputGroupText>
            </CCol>   <CFormInput placeholder="AccessGroupId" name="AccessGroupId" value={AccessGroupId} onChange={handleChangeId}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>AccessGroup</h6>
              </CInputGroupText>
            </CCol>    <CFormInput placeholder="AccessGroup" name="AccessGroup" value={AccessGroup} onChange={handleChangeAccessGroup}
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
export default AccessGroupPopup_Details
