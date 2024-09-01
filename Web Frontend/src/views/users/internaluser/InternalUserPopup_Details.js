import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CFormSelect, CModal, CModalBody, CTabPanel, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { requestdata_Employee_DropDowns_All } from '../../../apicalls/employee/get_all_list.js';
import { requestdata_UserRoles_DropDowns_All } from '../../../apicalls/userrole/get_all_list.js';
// import { CSelect } from '@coreui/react';
// import Select from 'react-select';
// CSelect,
const InternalUserPopup_Details = ({ visible, onClose, onOpen, InternalUserDetails, popupStatus }) => {

  const apiUrl = process.env.REACT_APP_API_URL;

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

  // const handleSubmit = async (event) => {
  //   event.preventDefault()

  //   if (popupStatus == 'create') {
  //     handleCreate(event)
  //   } else if (popupStatus == 'edit') {
  //     handleEdit(event)
  //   } else if (popupStatus == 'delete') {
  //     handleDelete(event)
  //   }
  //   // Validation (optional)
  //   // You can add validation logic here to check if all required fields are filled correctly

  // }

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

  // useEffect(() => {
  //   setDepartmentId(DepartmentDetails.MDD_DepartmentID)
  //   setDepartment(DepartmentDetails.MDD_Department)
  //   setIsActive(DepartmentDetails.MDD_Status)
  // }, [DepartmentDetails]);





  const handleSubmit = async (event) => {
    event.preventDefault()

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
  const options = [
    { value: 'option1', label: 'Option 1' },
    { value: 'option2', label: 'Option 2' },
    // ... more options
  ];
  useEffect(() => {
    requestdata();
  }, []);

  // console.log(InternalUserDetails)
  return (
    <>
      <CTabPanel className="p-3" itemKey="general">
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
            {/* <CSelect
                    label="Dropdown with Filtering"
                    options={options}
                    components={{
                      DropdownIndicator: (props) => (
                        <Select.components.DropdownIndicator {...props}>
                          <Select.components.DropdownIndicator {...props} />
                          <Select.components.ClearIndicator {...props} />
                        </Select.components.DropdownIndicator>
                      ),
                    }}
                  /> */}

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>FirstName</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="FirstName" name="FirstName" value={InternalUserDetails.UD_FirstName ? InternalUserDetails.UD_FirstName : ''} onChange={handleChangeFirstName}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>LastName</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="LastName" name="LastName" value={InternalUserDetails.UD_LastName ? InternalUserDetails.UD_LastName : ''} onChange={handleChangeLastName}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>EmailAddress</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="EmailAddress" name="EmailAddress" value={InternalUserDetails.UD_EmailAddress ? InternalUserDetails.UD_EmailAddress : ''} onChange={handleChangeEmailAddress}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>MobileNumber</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="MobileNumber" name="MobileNumber" value={InternalUserDetails.UD_MobileNumber ? InternalUserDetails.UD_MobileNumber : ''} onChange={handleChangeMobileNumber}
            // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>PhoneNumber</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="PhoneNumber" name="PhoneNumber" value={InternalUserDetails.UD_PhoneNumber ? InternalUserDetails.UD_PhoneNumber : ''} onChange={handleChangePhoneNumber}
            // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
            />

          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Remarks</h6>
              </CInputGroupText>
            </CCol>  <CFormInput placeholder="Remarks" name="Remarks" value={InternalUserDetails.UD_Remarks ? InternalUserDetails.UD_Remarks : ''} onChange={handleChangeRemarks}
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
      </CTabPanel>
    </>
  )
}
export default InternalUserPopup_Details
