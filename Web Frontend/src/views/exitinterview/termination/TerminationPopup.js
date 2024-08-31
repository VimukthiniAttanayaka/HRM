import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const TerminationPopup = ({ visible, onClose, onOpen, TerminationDetails, popupStatus }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  let templatetype = 'translation_Termination'

  const [TerminationId, setTerminationId] = useState('')
  const [Termination, setTermination] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeTermination = (event) => {
    setTermination(event.target.value)
  }
  const handleChangeId = (event) => {
    setTerminationId(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }
  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_TerminationID: TerminationId,
      MDD_Termination: Termination,
      MDD_LocationID: "string",
      MDD_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Termination/add_new_Termination', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Termination data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Termination data:', response.statusText)
    }
  }
  const handleEdit = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_TerminationID: TerminationId,
      MDD_Termination: Termination,
      MDD_LocationID: "string",
      MDD_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Termination/modify_Termination', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Termination data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Termination data:', response.statusText)
    }
  }
  const handleDelete = async (event) => {
    console.log('Delete Termination')
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_TerminationID: TerminationId
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Termination/inactivate_Termination', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Termination data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Termination data:', response.statusText)
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
      return getLabelText('Edit Termination', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Termination', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Termination', templatetype)
    } else {
      return getLabelText('Create New Termination', templatetype)
    }
  }

  useEffect(() => {
    setTerminationId(TerminationDetails.MDD_TerminationID)
    setTermination(TerminationDetails.MDD_Termination)
    setIsActive(TerminationDetails.MDD_Status)
  }, [TerminationDetails]);
  // console.log(TerminationDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>  {getLabelText('New Termination', templatetype)}
        {/* New Termination */}
      </CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}
            {/* {popupStatusSetup()} */}
          </CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('TerminationID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="TerminationID" name="TerminationID" value={TerminationDetails.MDD_TerminationID} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Termination', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Termination" name="Termination" value={Termination} onChange={handleChangeTermination} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}

                  // readOnly={isEditable,isAddNew,IsView}// value={addressBuildingName} onChange={handleChangeAddressBuildingName}
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
export default TerminationPopup
