import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';

const LocationPopup = ({ visible, onClose, onOpen, LocationDetails, popupStatus }) => {
  const apiUrl = process.env.REACT_APP_API_URL;

  const [LocationId, setLocationId] = useState('')
  const [Location, setLocation] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeLocation = (event) => {
    setLocation(event.target.value)
  }
  const handleChangeId = (event) => {
    setLocationId(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }
  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDL_LocationID: LocationId,
      MDL_Location: Location,
      MDL_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'location/add_new_Location', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Location data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Location data:', response.statusText)
    }
   }
  const handleEdit = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDL_LocationID: LocationId,
      MDL_Location: Location,
      MDL_Status: isActive,
    }
  // Submit the form data to your backend API
  const response = await fetch(apiUrl + 'location/modify_Location', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })

  if (response.ok) {
    onClose()
    console.log(response);
    // Handle successful submission (e.g., display a success message)
    console.log('Location data submitted successfully!')
  } else {
    // Handle submission errors
    console.error('Error submitting Location data:', response.statusText)
  }
}
  const handleDelete = async (event) => {
    console.log('Delete Location')
  // Prepare form data
  const formData = {
    UD_UserID: "string",
    AUD_notificationToken: "string",
    MDL_LocationID: LocationId,
  }
  // Submit the form data to your backend API
  const response = await fetch(apiUrl + 'location/inactivate_Location', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(formData),
  })

  if (response.ok) {
    onClose()
    console.log(response);
    // Handle successful submission (e.g., display a success message)
    console.log('Location data submitted successfully!')
  } else {
    // Handle submission errors
    console.error('Error submitting Location data:', response.statusText)
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
    if (popupStatus == 'edit'){
      return 'Edit Location'
    } else if (popupStatus == 'view'){
      return 'View Location'
    } else if (popupStatus == 'delete'){
      return 'Delete Location'
    } else {
      return 'Create New Location'
    }
  }

  useEffect(() => {
    setLocationId(LocationDetails.MDL_LocationID)
    setLocation(LocationDetails.MDL_Location)
    setIsActive(LocationDetails.MDL_Status)
  }, [LocationDetails]);
  // console.log(LocationDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Location</CButton>
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
                      <h6>LocationID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="LocationID" name="LocationID" value={LocationId} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Location</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Location" name="Location" value={Location} onChange={handleChangeLocation} disabled={( popupStatus == 'view' || popupStatus == 'delete') ? true :  false}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck checked={isActive} onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                </CInputGroup>
                <div className="d-grid">
                  {popupStatus == 'view' ? '' : ( popupStatus == 'delete' ? <CButton color="danger" type='submit'>Delete</CButton> :
                  <CButton color="success" type='submit'>Submit</CButton>)}
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default LocationPopup
