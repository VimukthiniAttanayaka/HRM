import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CFormSelect, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';
import { requestdata_Employee_DropDowns_All } from '../../../apicalls/employee/get_all_list.js';
import { requestdata_UserRoles_DropDowns_All } from '../../../apicalls/userrole/get_all_list.js';

const InternalUserPopup = ({ visible, onClose, onOpen, InternalUserDetails }) => {

  // const handleSubmit = (event) => {
  //   event.preventDefault();

  // };
  const [selectedOptionEmployeeID, setSelectedOptionEmployeeID] = useState('');
  const [selectedOptionUserRole, setSelectedOptionUserRole] = useState('');

  const [FirstName, setFirstName] = useState('')
  const [LastName, setLastName] = useState('')
  const [EmailAddress, setEmailAddress] = useState('')
  const [MobileNumber, setMobileNumber] = useState('')
  const [Remarks, setRemarks] = useState('')
  const [EmployeeID, setEmployeeID] = useState('')
  const [PhoneNumber, setPhoneNumber] = useState('')
  const [UserName, setUserName] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeIsActive = (event) => { }
  const handleChangeEmployeeID = (event) => {
    setEmployeeID(event.target.value)
  }
  const handleChangeFirstName = (event) => {
    setFirstName(event.target.value)
  }
  const handleChangeLastName = (event) => {
    setLastName(event.target.value)
  }
  const handleChangeEmailAddress = (event) => {
    setEmailAddress(event.target.value)
  }
  const handleChangeMobileNumber = (event) => {
    setMobileNumber(event.target.value)
  }
  const handleChangeRemarks = (event) => {
    setRemarks(event.target.value)
  }
  const handleChangePhoneNumber = (event) => {
    setPhoneNumber(event.target.value)
  }
  const handleChangeUserName = (event) => {
    setUserName(event.target.value)
  }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      LVT_InternalUserID: InternalUserId,
      LVT_LeaveAlotment: leaveAlotmentId,
      LVT_InternalUser: InternalUser,
      LVT_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'InternalUser/add_new_InternalUser', {
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

  const [optionsEmployeeID, setOptionsEmployeeID] = useState([]);
  const [optionsUserRole, setOptionsUserRole] = useState([]);

  async function requestdata() {
    const formData = {
      USR_EmployeeID: 'sedcx'
    }

    const UserRoleDetails = await requestdata_UserRoles_DropDowns_All(formData)

    setOptionsUserRole(UserRoleDetails);

    const EmployeeDetails = await requestdata_Employee_DropDowns_All(formData)

    setOptionsEmployeeID(EmployeeDetails);

  }

  useEffect(() => {
    requestdata();
  }, []);

  // console.log(InternalUserDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>New Internal User</CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">Create New Internal User</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CCard className="mx-4">
            <CCardBody className="p-4">
              <CForm onSubmit={handleSubmit}>
                {/* <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmployeeID</h6>
                    </CInputGroupText>
                  </CCol>

                  <CFormInput placeholder="EmployeeID" name="EmployeeID" value={InternalUserDetails.UD_EmployeeID ? InternalUserDetails.UD_EmployeeID:''} onChange={handleChangeEmployeeID}

                  />

                </CInputGroup> */}
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>UserName</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="UserName" name="UserName" value={InternalUserDetails.UD_UserName ? InternalUserDetails.UD_UserName : ''} onChange={handleChangeUserName}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>User Role</h6>
                    </CInputGroupText>
                  </CCol>

                  <CFormSelect value={selectedOptionUserRole} onChange={(e) => setSelectedOptionUserRole(e.target.value)}>
                    {optionsUserRole.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Employee ID</h6>
                    </CInputGroupText>
                  </CCol>

                  <CFormSelect value={selectedOptionEmployeeID} onChange={(e) => setSelectedOptionEmployeeID(e.target.value)}>
                    {optionsEmployeeID.map((option) => (
                      <option key={option.key} value={option.key}>
                        {option.value}
                      </option>
                    ))}
                  </CFormSelect>
                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>FirstName</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="FirstName" name="FirstName" value={InternalUserDetails.UD_FirstName ? InternalUserDetails.UD_FirstName:''} onChange={handleChangeFirstName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>LastName</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="LastName" name="LastName" value={InternalUserDetails.UD_LastName ? InternalUserDetails.UD_LastName:''} onChange={handleChangeLastName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>EmailAddress</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="EmailAddress" name="EmailAddress" value={InternalUserDetails.UD_EmailAddress ? InternalUserDetails.UD_EmailAddress:''} onChange={handleChangeEmailAddress}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>MobileNumber</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="MobileNumber" name="MobileNumber" value={InternalUserDetails.UD_MobileNumber ? InternalUserDetails.UD_MobileNumber:''} onChange={handleChangeMobileNumber}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>PhoneNumber</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="PhoneNumber" name="PhoneNumber" value={InternalUserDetails.UD_PhoneNumber ? InternalUserDetails.UD_PhoneNumber:''} onChange={handleChangePhoneNumber}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Remarks</h6>
                    </CInputGroupText>
                  </CCol>  <CFormInput placeholder="Remarks" name="Remarks" value={InternalUserDetails.UD_Remarks ? InternalUserDetails.UD_Remarks:''} onChange={handleChangeRemarks}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />

                </CInputGroup>
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
export default InternalUserPopup
