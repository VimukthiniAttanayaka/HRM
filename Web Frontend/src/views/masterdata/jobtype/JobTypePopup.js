import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { modifyJobType } from '../../../apicalls/jobtype/modify.js';
import { deleteJobType } from '../../../apicalls/jobtype/delete.js';
import { addNewJobType } from '../../../apicalls/jobtype/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const JobTypePopup = ({ visible, onClose, onOpen, JobTypeDetails, popupStatus, StatusInDB }) => {

  let templatetype = 'translation_jobtype'
  let templatetype_base = 'translation'
  const apiUrl = process.env.REACT_APP_API_URL;

  const [JobTypeId, setJobTypeId] = useState('')
  const [JobType, setJobType] = useState('')
  const [Description, setDescription] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeJobType = (event) => {
    setJobType(event.target.value)
  }
  const handleChangeDescription = (event) => {
    setDescription(event.target.value)
  }
  const handleChangeId = (event) => {
    setJobTypeId(event.target.value)
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
      MDJT_JobTypeID: JobTypeId,
      MDJT_JobType: JobType,
      MDJT_Description: Description,
      MDJT_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyJobType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteJobType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewJobType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }


  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit JobType', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View JobType', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete JobType', templatetype)
    } else {
      return getLabelText('Create New JobType', templatetype)
    }
  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setJobTypeId('')
      setJobType('')
      setDescription('')
      setIsActive(true)
    } else {
      setJobTypeId(JobTypeDetails.MDJT_JobTypeID)
      setJobType(JobTypeDetails.MDJT_JobType)
      setDescription(JobTypeDetails.MDJT_Description)
      setIsActive(StatusInDB)
    }
  }, [JobTypeDetails]);
  // console.log(JobTypeDetails)

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
      <CButton color="primary" onClick={onOpen}>New JobType</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New JobType</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobTypeID</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="JobTypeID" name="JobTypeID" value={JobTypeId} onChange={handleChangeId}
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobType</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="JobType" name="JobType" value={JobType} onChange={handleChangeJobType}
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
export default JobTypePopup
