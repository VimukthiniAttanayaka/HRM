import React, { useState, useEffect } from 'react'
import { CTooltip, CFormSelect, CButton, CModal, CModalBody, CBadge, CDropdown, CDropdownItem, CDropdownMenu, CDropdownToggle, CRow, CCol, CSmartTable, CTabPanel, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import data from './_data.js'
import { Modal } from '@coreui/coreui-pro';

const UserRolePopup_Details = ({ visible, onClose, onOpen, UserRoleDetails, checkMenuListItems }) => {

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
      UAG_AccessGroupID: AccessGroupId,
      UAG_AccessGroup: AccessGroup,
      UAG_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'AccessGroup/add_new_AccessGroup', {
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
  // const [checkMenuListItems, setcheckMenuListItems] = useState([]);

  const handleCheckboxChange = (event) => {
    const { checked, value } = event.target;
    if (checked) {
      setCheckedItems([...checkedItems, value]);
    } else {
      setCheckedItems(checkedItems.filter(item => item !== value));
    }
  };

  const options = [
    { value: 'option1', label: 'Option 1', checked: true },
    { value: 'option2', label: 'Option 2', checked: true },
    { value: 'option3', label: 'Option 3', checked: true },
  ];

  useEffect(() => {
  }, []);


  return (
    <>
      <CTabPanel className="p-3" itemKey="general">
        {/* <CButton color="primary" onClick={onOpen}>New Access Group</CButton> */}

        <CForm onSubmit={handleSubmit}>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>EUR_UserRoleID</h6>
              </CInputGroupText>
            </CCol>   <CFormInput placeholder="UserRoleID" name="UserRoleID" value={UserRoleDetails.EUR_UserRoleID} onChange={handleChangeId}
            // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
            />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>EUR_UserRole</h6>
              </CInputGroupText>
            </CCol>    <CFormInput placeholder="UserRole" name="UserRole" value={UserRoleDetails.EUR_UserRole} onChange={handleChangeUserRole}
            // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
            />
          </CInputGroup>
          {/* <CInputGroup className="mb-3"> */}
          {/* <CCol md={4}>
            <CInputGroupText>
              <h6>Available Menus</h6>
            </CInputGroupText>
          </CCol> */}

          {/* {checkMenuListItems.map((option) => (
                    <CFormCheck
                      key={option.value}
                      type="checkbox"
                      label={option.label}
                      value={option.value}
                      // checked={checkedItems.includes(option.value)}
                      checked={option.Ischecked}
                      onChange={handleCheckboxChange}
                    />
                  ))} */}
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

      </CTabPanel>
    </>
  )
}
export default UserRolePopup_Details
