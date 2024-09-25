import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import axios from 'axios';
import { modifyEmployee } from '../../../apicalls/employee/modify.js';
import { deleteEmployee } from '../../../apicalls/employee/delete.js';
import { addNewEmployee } from '../../../apicalls/employee/add_new.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const EmployeePopupTab_General = ({ EmployeeDetails, popupStatus }) => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const [employeeId, setEmployeeId] = useState()
  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [dob, setDob] = useState(new Date())
  const [maritalStatus, setMaritalStatus] = useState('')
  const [gender, setGender] = useState('')
  const [nationality, setNationality] = useState('srilankan')
  const [bloodGroup, setBloodGroup] = useState('o+')
  const [prefferedName, setPrefferedName] = useState('')
  const [nic, setNic] = useState('')
  const [passport, setPassport] = useState('')
  const [drivingLicense, setDrivingLicense] = useState('')

  const handleChangeEmployeeId = (event) => {
    setEmployeeId(event.target.value)
  }
  const handleChangeFirstName = (event) => {
    setFirstName(event.target.value)
  }
  const handleChangeLastName = (event) => {
    setLastName(event.target.value)
  }
  const handleChangeDob = (event) => {
    setDob(event.target.value);
  }
  const handleChangeMaritalStatus = (event) => {
    setMaritalStatus(event.target.value)
  }
  const handleChangeGender = (event) => {
    setGender(event.target.value)
  }
  const handleChangeNationality = (event) => {
    setNationality(event.target.value)
  }
  const handleChangeBloodGroup = (event) => {
    setBloodGroup(event.target.value)
  }
  const handleChangePrefferedName = (event) => {
    setPrefferedName(event.target.value)
  }
  const handleChangeNicNumber = (event) => {
    setNic(event.target.value)
  }
  const handleChangePassportNumber = (event) => {
    setPassport(event.target.value)
  }
  const handleChangeDrivingLicenseNumber = (event) => {
    setDrivingLicense(event.target.value)
  }

  const handleSubmitData = async (event) => {
    event.preventDefault()

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      EME_CustomerID: "string",
      EME_DepartmentID: department,
      EME_EmployeeID: employeeId,
      EME_FirstName: firstName,
      EME_LastName: lastName,
      EME_Gender: gender,
      EME_MaritalStatus: maritalStatus,
      EME_Nationality: nationality,
      EME_BloodGroup: bloodGroup,
      EME_NIC: nic,
      EME_Passport: passport,
      EME_DrivingLicense: drivingLicense,
    }

 if (popupStatus == 'edit') {
      const APIReturn = await modifyEmployee(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else if (popupStatus == 'delete') {
      const APIReturn = await deleteEmployee(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
    else {
      const APIReturn = await addNewEmployee(formData)
      if (APIReturn.resp === false) { setDialogTitle("Alert"); }
      else { setDialogTitle("Message"); }
      console.log(APIReturn.msg)
      setDialogContent(APIReturn.msg);
      setOpen(true);
    }
  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setEmployeeId('')
      setFirstName('')
      setLastName('')
      setMaritalStatus('')
      setGender('')
      setNationality('srilankan')
      setBloodGroup('o+')
      setPrefferedName('')
      setNic('')
      setPassport('')
      setDrivingLicense('')
    }
    else {
      const createdDOB = EmployeeDetails.EME_DateOfBirth;
      if (createdDOB !== undefined) {
        const dateOnly = createdDOB.slice(0, 10);
        setDob(dateOnly)
      }
      setEmployeeId(EmployeeDetails.EME_EmployeeID)
      setFirstName(EmployeeDetails.EME_FirstName)
      setLastName(EmployeeDetails.EME_LastName)
      setMaritalStatus(EmployeeDetails.EME_MaritalStatus)
      setGender(EmployeeDetails.EME_Gender)
      setNationality(EmployeeDetails.EME_Nationality)
      setBloodGroup(EmployeeDetails.EME_BloodGroup)
      setPrefferedName(EmployeeDetails.EME_PrefferedName)
      setNic(EmployeeDetails.EME_NIC)
      setPassport(EmployeeDetails.EME_Passport)
      setDrivingLicense(EmployeeDetails.EME_DrivingLicense)
    }
  }, [EmployeeDetails]);

  return (
    <>
      <CTabPanel className="p-3" itemKey="general">
        <CForm onSubmit={handleSubmitData}>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Employee Id</h6>
              </CInputGroupText>
            </CCol>   <CFormInput placeholder="Employee ID" name="Employee ID" value={employeeId} onChange={handleChangeEmployeeId}
              disabled={popupStatus == 'create' ? false : true}
            />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>FirstName</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="FirstName" name="FirstName"
              value={firstName} onChange={handleChangeFirstName}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>LastName</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="LastName" name="LastName"
              value={lastName} onChange={handleChangeLastName}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Date of birth</h6>
              </CInputGroupText>
            </CCol>
            <input
              type="date"
              id="dob"
              name="dob"
              value={dob}
              onChange={handleChangeDob}
            />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Gender</h6>
              </CInputGroupText>
            </CCol>
            <CFormCheck inline type="radio" name="gender" id="inlineCheckbox1" value="male" label="Male" checked={gender === 'male'}
              onChange={handleChangeGender} className='ms-4' />
            <CFormCheck inline type="radio" name="gender" id="inlineCheckbox2" value="female" label="Female" checked={gender === 'female'}
              onChange={handleChangeGender} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Marital status</h6>
              </CInputGroupText>
            </CCol>
            <CFormCheck inline type="radio" name="maritalStatus" id="inlineCheckbox1" value="singal" label="Single" checked={maritalStatus === 'single'}
              onChange={handleChangeMaritalStatus} className='ms-4' />
            <CFormCheck inline type="radio" name="maritalStatus" id="inlineCheckbox2" value="married" label="Married" checked={maritalStatus === 'married'}
              onChange={handleChangeMaritalStatus} />
            <CFormCheck inline type="radio" name="maritalStatus" id="inlineCheckbox2" value="widowed" label="Widowed" checked={maritalStatus === 'widowed'}
              onChange={handleChangeMaritalStatus} />
            <CFormCheck inline type="radio" name="maritalStatus" id="inlineCheckbox2" value="divorced" label="Divorced" checked={maritalStatus === 'divorced'}
              onChange={handleChangeMaritalStatus} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Nationality/Country</h6>
              </CInputGroupText>
            </CCol>
            <CFormSelect value={nationality} onChange={handleChangeNationality}>
              <option value="srilankan">Srilankan</option>
              <option value="indian">Indian</option>
            </CFormSelect>
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Blood group</h6>
              </CInputGroupText>
            </CCol>
            <CFormSelect value={bloodGroup} onChange={handleChangeBloodGroup}>
              <option value="o+">O+</option>
              <option value="o-">O-</option>
              <option value="a+">A+</option>
              <option value="a-">A-</option>
              <option value="b+">B+</option>
              <option value="b-">B-</option>
              <option value="ab+">AB+</option>
              <option value="ab-">AB-</option>
            </CFormSelect>
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>PrefferedName</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="PrefferedName" name="prefferedName"
              value={prefferedName} onChange={handleChangePrefferedName}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>NIC</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="NIC" name="nic"
              value={nic} onChange={handleChangeNicNumber}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Passport</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="Passport Number" name="passportNumber"
              value={passport} onChange={handleChangePassportNumber}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>
          <CInputGroup className="mb-3">
            <CCol md={4}>
              <CInputGroupText>
                <h6>Driving License</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="Driving License" name="drivingLicense"
              value={drivingLicense} onChange={handleChangeDrivingLicenseNumber}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
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
export default EmployeePopupTab_General
