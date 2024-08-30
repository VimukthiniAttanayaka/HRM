import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import axios from 'axios';

const EmployeePopupTab_Profile = ({ EmployeeDetails, popupStatus }) => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const [img, setImg] = useState('')

  const handleGetAllDocument = async (event) => {
    console.log('Delete Department')
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_EmployeeID: "employeeId"
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/get_employeeDocument_all', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
        console.log(res1)
        setImg(res1)
      })
  }

  const [selectedFileProfileImage, setSelectedFileProfileImage] = useState();
  const [selectedFileCV, setSelectedFileCV] = useState(null);
  const [selectedFileNIC, setSelectedFileNIC] = useState();
  const [selectedFilePassport, setSelectedFilePassport] = useState();
  const [selectedFileDrivingLicense, setSelectedFileDrivingLicense] = useState();

  function handleChangeProfileImage(e) {
    // console.log(e.target.files);
    setSelectedFileProfileImage(e.target.files[0]);
  }

  const handleFileChangeCV = (event) => {
    setSelectedFileCV(event.target.files[0]);
  };

  function handleChangeNIC(e) {
    // console.log(e.target.files);
    setSelectedFileNIC(e.target.files[0]);
  }

  function handleChangePassport(e) {
    // console.log(e.target.files);
    setSelectedFilePassport(e.target.files[0]);
  }

  function handleChangeDrivingLicense(e) {
    // console.log(e.target.files);
    setSelectedFileDrivingLicense(e.target.files[0]);
  }

  const handleSubmit = async (event) => {
    event.preventDefault();

    const data = {
      EME_EmployeeID: 'employeeId',
    }
    const formData = new FormData();
    formData.append('cv', selectedFileCV);
    formData.append('nic', selectedFileNIC);
    formData.append('profileImage', selectedFileProfileImage);
    formData.append('passport', selectedFilePassport);
    formData.append('drivingLicense', selectedFileDrivingLicense);

    try {
      const response = await axios.post(apiUrl + 'Employee/PostImage',
        formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      })
      const response1 = await axios.post(apiUrl + 'Employee/uploadAttachment',
        data, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      console.log(response.data);
    } catch (error) {
      console.error(error);
    }

  };

  return (
    <>
      <CTabPanel className="p-3" itemKey="profile">
        <CForm onSubmit={handleSubmit}>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Profile Image</h6>
              </CInputGroupText>
            </CCol>
            <input type="file" onChange={handleChangeProfileImage} />
            {selectedFileProfileImage && (
              <img src={URL.createObjectURL(selectedFileProfileImage)} alt="Preview" width={100} />
            )}
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>CV</h6>
              </CInputGroupText>
            </CCol>
            <input type="file" onChange={handleFileChangeCV} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>NIC</h6>
              </CInputGroupText>
            </CCol>
            <input type="file" onChange={handleChangeNIC} />
            {selectedFileNIC && (
              <img src={URL.createObjectURL(selectedFileNIC)} alt="Preview" width={100} />
            )}
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Passport</h6>
              </CInputGroupText>
            </CCol>
            <input type="file" onChange={handleChangePassport} />
            {selectedFilePassport && (
              <img src={URL.createObjectURL(selectedFilePassport)} alt="Preview" width={100} />
            )}
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Driving License</h6>
              </CInputGroupText>
            </CCol>
            <input type="file" onChange={handleChangeDrivingLicense} />
            {selectedFileDrivingLicense && (
              <img src={URL.createObjectURL(selectedFileDrivingLicense)} alt="Preview" width={100} />
            )}
          </CInputGroup>
          <div className="d-grid">
            <CButton color="success" type='submit'>Submit</CButton>
          </div>
        </CForm>
      </CTabPanel>
    </>
  )
}
export default EmployeePopupTab_Profile
