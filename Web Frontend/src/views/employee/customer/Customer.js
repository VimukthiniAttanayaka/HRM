import React, { useState } from 'react'
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

const Customer = () => {
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
      customerId,
      companyName,
      blockBuildingNumber,
      addressBuildingName,
      addressUnitNumber,
      addressStreetName,
      addressCity,
      addressCountryCode,
      addressPostalCode,
      contactPerson,
      contactNumber,
      pinOrPassword,
      isOtpSms,
      isOtpEmail,
      isActive,
    }
    // Submit the form data to your backend API
    const response = await fetch('/api/customers', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      // Handle successful submission (e.g., display a success message)
      console.log('Customer data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting customer data:', response.statusText)
    }
  }
  return (
    <div className="bg-body-tertiary min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={9} lg={7} xl={6}>
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <CForm onSubmit={handleSubmit}>
                  <h1>Edit</h1>
                  <p className="text-body-secondary">Edit Your Company Details</p>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Customer Id" name="customerId" value={customerId} onChange={handleChangeId} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Company Name" name="companyName" value={companyName} onChange={handleChangeName} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Block Building Number" name="blockBuildingNumber" value={blockBuildingNumber} onChange={handleChangeBlockBuildingNumber} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Building Name" name="addressBuildingName" value={addressBuildingName} onChange={handleChangeAddressBuildingName} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Unit Number" name="addressUnitNumber" value={addressUnitNumber} onChange={handleChangeAddressUnitNumber} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Street Name" name="addressStreetName" value={addressStreetName} onChange={handleChangeAddressStreetName} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address City" name="addressCity" value={addressCity} onChange={handleChangeAddressCity} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Country Code" name="addressCountryCode" value={addressCountryCode} onChange={handleChangeAddressCountryCode} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Address Postal Code" name="addressPostalCode" value={addressPostalCode} onChange={handleChangeAddressPostalCode} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Contact Person" name="contactPerson" value={contactPerson} onChange={handleChangeContactPerson} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    {/* <CInputGroupText>
                      <CIcon icon={cilUser} />
                    </CInputGroupText> */}
                    <CFormInput placeholder="Contact Number" name="contactNumber" value={contactNumber} onChange={handleChangeContactNumber} />
                  </CInputGroup>
                  <CInputGroup className="mb-3">
                    <CFormSelect>
                      <option>Pin or Password</option>
                      <option value="PIN">Pin</option>
                      <option value="PWD">Password</option>
                    </CFormSelect>
                  </CInputGroup>
                  <CInputGroup className="mb-4">
                    <CFormCheck label="OTP by sms" defaultChecked />
                  </CInputGroup>
                  <CInputGroup className="mb-4">
                    <CFormCheck label="OTP by email" defaultChecked />
                  </CInputGroup>
                  <CInputGroup className="mb-4">
                    <CFormCheck label="Status" defaultChecked />
                  </CInputGroup>
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
