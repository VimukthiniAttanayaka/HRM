import React, { useState, useEffect } from 'react'
import { CTooltip, CButton, CFormSelect, CRow, CModal, CModalBody, CCol, CInputGroupText, CModalTitle, CModalFooter, CModalHeader, CFormCheck, CPopover, CLink, CCard, CCardBody, CForm, CFormInput, CInputGroup } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getLabelText } from 'src/MultipleLanguageSheets'

const CompanyPopup = ({ visible, onClose, onOpen, CompanyDetails, popupStatus }) => {
  const apiUrl = process.env.REACT_APP_API_URL;
  let templatetype = 'translation_company'

  const [customerId, setCustomerId] = useState('')
  const [companyName, setCompanyName] = useState('')
  const [groupName, setGroupName] = useState('')
  const [blockBuildingNumber, setBlockBuildingNumber] = useState('')
  const [addressBuildingName, setAddressBuildingName] = useState('')
  const [addressUnitNumber, setAddressUnitNumber] = useState('')
  const [addressStreetName, setAddressStreetName] = useState('')
  const [addressCity, setAddressCity] = useState('')
  const [addressCountryCode, setAddressCountryCode] = useState('')
  const [addressPostalCode, setAddressPostalCode] = useState('')
  const [contactPerson, setContactPerson] = useState('')
  const [contactNumber, setContactNumber] = useState('')
  const [pinOrPassword, setPinOrPassword] = useState('pin')
  const [isOtpSms, setIsOtpSms] = useState(true)
  const [isOtpEmail, setIsOtpEmail] = useState(true)
  const [isActive, setIsActive] = useState(true)

  const handleChangeId = (event) => {
    setCustomerId(event.target.value)
  }
  const handleChangeName = (event) => {
    setCompanyName(event.target.value)
  }
  const handleChangeGroupName = (event) => {
    setGroupName(event.target.value)
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
  const handleChangePinOrPassword = (event) => {
    setPinOrPassword(event.target.value)
  }
  const handleChangeIsOtpSms = (event) => {
    setIsOtpSms(event.target.checked)
  }
  const handleChangeIsOtpEmail = (event) => {
    setIsOtpEmail(event.target.checked)
  }
  const handleChangeStatus = (event) => {
    setIsActive(event.target.checked)
  }

  const handleCreate = async (event) => {

    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      CUS_ID: customerId,
      CUS_CompanyName: companyName,
      CUS_GroupCompany: groupName,
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
      CUS_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Customer/add_new_customer', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Company data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Company data:', response.statusText)
    }
  }
  const handleEdit = async (event) => {
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      CUS_ID: customerId,
      CUS_CompanyName: companyName,
      CUS_GroupCompany: groupName,
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
      CUS_Status: isActive
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Customer/modify_customer', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Company data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Company data:', response.statusText)
    }
  }
  const handleDelete = async (event) => {
    console.log('Delete Company')
    // Prepare form data
    const formData = {
      UD_UserID: "string",
      AUD_notificationToken: "string",
      CUS_ID: customerId
    }
    // Submit the form data to your backend API
    const response = await fetch(apiUrl + 'Customer/inactivate_customer', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(formData),
    })

    if (response.ok) {
      onClose()
      console.log(response);
      // Handle successful submission (e.g., display a success message)
      console.log('Company data submitted successfully!')
    } else {
      // Handle submission errors
      console.error('Error submitting Company data:', response.statusText)
    }
  }

  const handleSubmit = async (event) => {
    event.preventDefault()

    if (popupStatus == 'create') {
      handleCreate(event)
    } else if (popupStatus == 'edit') {
      handleEdit(event)
    } else if (popupStatus == 'delete') {
      handleDelete(event)
    }
    // Validation (optional)
    // You can add validation logic here to check if all required fields are filled correctly

  }

  const popupStatusSetup = (event) => {

    if (popupStatus == 'edit') {
      return getLabelText('Edit Company', templatetype)
    } else if (popupStatus == 'view') {
      return getLabelText('View Company', templatetype)
    } else if (popupStatus == 'delete') {
      return getLabelText('Delete Company', templatetype)
    } else {
      return getLabelText('Create New Company', templatetype)
    }
  }

  useEffect(() => {
    if (popupStatus == 'create') {
      setCustomerId('')
    setCompanyName('')
    setGroupName('')
    setBlockBuildingNumber('')
    setAddressBuildingName('')
    setAddressUnitNumber('')
    setAddressStreetName('')
    setAddressCity('')
    setAddressCountryCode('')
    setAddressPostalCode('')
    setContactPerson('')
    setContactNumber('')
      setPinOrPassword('pin')
    setIsOtpSms(true)
    setIsOtpEmail(true)
    setIsActive(true)
    }
    else{
    setCustomerId(CompanyDetails.CUS_ID)
    setCompanyName(CompanyDetails.CUS_CompanyName)
    setGroupName(CompanyDetails.CUS_GroupCompany)
    setBlockBuildingNumber(CompanyDetails.CUS_Adrs_BlockBuildingNo)
    setAddressBuildingName(CompanyDetails.CUS_Adrs_BuildingName)
    setAddressUnitNumber(CompanyDetails.CUS_Adrs_UnitNumber)
    setAddressStreetName(CompanyDetails.CUS_Adrs_StreetName)
    setAddressCity(CompanyDetails.CUS_Adrs_City)
    setAddressCountryCode(CompanyDetails.CUS_Adrs_CountryCode)
    setAddressPostalCode(CompanyDetails.CUS_Adrs_PostalCode)
    setContactPerson(CompanyDetails.CUS_ContactPerson)
    setContactNumber(CompanyDetails.CUS_ContactNumber)
    setPinOrPassword(CompanyDetails.CUS_PinOrPwd)
    setIsOtpSms(CompanyDetails.CUS_OTP_By_SMS)
    setIsOtpEmail(CompanyDetails.CUS_OTP_By_Email)
    setIsActive(CompanyDetails.CUS_Status)
    }
  }, [CompanyDetails]);
  // console.log(CompanyDetails)
  return (
    <>
      <CButton color="primary" onClick={onOpen}>  {getLabelText('New Company', templatetype)}
        {/* New Company */}
      </CButton>
      <CModal size='lg'
        scrollable
        alignment="center"
        visible={visible}
        onClose={onClose}
        aria-labelledby="TooltipsAndPopoverExample"
        backdrop="static"
      >
        <CModalHeader>
          <CModalTitle id="TooltipsAndPopoverExample">{popupStatusSetup()}
            {/* {popupStatusSetup()} */}
          </CModalTitle>
        </CModalHeader>
        <CModalBody>
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
                      <h6>Group Company</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormInput maxLength={20} placeholder="Group Company" name="groupName" value={groupName} onChange={handleChangeGroupName} />
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
                  <CFormSelect value={pinOrPassword} onChange={handleChangePinOrPassword}>
                    <option value="pin">Pin</option>
                    <option value="pwd">Password</option>
                  </CFormSelect>
                </CInputGroup>
                <CRow>
                  <CCol md={4}>
                    <CInputGroup className="mb-4">
                      <CFormCheck label="OTP by sms" checked={isOtpSms} onChange={handleChangeIsOtpSms} />
                    </CInputGroup>
                  </CCol>
                  <CCol md={4}>
                    <CInputGroup className="mb-4">
                      <CFormCheck label="OTP by email" checked={isOtpEmail} onChange={handleChangeIsOtpEmail}/>
                    </CInputGroup>
                  </CCol>
                  <CCol md={4}>
                    <CInputGroup className="mb-4">
                      <CFormCheck checked={isActive} onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                    </CInputGroup>
                  </CCol>
                </CRow>
                <div className="d-grid">
                  {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>{getLabelText('Delete', templatetype)}</CButton> :
                    <CButton color="success" type='submit'>{getLabelText('Submit', templatetype)}</CButton>)}
                </div>
              </CForm>
              {/* <CForm onSubmit={handleSubmit}>
                <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('CompanyID', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>   <CFormInput placeholder="CompanyID" name="CompanyID" value={CompanyDetails.MDD_CompanyID} onChange={handleChangeId} disabled={popupStatus == 'create' ? false : true}
                  // value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup> */}
              {/* <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Company', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>    <CFormInput placeholder="Company" name="Company" value={companyName} onChange={handleChangeCompanyName} disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false}

                  // readOnly={isEditable,isAddNew,IsView}// value={addressBuildingName} onChange={handleChangeAddressBuildingName}
                  />
                </CInputGroup> */}
              {/* <CInputGroup className="mb-3">
                  <CCol md={4}>
                    <CInputGroupText>
                      <h6>{getLabelText('Status', templatetype)}</h6>
                    </CInputGroupText>
                  </CCol>
                  <CFormCheck checked={isActive} onChange={handleChangeStatus} label="Status" disabled={(popupStatus == 'view' || popupStatus == 'delete') ? true : false} />
                </CInputGroup>
                <div className="d-grid">
                  {popupStatus == 'view' ? '' : (popupStatus == 'delete' ? <CButton color="danger" type='submit'>{getLabelText('Delete', templatetype)}</CButton> :
                    <CButton color="success" type='submit'>{getLabelText('Submit', templatetype)}</CButton>)}
                </div>
              </CForm> */}
            </CCardBody>
          </CCard>
        </CModalBody>
      </CModal>
    </>
  )
}
export default CompanyPopup
