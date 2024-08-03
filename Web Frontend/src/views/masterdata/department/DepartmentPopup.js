import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const DepartmentPopup = ({ visible, onClose, onOpen, DepartmentDetails, popupStatus }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  let templatetype = 'translation_department'

  const [DepartmentId, setDepartmentId] = useState('')
  const [Department, setDepartment] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeDepartment = (event) => {
    setDepartment(event.target.value)
  }
  const handleChangeId = (event) => {
    setDepartmentId(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }
  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_DepartmentID: DepartmentId,
      MDD_Department: Department,
      MDD_LocationID: "string",
      MDD_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Department/add_new_Department', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
    }
  }
  const handleEdit = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_DepartmentID: DepartmentId,
      MDD_Department: Department,
      MDD_LocationID: "string",
      MDD_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Department/modify_department', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
    }
  }
  const handleDelete = async (event) => {
    console.log('Delete Department')
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDD_DepartmentID: DepartmentId
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Department/inactivate_department', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Department data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Department data:', response.statusText)
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
      return getLabelText('Edit Department', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Department', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Department', templatetype)
    } else {
      return getLabelText('Create New Department', templatetype)
    }
  }

  useEffect(() => {
    setDepartmentId(DepartmentDetails.MDD_DepartmentID)
    setDepartment(DepartmentDetails.MDD_Department)
    setIsActive(DepartmentDetails.MDD_Status)
  }, [DepartmentDetails]);
  // console.log(DepartmentDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>  {getLabelText('New Department', templatetype)}
        {/* New Department */}
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
                      <h6>{getLabelText('DepartmentID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder={getLabelText("DepartmentID", templatetype)} name="DepartmentID" value={DepartmentDetails.MDD_DepartmentID} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Department', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder={getLabelText("Department", templatetype)} name="Department" value={Department} onChange={handleChangeDepartment} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}

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
export default DepartmentPopup
