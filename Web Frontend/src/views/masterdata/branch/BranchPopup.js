import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';

import { modifyBranch } from '../../../apicalls/branch/modify.js';
import { deleteBranch } from '../../../apicalls/branch/delete.js';
import { addNewBranch } from '../../../apicalls/branch/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const BranchPopup = ({ visible, onClose, onOpen, branchDetails, popupStatus, StatusInDB }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  let templatetype = 'translation_branch'
  let templatetype_base = 'translation'

  const [branchId, setBranchId] = useState('')
  const [branch, setBranch] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeBranch = (event) => { setBranch(event.target.value) }
  const handleChangeId = (event) => { setBranchId(event.target.value) }
  const handleChangeStatus = (event) => { setIsActive(event.target.checked) }

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
      MDB_BranchID: branchId,
      MDB_Branch: branch,
      MDB_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyBranch(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteBranch(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewBranch(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }


  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit Branch', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Branch', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Branch', templatetype)
    } else {
      return getLabelText('Create New Branch', templatetype)
    }
  }

  useEffect(() => {
    setBranchId(branchDetails.MDB_BranchID)
    setBranch(branchDetails.MDB_Branch)
    setIsActive(StatusInDB)
  }, [branchDetails]);
  // console.log(branchDetails)

  const [open, setOpen] = useState(false);
  const [openEmp_Popup, setOpenEmp_Popup] = useState(false);

  const handleClose = () => {
    setOpen(false);
    onClose();
  };

  const [DialogTitle, setDialogTitle] = useState('');
  const [DialogContent, setDialogContent] = useState('');
  // console.log(UserMenuDetails)

  return (
    <>
      <CButton color="primary" onClick={onOpen}>{getLabelText('New Branch', templatetype)}</CButton>
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
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('BranchID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="BranchID" name="BranchID" value={branchId} onChange={handleChangeId}
                    disabled={popupStatus == 'create' ? false : true}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Branch', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Branch" name="Branch" value={branch} onChange={handleChangeBranch}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />
                </CInputGroup>

                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Status', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck checked={isActive} defaultChecked onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                </CInputGroup>
                <div className="d-grid">
                  {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>{getLabelText('Delete', templatetype)}</CButton> :
                    <CButton color="success" type='submit'>{getLabelText('Submit', templatetype)}</CButton>)}
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default BranchPopup
