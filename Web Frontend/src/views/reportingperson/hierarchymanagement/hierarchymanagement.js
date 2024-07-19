import React, { useState, useEffect } from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
  CFormCheck,
  CFormSelect,
} from '@coreui/react-pro'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass';

const Customer = () => {

  const apiUrl = process.env.REACT_APP_API_URL;

  const [customerId, setCustomerId] = useState('')
  const [companyName, setCompanyName] = useState('')
  const [blockBuildingNumber, setBlockBuildingNumber] = useState('')
  const [addressBuildingName, setAddressBuildingName] = useState('')
  const [addressUnitNumber, setAddressUnitNumber] = useState('')
  const [addressStreetName, setAddressStreetName] = useState('')
  const [addressCity, setAddressCity] = useState('')
  const [addressCountryCode, setAddressCountryCode] = useState('')
  const [addressPostalCode, setAddressPostalCode] = useState('')
  const [contactPerson, setContactPerson] = useState('')
  const [contactNumber, setContactNumber] = useState('')
  const [pinOrPassword, setPinOrPassword] = useState('PIN')
  const [isOtpSms, setIsOtpSms] = useState(true)
  const [isOtpEmail, setIsOtpEmail] = useState(true)
  const [isActive, setIsActive] = useState(true)


  const handleChangeId = (event) => {
    setCustomerId(event.target.value)
  }
  const handleChangeName = (event) => {
    setCompanyName(event.target.value)
  }
  const handleChangeBlockBuildingNumber = (event) => {
    setBlockBuildingNumber(event.target.value)
  }
  const handleChangeAddressBuildingName = (event) => {
    setAddressBuildingName(event.target.value)
  }
  const handleChangeAddressUnitNumber = (event) => {
    setAddressUnitNumber(event.target.value)
  }
  const handleChangeAddressStreetName = (event) => {
    setAddressStreetName(event.target.value)
  }
  const handleChangeAddressCity = (event) => {
    setAddressCity(event.target.value)
  }
  const handleChangeAddressCountryCode = (event) => {
    setAddressCountryCode(event.target.value)
  }
  const handleChangeAddressPostalCode = (event) => {
    setAddressPostalCode(event.target.value)
  }
  const handleChangeContactPerson = (event) => {
    setContactPerson(event.target.value)
  }
  const handleChangeContactNumber = (event) => {
    setContactNumber(event.target.value)
  }
  const handleChangePinOrPassword = (event) => { }
  const handleChangeIsOtpSms = (event) => { }
  const handleChangeIsOtpEmail = (event) => { }
  const handleChangeIsActive = (event) => { }
  // const handleChange = (event) => {
  //   const { name, value, type, checked } = event.target
  //   switch (type) {
  //     case 'checkbox':
  //       if (name === 'isOtpSms') {
  //         setIsOtpSms(checked)
  //       } else if (name === 'isOtpEmail') {
  //         setIsOtpEmail(checked)
  //       } else if (name === 'isActive') {
  //         setIsActive(checked)
  //       }
  //       break
  //     case 'select-one':
  //       setPinOrPassword(value)
  //       break
  //     case 'customerId':
  //       setCustomerId(value);
  //       break
  //     case 'companyName':
  //       setCompanyName(value);
  //       break
  //     default:
  //       setContactPerson(value);
  //     // setCompanyName(value);
  //     // setBlockBuildingNumber(value);
  //     // setAddressBuildingName(value);
  //     // setAddressUnitNumber(value);
  //     // setAddressStreetName(value);
  //     // setAddressCity(value);
  //     // setAddressCountryCode(value);
  //     // setAddressPostalCode(value);
  //     // setContactPerson(value);
  //     // setContactNumber(value);
  //     // break;
  //   }
  // }

  const handleSubmit = async (event) => {
    event.preventDefault()

    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

    // Prepare form data
    const formData = {
      CUS_ID: customerId,
      CUS_CompanyName: companyName,
      CUS_Adrs_BlockBuildingNo: blockBuildingNumber,
      CUS_Adrs_BuildingName: addressBuildingName,
      CUS_Adrs_UnitNumber: addressUnitNumber,
      CUS_Adrs_StreetName: addressStreetName,
      CUS_Adrs_City: addressCity,
      CUS_Adrs_CountryCode: addressCountryCode,
      CUS_Adrs_PostalCode: addressPostalCode,
      CUS_ContactPerson: contactPerson,
      CUS_ContactNumber: contactNumber,
      CUS_PinOrPwd: pinOrPassword,
      CUS_OTP_By_SMS: isOtpSms,
      CUS_OTP_By_Email: isOtpEmail,
      CUS_Status: isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'customer/add_new_customer', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Company data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Company data:', response.statusText)
    }
  }

  const auth = localStorage.getItem('token');

  async function requestdata() {
    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();
    // const config = {
    //   headers: { Authorization: `Bearer ${auth}` }
    // };
    const formData = {
      UD_StaffID: staffId,
      AUD_notificationToken: token,
      CUS_ID: 'cus1'
    }
    const res = await fetch(apiUrl + 'customer/get_customers_single', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })
      .then(response => response.json())
      .then(json => {
        let res1 = JSON.parse(JSON.stringify(json))
        console.log(res1);
        // setCustomerId(res1[0].Customer[0].CUS_ID);
        // setCompanyName(res1[0].Customer[0].CUS_CompanyName);
        // setBlockBuildingNumber(res1[0].Customer[0].CUS_Adrs_BlockBuildingNo);
        // setAddressBuildingName(res1[0].Customer[0].CUS_Adrs_BuildingName);
        // setAddressUnitNumber(res1[0].Customer[0].CUS_Adrs_UnitNumber);
        // setAddressStreetName(res1[0].Customer[0].CUS_Adrs_StreetName);
        // setAddressCity(res1[0].Customer[0].CUS_Adrs_City);
        // setAddressCountryCode(res1[0].Customer[0].CUS_Adrs_CountryCode);
        // setAddressPostalCode(res1[0].Customer[0].CUS_Adrs_PostalCode);
        // setContactPerson(res1[0].Customer[0].CUS_ContactPerson);
        // setContactNumber(res1[0].Customer[0].CUS_ContactNumber);
        // setPinOrPassword(res1[0].Customer[0].CUS_PinOrPwd);
        // setIsOtpSms(res1[0].Customer[0].CUS_OTP_By_SMS);
        // setIsOtpEmail(res1[0].Customer[0].CUS_OTP_By_Email);
        // setIsActive(res1[0].Customer[0].CUS_Status);
      })
  }
  useEffect(() => {
    requestdata();
  }, [auth]);

  return (
    <div className="bg-body-tertiary min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={9}>
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <CForm onSubmit={handleSubmit}>
                  <h1>{customerId ? "Edit" : "Add"}</h1>
                  <p className="text-body-secondary">{customerId ? "Edit" : "Add"} Your Company Details</p>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Company Id</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Company Id" name="customerId" value={customerId} onChange={handleChangeId} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Company Name</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Company Name" name="companyName" value={companyName} onChange={handleChangeName} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Block Building Number</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Block Building Number" name="blockBuildingNumber" value={blockBuildingNumber} onChange={handleChangeBlockBuildingNumber} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Address Building Name</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Address Building Name" name="addressBuildingName" value={addressBuildingName} onChange={handleChangeAddressBuildingName} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Address Unit Number</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Address Unit Number" name="addressUnitNumber" value={addressUnitNumber} onChange={handleChangeAddressUnitNumber} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Address Street Name</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Address Street Name" name="addressStreetName" value={addressStreetName} onChange={handleChangeAddressStreetName} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Address City</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Address City" name="addressCity" value={addressCity} onChange={handleChangeAddressCity} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Address Country Code</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Address Country Code" name="addressCountryCode" value={addressCountryCode} onChange={handleChangeAddressCountryCode} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Address Postal Code</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Address Postal Code" name="addressPostalCode" value={addressPostalCode} onChange={handleChangeAddressPostalCode} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Contact Person</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={20} placeholder="Contact Person" name="contactPerson" value={contactPerson} onChange={handleChangeContactPerson} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Contact Number</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormInput maxLength={10} placeholder="Contact Number" name="contactNumber" value={contactNumber} onChange={handleChangeContactNumber} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CCol md={4}>
                      <CInputGroupText>
                        <h6>Pin or Password</h6>
                      </CInputGroupText>
                    </CCol>
                    <CFormSelect>
                      <option value="PIN">Pin</option>
                      <option value="PWD">Password</option>
                    </CFormSelect>
                  </CInputGroup>
                  <CRow>
                    <CCol md={4}>
                      <CInputGroup className="mb-4">
                        <CFormCheck label="OTP by sms" defaultChecked />
                      </CInputGroup>
                    </CCol>
                    <CCol md={4}>
                      <CInputGroup className="mb-4">
                        <CFormCheck label="OTP by email" defaultChecked />
                      </CInputGroup>
                    </CCol>
                    <CCol md={4}>
                      <CInputGroup className="mb-4">
                        <CFormCheck label="Status" defaultChecked />
                      </CInputGroup>
                    </CCol>
                  </CRow>
                  <div className="d-grid">
                    <CButton color="success" type='submit'>Submit</CButton>
                  </div>
                </CForm>
              </CCardBody>
            </CCard>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Customer
