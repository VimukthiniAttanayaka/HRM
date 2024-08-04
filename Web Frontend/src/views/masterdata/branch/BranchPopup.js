import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const BranchPopup = ({ visible, onClose, onOpen, branchDetails, popupStatus }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  let templatetype = 'translation_branch'
  let templatetype_base = 'translation'

  const [branchId, setBranchId] = useState('')
  const [branch, setBranch] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeBranch = (event) => {
    setBranch(event.target.value)
  }
  const handleChangeId = (event) => {
    setBranchId(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }
  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDB_BranchID: branchId,
      MDB_Branch: branch,
      MDB_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Branch/add_new_Branch', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Branch data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Branch data:', response.statusText)
    }
  }
  const handleEdit = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDB_BranchID: branchId,
      MDB_Branch: branch,
      MDB_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Branch/modify_Branch', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Branch data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Branch data:', response.statusText)
    }
  }
  const handleDelete = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      MDB_BranchID: branchId,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Branch/inactivate_Branch', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Branch data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Branch data:', response.statusText)
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
    setIsActive(branchDetails.MDB_Status)
  }, [branchDetails]);
  // console.log(branchDetails)
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
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('BranchID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="BranchID" name="BranchID" value={branchId} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Branch', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Branch" name="Branch" value={branch} onChange={handleChangeBranch} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}
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
export default BranchPopup
