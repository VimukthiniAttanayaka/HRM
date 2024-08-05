import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CCol, CInputGroupText, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'

const PopUp = ({ visible, onClose, onOpen }) => {
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

  const handleSubmit = (event) => {
    event.preventDefault();

  };
  return (
    <>
      {/* <CButton color="primary" onClick={onOpen}>Add New Employee</CButton> */}
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Employee</CModalTitle>
        </CModalHeader>
        <CModalBody>
          {/* <CCard className="mx-4" md={9}>
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Company Id</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Company Id" name="customerId"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Department Id</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Department Id" name="DepartmentId"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>

                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Employee ID</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Employee ID" name="EmployeeID"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>FirstName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="FirstName" name="FirstName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LastName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="LastName" name="LastName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PrefferedName</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PrefferedName" name="PrefferedName"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>JobTitle_Code</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Address</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Address" name="Address"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmailAddress</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="EmailAddress" name="EmailAddress"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>MobileNumber</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="MobileNumber" name="MobileNumber"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber1</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber1" name="PhoneNumber1"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber2</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="PhoneNumber2" name="PhoneNumber2"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>RankDescription</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="RankDescription" name="RankDescription"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>StaffLocation</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="StaffLocation" name="StaffLocation"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remarks</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="Remarks" name="Remarks"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LastResetDateTime</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="LastResetDateTime" name="LastResetDateTime"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>SyncedDateTime</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="SyncedDateTime" name="SyncedDateTime"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveFrom</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="ActiveFrom" name="ActiveFrom"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>ActiveTo</h6>
                    </CInputGroupText>
                  </CCol> <CDatePicker placeholder="ActiveTo" name="ActiveTo"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol><CFormCheck label="Status" defaultChecked />
                </CInputGroup>

                <div className="d-grid">
                  <CButton color="success" type='submit'>Submit</CButton>
                </div>
              </CForm>
            </CCardBody>
          </CCard> */}
        </CModalBody>
      </CModal>
    </>
  )
}
export default PopUp;
