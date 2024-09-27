import React, { useState, useEffect } from 'react'
import { CTooltip, CRow, CButton, CModal, CTabs, CFormSelect, CCardHeader, CTabList, CTab, CCol, CInputGroupText, CTabContent, CTabPanel, CModalBody, CModalTitle, CModalFooter, CFormCheck, CModalHeader, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup, CDatePicker } from '@coreui/react-pro'
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
  const [Address, setAddress] = useState('')
  const [EmailAddress, setEmailAddress] = useState('')
  const [MobileNumber, setMobileNumber] = useState('')
  const [PhoneNumber1, setPhoneNumber1] = useState('')
  const [PhoneNumber2, setPhoneNumber2] = useState('')
  const [tin, setTin] = useState('')
  const [isActive, setIsActive] = useState(true)

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
  const handleChangeAddress = (event) => {
    setAddress(event.target.value)
  }
  const handleChangeEmailAddress = (event) => {
    setEmailAddress(event.target.value)
  }
  const handleChangeMobileNumber = (event) => {
    setMobileNumber(event.target.value)
  }
  const handleChangePhoneNumber1 = (event) => {
    setPhoneNumber1(event.target.value)
  }
  const handleChangePhoneNumber2 = (event) => {
    setPhoneNumber2(event.target.value)
  }
  const handleChangeTin = (event) => {
    setTin(event.target.value)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
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
      EME_Address: Address,
      EME_EmailAddress: EmailAddress,
      EME_MobileNumber: MobileNumber,
      EME_PhoneNumber1: PhoneNumber1,
      EME_PhoneNumber2: PhoneNumber2,
      EME_PayeeTaxNumber: tin,
      EME_Status: isActive,

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
      setAddress('')
      setEmailAddress('')
      setMobileNumber('')
      setPhoneNumber1('')
      setPhoneNumber2('')
      setTin('')
      setIsActive(true)
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
      setAddress(EmployeeDetails.EME_Address)
      setEmailAddress(EmployeeDetails.EME_EmailAddress)
      setMobileNumber(EmployeeDetails.EME_MobileNumber)
      setPhoneNumber1(EmployeeDetails.EME_PhoneNumber1)
      setPhoneNumber2(EmployeeDetails.EME_PhoneNumber2)
      setTin(EmployeeDetails.EME_PayeeTaxNumber)
      setIsActive(EmployeeDetails.EME_Status)
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
                <h6>PrefferedName</h6>
              </CInputGroupText>
            </CCol> <CFormInput placeholder="PrefferedName" name="prefferedName"
              value={prefferedName} onChange={handleChangePrefferedName}
              disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
          </CInputGroup>

          <CCard>
            <CCardHeader>
              Civil Status
            </CCardHeader>
            <CCardBody>

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
                <CCol md={2}>
                  <CInputGroupText>
                    <h6>Date of birth</h6>
                  </CInputGroupText>
                </CCol>
                <CCol md={5}><input
                  type="date"
                  id="dob"
                  name="dob"
                  value={dob}
                  onChange={handleChangeDob}
                /> </CCol>
                <CCol md={3}>
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
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>Tax identification number(TIN)</h6>
                  </CInputGroupText>
                </CCol> <CFormInput placeholder="TIN" name="tin"
                  value={tin} onChange={handleChangeTin}
                />
              </CInputGroup>   </CCardBody>
          </CCard>
          <CCard>
            <CCardHeader>
              General Address
            </CCardHeader>
            <CCardBody>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>Address</h6>
                  </CInputGroupText>
                </CCol> <CFormInput placeholder="Address" name="Address"
                  value={Address} onChange={handleChangeAddress}
                />
              </CInputGroup>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>EmailAddress</h6>
                  </CInputGroupText>
                </CCol> <CFormInput placeholder="EmailAddress" name="emailAddress"
                  value={EmailAddress} onChange={handleChangeEmailAddress}
                />
              </CInputGroup>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>MobileNumber</h6>
                  </CInputGroupText>
                </CCol> <CFormInput placeholder="MobileNumber" name="mobileNumber"
                  value={MobileNumber} onChange={handleChangeMobileNumber}
                />
              </CInputGroup>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>PhoneNumber1</h6>
                  </CInputGroupText>
                </CCol> <CFormInput placeholder="PhoneNumber1" name="phoneNumber1"
                  value={PhoneNumber1} onChange={handleChangePhoneNumber1}
                />
              </CInputGroup>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>PhoneNumber2</h6>
                  </CInputGroupText>
                </CCol> <CFormInput placeholder="PhoneNumber2" name="phoneNumber2"
                  value={PhoneNumber2} onChange={handleChangePhoneNumber2}
                />
              </CInputGroup>
            </CCardBody>
          </CCard>
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
      </CTabPanel >
    </>
  )
}
export default EmployeePopupTab_General
