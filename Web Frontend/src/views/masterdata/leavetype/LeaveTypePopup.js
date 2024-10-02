import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
// import data from './_data.js'
// import { Modal } from '@coreui/coreui-pro';
import { modifyLeaveType } from '../../../apicalls/leavetype/modify.js';
import { deleteLeaveType } from '../../../apicalls/leavetype/delete.js';
import { addNewLeaveType } from '../../../apicalls/leavetype/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

import PopUpAlert from '../../shared/PopUpAlert.js'

const LeaveTypePopup = ({ visible, onClose, onOpen, LeaveTypeDetails, popupStatus, StatusInDB }) => {

  let templatetype = 'translation_leavetype'
  let templatetype_base = 'translation'
  const apiUrl = process.env.REACT_APP_API_URL;

  const [LeaveTypeId, setLeaveTypeId] = useState('')
  const [LeaveType, setLeaveType] = useState('')
  const [LeaveAlotment, setLeaveAlotment] = useState(0)
  const [Duration, setDuration] = useState(0)
  const [Description, setDescription] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeLeaveType = (event) => {
    setLeaveType(event.target.value)
  }
  const handleChangeDuration = (event) => {
    setDuration(event.target.value)
  }
  const handleChangeLeaveAlotment = (event) => {
    setLeaveAlotment(event.target.value)
  }
  const handleChangeDescription = (event) => {
    setDescription(event.target.value)
  }
  const handleChangeId = (event) => {
    setLeaveTypeId(event.target.value)
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
      MDLT_LeaveTypeID: LeaveTypeId,
      MDLT_LeaveType: LeaveType,
      MDLT_Description: Description,
      MDLT_Duration: parseInt(Duration),
      MDLT_LeaveAlotment: parseInt(LeaveAlotment),
      MDLT_Status: isActive,
      UD_UserID: staffId,
    }
    // console.log(formData)
    if (popupStatus == 'edit') {
      const APIReturn = await modifyLeaveType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteLeaveType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewLeaveType(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }


  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit LeaveType', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View LeaveType', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete LeaveType', templatetype)
    } else {
      return getLabelText('Create New LeaveType', templatetype)
    }
  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setLeaveTypeId('')
      setLeaveType('')
      setDescription('')
      setDuration('')
      setLeaveAlotment('')
      setIsActive(true)
    } else {
      setLeaveTypeId(LeaveTypeDetails.MDLT_LeaveTypeID)
      setLeaveType(LeaveTypeDetails.MDLT_LeaveType)
      setDescription(LeaveTypeDetails.MDLT_Description)
      setDuration(LeaveTypeDetails.MDLT_Duration)
      setLeaveAlotment(LeaveTypeDetails.MDLT_LeaveAlotment)
      setIsActive(StatusInDB)
    }
  }, [LeaveTypeDetails]);
  // console.log(LeaveTypeDetails)

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
      <CButton color="primary" onClick={onOpen}>New LeaveType</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New LeaveType</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <PopUpAlert open={open} handleClose={handleClose} dialogTitle={DialogTitle} dialogContent={DialogContent} />
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveTypeID</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="LeaveTypeID" name="LeaveTypeID" value={LeaveTypeId} onChange={handleChangeId}
                    disabled={(popupStatus == 'edit' || popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LeaveType</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput placeholder="LeaveType" name="LeaveType" value={LeaveType} onChange={handleChangeLeaveType}
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
                      <h6>LeaveAlotment</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="LeaveAlotment" name="LeaveAlotment" value={LeaveAlotment} onChange={handleChangeLeaveAlotment} type='number'
                    disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Duration</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="Duration" name="Duration" value={Duration} onChange={handleChangeDuration} type='number'
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
export default LeaveTypePopup
