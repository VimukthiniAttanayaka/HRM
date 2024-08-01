import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const DepartmentPopup = ({ visible, onClose, onOpen, DepartmentDetails, popupStatus }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [DepartmentId, setDepartmentId] = useState('')
  const [Department, setDepartment] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeAlotment = (event) => {
    setLeaveAlotmentId(event.target.value)
  }
  const handleChangeDepartment = (event) => {
    setDepartment(event.target.value)
  }
  const handleChangeId = (event) => {
    setDepartmentId(event.target.value)
  }
  const handleCreate = async (event) => {
    console.log('Create Department')
    // Prepare form data
    const formData = {
      MDD_DepartmentID: DepartmentId,
      MDD_LeaveAlotment: leaveAlotmentId,
      MDD_Department: Department,
      MDD_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Department/add_new_Department', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Leave Type data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Leave Type data:', response.statusText)
    }
  }
  const handleEdit = (event) => {
    console.log('Edit Department')
  }
  const handleDelete = (event) => {
    console.log('Delete Department')
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
      return 'Edit Department'
    } else if (popupStatus == 'view') {
      return 'View Department'
    } else if (popupStatus == 'delete') {
      return 'Delete Department'
    } else {
      return 'Create New Department'
    }
  }

  // console.log(DepartmentDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Department</CButton>
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
                      <h6>DepartmentID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="DepartmentID" name="DepartmentID" value={DepartmentDetails.MDD_DepartmentID} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Department</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Department" name="Department" value={DepartmentDetails.MDD_Department} onChange={handleChangeDepartment} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}

                  // readOnly={isEditable,isAddNew,IsView}// value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck label="Status" defaultChecked disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                </CInputGroup>
                <div className="d-grid">
                  {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>Delete</CButton> :
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
export default DepartmentPopup
