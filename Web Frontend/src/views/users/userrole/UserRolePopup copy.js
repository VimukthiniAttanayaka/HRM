import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const UserRolePopup = ({ visible, onClose, onOpen, UserRoleDetails , checkAccessGroupListItems }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [UserRoleId, setUserRoleId] = useState('')
  const [UserRole, setUserRole] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeUserRole = (event) => {
    setUserRole(event.target.value)
  }
  const handleChangeId = (event) => {
    setUserRoleId(event.target.value)
  }
  const handleChangeIsActive = (event) => { }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      EUR_UserRoleID: UserRoleId,
      EUR_UserRole: UserRole,
      EUR_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'UserRole/add_new_UserRole', {
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

  // console.log(UserRoleDetails)
  const [checkedItems, setCheckedItems] = useState([]);

  const handleCheckboxChange = (event) => {
    const { checked, value } = event.target;
    if (checked) {
      setCheckedItems([...checkedItems, value]);
    } else {
      setCheckedItems(checkedItems.filter(item => item !== value));
    }
  };

  const options = [
    { value: 'option1', label: 'Option 1' },
    { value: 'option2', label: 'Option 2' },
    { value: 'option3', label: 'Option 3' },
  ];

  return (
    <>
      <CButton color="primary" onClick={onOpen}>New UserRole</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New UserRole</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserRoleID</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="UserRoleID" name="UserRoleID" value={UserRoleDetails.EUR_UserRoleID} onChange={handleChangeId}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserRole</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="UserRole" name="UserRole" value={UserRoleDetails.EUR_UserRole} onChange={handleChangeUserRole}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup>
                {/* <CInputGroup className="mb-3"> */}
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>User Groups</h6>
                    </CInputGroupText>
                  </CCol>
                  {checkAccessGroupListItems.map((option) => (
                  <CFormCheck
                    key={option.value}
                    type="checkbox"
                    label={option.label}
                    value={option.value}
                    // checked={checkedItems.includes(option.value)}
                    checked={option.Ischecked}
                    onChange={handleCheckboxChange}
                  />
                ))}
                {/* </CInputGroup> */}
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Status</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck label="Status" defaultChecked />
                </CInputGroup>
                <div className="d-grid">
                  <CButton color="success" type='submit'>Submit</CButton>
                </div>
              </CForm>
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default UserRolePopup
