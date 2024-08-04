import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const JobRolePopup = ({ visible, onClose, onOpen, JobRoleDetails, popupStatus }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  let templatetype = 'translation_jobrole'
  let templatetype_base = 'translation'

  const [JobRoleId, setJobRoleId] = useState('')
  const [JobRole, setJobRole] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeJobRole = (event) => {
    setJobRole(event.target.value)
  }
  const handleChangeId = (event) => {
    setJobRoleId(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }
  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDJR_JobRoleID: JobRoleId,
      MDJR_JobRole: JobRole,
      MDJR_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'JobRole/add_new_JobRole', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('JobRole data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting JobRole data:', response.statusText)
    }
  }
  const handleEdit = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDJR_JobRoleID: JobRoleId,
      MDJR_JobRole: JobRole,
      MDJR_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'JobRole/modify_JobRole', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('JobRole data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting JobRole data:', response.statusText)
    }
  }
  const handleDelete = async (event) => {
    console.log('Delete JobRole')
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDJR_JobRoleID: JobRoleId,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'JobRole/inactivate_JobRole', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('JobRole data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting JobRole data:', response.statusText)
    }
  }

  const handleSubmit = async (event) => {
    event.preventDefault()

    if (popupStatus == 'create') {
      handleCreate(event)
    } else if (popupStatus == 'edit') {
      handleEdit(event)
    } else if (popupStatus == 'delete') {
      handleDelete(event)
    }
    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

  }

  const popupStatusSetup = (event) => {
    if (popupStatus == 'edit') {
      return getLabelText('Edit JobRole', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View JobRole', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete JobRole', templatetype)
    } else {
      return getLabelText('Create New JobRole', templatetype)
    }
  }

  useEffect(() => {
    setJobRoleId(JobRoleDetails.MDJR_JobRoleID)
    setJobRole(JobRoleDetails.MDJR_JobRole)
    setIsActive(JobRoleDetails.MDJR_Status)
  }, [JobRoleDetails]);
  // console.log(JobRoleDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>{getLabelText('New JobRole', templatetype)}</CButton>
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
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('JobRoleID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="JobRoleID" name="JobRoleID" value={JobRoleId} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('JobRole', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="JobRole" name="JobRole" value={JobRole} onChange={handleChangeJobRole} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Status', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck checked={isActive} onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
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
export default JobRolePopup
