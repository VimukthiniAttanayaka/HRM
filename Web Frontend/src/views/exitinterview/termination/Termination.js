import React, { useState, useEffect } from 'react'
import { CCard, CCardHeader, CCardBody, CRow, CCol, CInputGroupText, CFormInput, CInputGroup, CButton } from '@coreui/react-pro'
import { getJWTToken, getCustomerID, getStaffID } from '../../../staticClass.js';
import { getLabelText } from 'src/MultipleLanguageSheets'
import { getEmployeeSingle } from '../../../apicalls/employee/get_employee_single.js';

const Termination = () => {
  let templatetype = 'translation_Termination'
  let templatetype_base = 'translation'

  const [EmployeeID, setEmployeeID] = useState('')
  const [NIC, setNIC] = useState('')
  const [Passport, setPassport] = useState('')
  const [LastName, setLastName] = useState('')
  const [FirstName, setFirstName] = useState('')
  const handleChangeEmployeeID = (event) => { setEmployeeID(event.target.value) }

  async function loadDetails(item) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: EmployeeID
    }

    const EmployeeDetails = await getEmployeeSingle(formData)
    console.log(EmployeeDetails)
    setNIC(EmployeeDetails.EME_NIC)
    setPassport(EmployeeDetails.EME_Passport)
    setLastName(EmployeeDetails.EME_LastName)
    setFirstName(EmployeeDetails.EME_FirstName)
  }
  
  async function confirmTermination(item) {

    const token = getJWTToken();
    const staffId = getStaffID();
    const customerId = getCustomerID();

    const formData = {
      // UD_StaffID: staffId,
      // AUD_notificationToken: token,
      EME_EmployeeID: EmployeeID
    }
  }

  return (
    <>
      <CCard className="mb-4">
        <CCardHeader>
          {/* <strong>Termination List</strong> */}
          {getLabelText('Termination List', templatetype)}
        </CCardHeader>
        <CCardBody>
          <CRow><CCol>
            <CInputGroup className="mb-3">
              <CCol md={4}>
                <CInputGroupText>
                  <h6>Employee ID</h6>
                </CInputGroupText>
              </CCol>
              <CCol md={4}>
                <CFormInput maxLength={20} placeholder="Employee ID" name="EmployeeID" value={EmployeeID} onChange={handleChangeEmployeeID} />
              </CCol>
              <CCol md={4}>
                <CButton color="primary"
                  className="mb-2"
                  onClick={() => {
                    loadDetails(EmployeeID)
                  }}>Search</CButton>
              </CCol>   </CInputGroup>
          </CCol></CRow>
          <CRow><CCol>
            <CInputGroup className="mb-3">
              <CCol md={4}>
                <CInputGroupText>
                  <h6>NIC</h6>
                </CInputGroupText>
              </CCol>
              <CCol md={4}>
                <CFormInput readOnly maxLength={20} placeholder="NIC" name="NIC" value={NIC} />
              </CCol>
              <CCol md={4}>   </CCol>
            </CInputGroup>
          </CCol></CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>Passport</h6>
                  </CInputGroupText>
                </CCol>
                <CCol md={4}><CFormInput readOnly maxLength={20} placeholder="Passport" name="Passport" value={Passport} />
                </CCol>
                <CCol md={4}>   </CCol>
              </CInputGroup>
            </CCol></CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>FirstName</h6>
                  </CInputGroupText>
                </CCol>
                <CCol md={4}><CFormInput readOnly placeholder="FirstName" name="FirstName" value={FirstName} />
                </CCol>
                <CCol md={4}>   </CCol>
              </CInputGroup>
            </CCol></CRow>
          <CRow>
            <CCol>
              <CInputGroup className="mb-3">
                <CCol md={4}>
                  <CInputGroupText>
                    <h6>LastName</h6>
                  </CInputGroupText>
                </CCol>
                <CCol md={4}><CFormInput readOnly placeholder="LastName" name="LastName" value={LastName} />
                </CCol>
                <CCol md={4}>   </CCol>
              </CInputGroup>
            </CCol>
          </CRow>
          <CRow><CCol>
            <CInputGroup className="mb-3">
              <CCol md={4}>   </CCol>
              <CCol md={4}>
                <CButton color="primary"
                  className="mb-2" onClick={() => {
                    confirmTermination()
                  }}>Confirm Termination</CButton></CCol>
              <CCol md={4}>   </CCol>
            </CInputGroup>
          </CCol>
          </CRow>
        </CCardBody >
      </CCard >
    </>
  )
}

export default Termination
