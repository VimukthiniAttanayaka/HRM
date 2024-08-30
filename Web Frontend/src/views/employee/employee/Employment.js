import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import axios from 'axios';
import General from './General.js';
import Profile from './Profile.js';
import Contact from './Contact.js';

const Employment = ({ EmployeeDetails, popupStatus }) => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const [employeeId, setEmployeeId] = useState()
  const [jobTitle, setJobTitle] = useState('manager')
  const [department, setDepartment] = useState('management')
  const [reportingManager, setReportingManager] = useState('PIN1')
  const [dateOfHired, setDateOfHired] = useState('2024-01-01')
  const [employmentType, setEmploymentType] = useState('fullTime')
  const [salary, setSalary] = useState(0)
  const [additionalInformation, setAdditionalInformation] = useState('')
  const [tin, setTin] = useState('')
  const [isActive, setIsActive] = useState(true)

  const handleChangeJobTitle = (event) => {
    setJobTitle(event.target.value)
  }
  const handleChangeDepartment = (event) => {
    setDepartment(event.target.value)
  }
  const handleChangeReportingManager = (event) => {
    setReportingManager(event.target.value)
  }
  const handleChangeDateOfHired = (event) => {
    setDateOfHired(event.target.value)
  }
  const handleChangeEmploymentType = (event) => {
    setEmploymentType(event.target.value)
  }
  const handleChangeSalary = (event) => {
    setSalary(event.target.value)
  }
  const handleChangeAdditionalInformation = (event) => {
    setAdditionalInformation(event.target.value)
  }
  const handleChangeTin = (event) => {
    setTin(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }

  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_CustomerID: "string",
      EME_PrefferedName: prefferedName,
      EME_JobTitle_Code: jobTitle,
      EME_ReportingManager: reportingManager,
      EME_EmployeeType: employmentType,
      EME_PayeeTaxNumber: tin,
      EME_Salary: 569,
      EME_DateOfHire: dateOfHired,
      EME_Status: isActive,
      EME_DateOfBirth: dob,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/add_new_employee', {
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
      EME_CustomerID: "string",
      EME_PrefferedName: prefferedName,
      EME_JobTitle_Code: jobTitle,
      EME_ReportingManager: reportingManager,
      EME_EmployeeType: employmentType,
      EME_PayeeTaxNumber: tin,
      EME_Salary: 568,
      EME_DateOfHire: dateOfHired,
      EME_Status: isActive,
      EME_DateOfBirth: dob,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/modify_employee', {
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
      EME_EmployeeID: employeeId,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Employee/inactivate_employee', {
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

  function ImageDisplay({ documentData }) {
    const { USRED_DocumentData, USRED_DocumentType } = documentData;

    const createImageSrc = (base64String, imageType) => {
      return `data:image/${imageType};base64,${base64String}`;
    };

    const imageSrc = createImageSrc(USRED_DocumentData, USRED_DocumentType);

    return (
      <img src={imageSrc} alt="Document" />
    );
  }

  const handleSubmitData = async (event) => {
    event.preventDefault()

    if (popupStatus == 'create') {
      handleCreate(event)
    } else if (popupStatus == 'edit') {
      handleEdit(event)
    } else if (popupStatus == 'delete') {
      handleDelete(event)
    }

  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setEmployeeId('')
      setJobTitle('manager')
      setDepartment('management')
      setReportingManager('PIN1')
      setEmploymentType('fullTime')
      setSalary(0)
      setAdditionalInformation('')
      setTin('')
      setIsActive(true)
    }
    else {
      const createdDOH = EmployeeDetails.EME_DateOfHired;
      if (createdDOH !== undefined) {
        const dateOnly = createdDOH.slice(0, 10);
        setDob(dateOnly)
      }
      setEmployeeId(EmployeeDetails.EME_EmployeeID)
      setJobTitle(EmployeeDetails.EME_JobTitle_Code)
      setDepartment(EmployeeDetails.EME_DepartmentID)
      setReportingManager(EmployeeDetails.EME_ReportingManager)
      setEmploymentType(EmployeeDetails.EME_EmployeeType)
      setSalary(EmployeeDetails.EME_Salary)
      setAdditionalInformation(EmployeeDetails.EME_AdditionalInformation)
      setTin(EmployeeDetails.EME_PayeeTaxNumber)
      setIsActive(EmployeeDetails.EME_Status)
    }
  }, [EmployeeDetails]);

  return (
    <>
      <CTabPanel className="p-3" itemKey="employment">
        <CForm onSubmit={handleSubmitData}>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Job title</h6>
              </CInputGroupText>
            </CCol>
            <CFormSelect value={jobTitle} onChange={handleChangeJobTitle}>
              <option value="manager">Manager</option>
              <option value="directer">Directer</option>
              <option value="developer">Developer</option>
              <option value="techLead">Tech lead</option>
              {/* <option value="PIN">B+</option>
                    <option value="PWD">B-</option>
                    <option value="PIN">AB+</option>
                    <option value="PWD">AB-</option> */}
            </CFormSelect>
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Department</h6>
              </CInputGroupText>
            </CCol>
            <CFormSelect value={department} onChange={handleChangeDepartment}>
              <option value="management">Management</option>
              <option value="hr">HR</option>
              <option value="accounting">Accounting</option>
              <option value="developer">Developer</option>
              {/* <option value="PIN">B+</option>
                    <option value="PWD">B-</option>
                    <option value="PIN">AB+</option>
                    <option value="PWD">AB-</option> */}
            </CFormSelect>
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Reporting manager</h6>
              </CInputGroupText>
            </CCol>
            <CFormSelect value={reportingManager} onChange={handleChangeReportingManager}>
              <option value="PIN1">O+</option>
              <option value="PWD2">O-</option>
              <option value="PIN3">A+</option>
              <option value="PWD4">A-</option>
              <option value="PIN5">B+</option>
              <option value="PWD6">B-</option>
              <option value="PIN7">AB+</option>
              <option value="PWD8">AB-</option>
            </CFormSelect>
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Date of hire</h6>
              </CInputGroupText>
            </CCol>
            <input
              type="date"
              id="dob"
              name="dateOfHired"
              value={dateOfHired}
              onChange={handleChangeDateOfHired}
            />
            {/* <CDatePicker placeholder="Date of hired" name="dateOfHired"
                  value={dateOfHired} onChange={handleChangeDateOfHired}
                  /> */}
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Employment type</h6>
              </CInputGroupText>
            </CCol>
            <CFormSelect value={employmentType} onChange={handleChangeEmploymentType}>
              <option value="fullTime">full-time</option>
              <option value="partTime">part-time</option>
              <option value="contract">contract</option>
            </CFormSelect>
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Salary</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="Salary" name="salary" type='number'
              value={salary} onChange={handleChangeSalary}
            />
          </CInputGroup>
          {/* <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>Benefits eligibility</h6>
                    </CInputGroupText>
                  </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
                  // value={customerId} onChange={handleChangeId}
                  />
                </CInputGroup> */}
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Additional Information</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="JobTitle_Code" name="JobTitle_Code"
              value={additionalInformation} onChange={handleChangeAdditionalInformation}
            />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Tax identification number(TIN)</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="TIN" name="tin"
              value={tin} onChange={handleChangeTin}
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
            {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>Delete</CButton> :
              <CButton color="success" type='submit'>Submit</CButton>)}
          </div>
        </CForm>
      </CTabPanel>
    </>
  )
}
export default Employment
