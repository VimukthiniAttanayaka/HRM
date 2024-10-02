import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { modifySalaryType } from '../../../apicalls/salarytype/modify.js';
import { deleteSalaryType } from '../../../apicalls/salarytype/delete.js';
import { addNewSalaryType } from '../../../apicalls/salarytype/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const SalaryTypePopup = ({ visible, onClose, onOpen, SalaryTypeDetails, popupStatus, StatusInDB }) => {

  let templatetype = 'translation_salarytype'
  let templatetype_base = 'translation'
  const apiUrl = process.env.REACT_APP_API_URL;

  const [SalaryTypeId, setSalaryTypeId] = useState('')
  const [SalaryType, setSalaryType] = useState('')
  const [Description, setDescription] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeSalaryType = (event) => {
    setSalaryType(event.target.value)
  }
  const handleChangeDescription = (event) => {
    setDescription(event.target.value)
  }
  const handleChangeId = (event) => {
    setSalaryTypeId(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }
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
      MDST_SalaryTypeID: SalaryTypeId,
      MDST_SalaryType: SalaryType,
      MDST_Description: Description,
      MDST_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifySalaryType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteSalaryType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewSalaryType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }


  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit SalaryType', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View SalaryType', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete SalaryType', templatetype)
    } else {
      return getLabelText('Create New SalaryType', templatetype)
    }
  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setSalaryTypeId('')
      setSalaryType('')
      setDescription('')
      setIsActive(true)
    } else {
      setSalaryTypeId(SalaryTypeDetails.MDST_SalaryTypeID)
      setSalaryType(SalaryTypeDetails.MDST_SalaryType)
      setDescription(SalaryTypeDetails.MDST_Description)
      setIsActive(StatusInDB)
    }
  }, [SalaryTypeDetails]);
  // console.log(SalaryTypeDetails)

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
      <CButton color="primary" onClick={onOpen}>New SalaryType</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New SalaryType</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>SalaryTypeID</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="SalaryTypeID" name="SalaryTypeID" value={SalaryTypeId} onChange={handleChangeId}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>SalaryType</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="SalaryType" name="SalaryType" value={SalaryType} onChange={handleChangeSalaryType}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Description</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="Description" name="Description" value={Description} onChange={handleChangeDescription}
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
export default SalaryTypePopup
